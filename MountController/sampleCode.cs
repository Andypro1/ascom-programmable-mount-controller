using ASCOM.Com.DriverAccess;
using ASCOM.Common.DeviceInterfaces;
using System.Runtime.InteropServices;

namespace MountController {
	public class SampleCode {
		static void Go() {
			//string progID;

			//Util U = new Util();
			//Console.WriteLine(string.Join("; ", Telescope.Telescopes.Select(t => t.Name)));

			//#region Telescope
			//Console.WriteLine("\r\nTelescope:");
			////progID = Telescope.Telescopes.Telescope.Choose("ASCOM.Simulator.Telescope");

			//progID = Telescope.Telescopes.Where(t => t.Name == "Simulator").First().ProgID;

			//if(progID != "") {
			//	Telescope T = new Telescope(progID);
			//	T.Connected = true;
			//	Console.WriteLine("  Connected to " + progID);
			//	Console.WriteLine("  Current LST = " + U.HoursToHMS(T.SiderealTime));
			//	Console.WriteLine("  Current RA  = " + U.HoursToHMS(T.RightAscension));
			//	Console.WriteLine("  Current DEC = " + U.DegreesToDMS(T.Declination));
			//	Console.WriteLine("  CanSetTracking = " + T.CanSetTracking);
			//	if(T.CanSetTracking) {
			//		Console.WriteLine("  Turning Tracking off...");
			//		T.Tracking = false;
			//		Console.WriteLine("  Tracking is now " + (T.Tracking ? "on" : "off") + ".");
			//		Console.WriteLine("  Wait 5 seconds...");
			//		U.WaitForMilliseconds(5000);
			//		Console.WriteLine("  Turning Tracking back on...");
			//		T.Tracking = true;
			//	}
			//	Console.WriteLine("  Latitude = " + U.DegreesToDMS(T.SiteLatitude));
			//	Console.WriteLine("  Longitude = " + U.DegreesToDMS(T.SiteLongitude));
			//	Console.Write("  Slewing to point 1");
			//	T.SlewToCoordinatesAsync(T.SiderealTime - 2, (T.SiteLatitude > 0 ? +55 : -55));
			//	while(T.Slewing) {
			//		Console.Write(".");
			//		U.WaitForMilliseconds(300);
			//	}
			//	Console.WriteLine("\r\n  Slew complete.");
			//	Console.Write("  Slewing to point 2");
			//	T.SlewToCoordinatesAsync(T.SiderealTime + 2, (T.SiteLatitude > 0 ? +35 : -35));
			//	while(T.Slewing) {
			//		Console.Write(".");
			//		U.WaitForMilliseconds(300);
			//	}
			//	Console.WriteLine("\r\n  Slew complete.");
			//	//IAxisRates AxR = T.AxisRates(TelescopeAxes.axisPrimary);
			//	//Console.WriteLine("  " + AxR.Count + " rates");
			//	//if(AxR.Count == 0)
			//	//	Console.WriteLine("  Empty AxisRates");
			//	//else
			//	//	foreach(IRate r in AxR)
			//	//		Console.WriteLine("  Max=" + r.Maximum + " Min=" + r.Minimum);
			//	//ITrackingRates TrR = T.TrackingRates;
			//	//if(TrR.Count == 0)
			//	//	Console.WriteLine("  Empty TrackingRates!");
			//	//else
			//	//	foreach(DriveRates dr in TrR)
			//	//		Console.WriteLine("  DriveRate=" + dr);
			//	T.Connected = false;
			//	T.Dispose();
			//}
			//#endregion

			//#region Camera
			//Console.WriteLine("\r\nCamera:");
			//progID = Camera.Choose("ASCOM.Simulator.Camera");
			//if(progID != "") {
			//	Camera C = new Camera(progID);
			//	C.Connected = true;
			//	Console.WriteLine("  Connected to " + progID);
			//	Console.WriteLine("  Description = " + C.Description);
			//	Console.WriteLine("  Pixel size = " + C.PixelSizeX + " * " + C.PixelSizeY);
			//	Console.WriteLine("  Camera size = " + C.CameraXSize + " * " + C.CameraYSize);
			//	Console.WriteLine("  Max Bin = " + C.MaxBinX + " * " + C.MaxBinY);
			//	Console.WriteLine("  Bin = " + C.BinX + " * " + C.BinY);
			//	Console.WriteLine("  MaxADU = " + C.MaxADU);
			//	Console.WriteLine("  CameraState = " + C.CameraState.ToString());
			//	Console.WriteLine("  CanAbortExposure = " + C.CanAbortExposure);
			//	Console.WriteLine("  CanAsymmetricBin = " + C.CanAsymmetricBin);
			//	Console.WriteLine("  CanGetCoolerPower = " + C.CanGetCoolerPower);
			//	Console.WriteLine("  CanPulseGuide = " + C.CanPulseGuide);
			//	Console.WriteLine("  CanSetCCDTemperature = " + C.CanSetCCDTemperature);
			//	Console.WriteLine("  CanStopExposure = " + C.CanStopExposure);
			//	Console.WriteLine("  CCDTemperature = " + C.CCDTemperature);
			//	if(C.CanGetCoolerPower)
			//		Console.WriteLine("  CoolerPower = " + C.CoolerPower);
			//	Console.WriteLine("  ElectronsPerADU = " + C.ElectronsPerADU);
			//	Console.WriteLine("  FullWellCapacity = " + C.FullWellCapacity);
			//	Console.WriteLine("  HasShutter = " + C.HasShutter);
			//	Console.WriteLine("  HeatSinkTemperature = " + C.HeatSinkTemperature);
			//	if(C.CanPulseGuide)
			//		Console.WriteLine("  IsPulseGuiding = " + C.IsPulseGuiding);
			//	Console.Write("  Take 15 second image");
			//	C.StartExposure(15.0, true);
			//	while(!C.ImageReady) {
			//		Console.Write(".");
			//		U.WaitForMilliseconds(300);
			//	}
			//	Console.WriteLine("\r\n  Exposure complete, ready for download.");
			//	Console.WriteLine("  CameraState = " + C.CameraState.ToString());
			//	Console.WriteLine("  LastExposureDuration = " + C.LastExposureDuration);
			//	Console.WriteLine("  LastExposureStartTime = " + C.LastExposureStartTime);
			//	int[,] imgArray = (int[,])C.ImageArray;
			//	Console.WriteLine("  Array is " + (imgArray.GetUpperBound(0) + 1) + " by " + (imgArray.GetUpperBound(1) + 1));
			//	C.Connected = false;
			//	C.Dispose();
			//}
			//#endregion
		}
	}
}
