using System;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
namespace depend
{
	public class App : Application
	{
		Label lblLat = new Label {
			XAlign = TextAlignment.Center,
			Text = "Lat"
		},
		lblLng = new Label { 
			XAlign = TextAlignment.Center,
			Text = "Lng"
		};
		IMyLocation loc;
		//MapSpan span = ;
		Map map = new Map(MapSpan.FromCenterAndRadius(new Position(37,-122), Distance.FromKilometers(1))) {
			VerticalOptions = LayoutOptions.FillAndExpand,
			BackgroundColor = Color.Blue,
			IsShowingUser = true
		};
		public App ()
		{

			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					//VerticalOptions = LayoutOptions.Center,
					Children = {
						map,

						//new Label {
						//	XAlign = TextAlignment.Center,
						//	Text = "Current Location"//DependencyService.Get<IMyInterface>().GetPlatformName()
						//},
						//lblLat,
						//lblLng
					}
				}
			};
		}

		protected override void OnStart ()
		{
			loc = DependencyService.Get<IMyLocation> ();
			loc.locationObtained += (object sender, ILocationEventArgs e) => {
				var lat = e.lat;
				var lng = e.lng;

				var span = MapSpan.FromCenterAndRadius(new Position(lat, lng), Distance.FromKilometers(1));
				//span.LatitudeDegrees = lat;
				//span.LongitudeDegrees = lng;

				map.MoveToRegion(span);
				lblLat.Text = lat.ToString();
				lblLng.Text = lng.ToString();
			};
			loc.ObtainMyLocation ();
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

