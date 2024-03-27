using System;
using System.Threading;
using ASCOM;
using ASCOM.Com.DriverAccess;

namespace MountController {
	public class gptSolution {
		private static int _sleepTime = -1;  //  Mount settle time after slew
		private static double _stepSize     = -1.0; // Step size for slewing
		private static double _circleRadius = -1.0; // 1° radius

		public static void Go() {
			//  Prompt for telescope selection
			ConsoleKeyInfo CKI = new ConsoleKeyInfo();
			var tNumber = -1;

			//  Get valid user input for telescope selection
			while(tNumber < 0 || tNumber >= Telescope.Telescopes.Count) {
				Console.WriteLine("Select telescope:");
				Telescope.Telescopes.Select((t, i) => {
					Console.WriteLine($"{i}: {t.Name}");
					return t;
				}).ToList();

				CKI = Console.ReadKey();
				tNumber = int.TryParse(CKI.KeyChar.ToString(), out tNumber) ? tNumber : -1;
			}

			//  Get valid user input for radius of circle
			while(_circleRadius <= 0 || _circleRadius > 20.0) {
				Console.WriteLine("Select circle radius (°):");

				var readSize = Console.ReadLine();
				_circleRadius = double.TryParse(readSize, out _circleRadius) ? _circleRadius : -1;
			}

			//  Get valid user input for angle step size
			while(_stepSize <= 0 || _stepSize > 180.0) {
				Console.WriteLine("Select angle stepsize (°):");

				var readSize = Console.ReadLine();
				_stepSize = double.TryParse(readSize, out _stepSize) ? _stepSize : -1;
			}

			//  Get valid user input for mount sleep/settle time
			while(_sleepTime < 0 || _sleepTime > 2000) {
				Console.WriteLine("Select mount sleep time (ms):");

				var readSize = Console.ReadLine();
				_sleepTime = int.TryParse(readSize, out _sleepTime) ? _sleepTime : -1;
			}


			// Connect to the ASCOM Telescope driver
			var progID = Telescope.Telescopes[tNumber].ProgID;
			Telescope telescope = new Telescope(progID);
			telescope.Connected = true;

			// Check if the telescope is connected
			if(!telescope.Connected) {
				Console.WriteLine("Telescope not connected.");
				return;
			}

			double currentRA = 0;
			double currentDec = 0;

			//  Set up parameters for simulator
			if(telescope.Name.Contains("simulator", StringComparison.CurrentCultureIgnoreCase)) {
				telescope.SiteElevation = 199;  //  Cleveland
				telescope.SiteLatitude = 41.47606;
				telescope.SiteLongitude = -81.78017;
				telescope.UTCDate = (new DateTime(2024, 4, 8, 15, 14, 0)).ToUniversalTime();  //  Eclipse time
				telescope.TrackingRate = ASCOM.Common.DeviceInterfaces.DriveRate.Solar;
				telescope.Tracking = true;

				currentRA = 1.196;
				currentDec = 7.6055;

				try {
					telescope.TargetDeclination = currentDec;
					telescope.TargetRightAscension = currentRA;
					telescope.SlewToTarget();
				}
				catch(Exception ex) {
					Console.WriteLine("Error: [sim] " + ex.Message);
				}
			}
			else {
				//  real scope 

				// Get current right ascension and declination
				currentRA = telescope.RightAscension;
				currentDec = telescope.Declination;
			}


			//  Set initial params
			double centerX = currentRA; // Center in current RA
			double centerY = currentDec; // Center in current Dec
			double angle = 0;

			try {
				// Slew around the circle
				while(angle < 360) {
					// Calculate new position on the circle
					double newRA  = centerX + (_circleRadius * Math.Cos(angle * Math.PI / 180));
					double newDec = centerY + (_circleRadius * Math.Sin(angle * Math.PI / 180));

					//  Do NOT pier flip if we hit the edge case.  Just truncate RA to a small value
					newRA = newRA < 0 ? 0.1 : newRA;

					// Slew to the new position
					//if(telescope.CanMoveAxis(ASCOM.Common.DeviceInterfaces.TelescopeAxis.Primary) &&
					//	telescope.CanMoveAxis(ASCOM.Common.DeviceInterfaces.TelescopeAxis.Secondary)) {
					//	telescope.MoveAxis(ASCOM.Common.DeviceInterfaces.TelescopeAxis.Primary, 2.5);
					//	Console.WriteLine("Can move axes");
					//}
					//else {
						telescope.SlewToCoordinates(newRA, newDec);
					//}

					Console.WriteLine($"{newRA}, {newDec}");

					// Wait for the slew to complete (adjust sleep time as needed)
					Thread.Sleep(_sleepTime);

					// Increment angle
					angle += _stepSize;
				}

				// Return to the center
				telescope.SlewToCoordinates(centerX, centerY);

				// Wait for the slew to complete (adjust sleep time as needed)
				Thread.Sleep(_sleepTime);

				Console.WriteLine("Slewing complete.");
			}
			catch(Exception ex) {
				Console.WriteLine("Error: " + ex.Message);
			}
			finally {
				// Disconnect from the telescope
				telescope.Connected = false;
			}
		}
	}
}