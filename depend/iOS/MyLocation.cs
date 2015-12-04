using System;
using CoreLocation;
using depend.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(MyLocation))]
namespace depend.iOS
{
	public class LocationEventArgs: EventArgs, ILocationEventArgs {
		public double lat { get; set;}
		public double lng { get; set;}
	}
	public class MyLocation : IMyLocation
	{
		CLLocationManager lm;
		public EventHandler<ILocationEventArgs> locationObtained;
		event EventHandler<ILocationEventArgs> IMyLocation.locationObtained {
			add { locationObtained += value; }
			remove { locationObtained -= value; }
		}
		public void ObtainMyLocation() {
			lm = new CLLocationManager ();
			lm.DesiredAccuracy = CLLocation.AccuracyBest;
			lm.DistanceFilter = CLLocationDistance.FilterNone;
			lm.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) => {
				var locations = e.Locations;
				var strLocation = locations [locations.Length - 1].Coordinate.Longitude.ToString ();
				LocationEventArgs args = new LocationEventArgs ();
				args.lat = locations [locations.Length - 1].Coordinate.Latitude;
				args.lng = locations [locations.Length - 1].Coordinate.Longitude;
				locationObtained (this, args);
			};

			lm.AuthorizationChanged += (object sender, CLAuthorizationChangedEventArgs e) => {
				if (e.Status == CLAuthorizationStatus.AuthorizedWhenInUse) {
					lm.StartUpdatingLocation();
				}
			};
			lm.RequestWhenInUseAuthorization ();
		}
		~MyLocation ()
		{
			lm.StopUpdatingLocation ();
		}
	}
}

