using System;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace tollemap
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					//VerticalOptions = LayoutOptions.Center,
					Children = {
						new Map(MapSpan.FromCenterAndRadius(
							new Position(37,-122),
							Distance.FromKilometers(10))) {
							VerticalOptions = LayoutOptions.FillAndExpand,
							BackgroundColor = Color.Blue,
							IsShowingUser = true,
						}
					}
				}
			};
		}

		protected override void OnStart ()
		{
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

