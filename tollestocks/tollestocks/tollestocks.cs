using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace tollestocks
{
	public class App : Application
	{
		ListView listView = new ListView {
			ItemTemplate = new DataTemplate(() => {
				Label nameLabel = new Label();
				nameLabel.SetBinding(Label.TextProperty, "Name");
				return new ViewCell
				{
					View = new StackLayout {
						Padding = new Thickness(0,5),
						Orientation = StackOrientation.Horizontal,
						Children = {
							new StackLayout {
								VerticalOptions = LayoutOptions.Center,
								Spacing = 0,
								Children = {
									nameLabel
								}
							}

						}

					}
				};
			})
		};
		public App ()
		{
			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						},
						listView
					}
				}
			};


			//listView.ItemsSource = new System.Collections.Generic.List<tollestocks.Quote> { 
			//	new tollestocks.Quote { Name="hello" }
			//};


		}
		private async void WhatEver() {
			//Xamarin.Forms.Device.BeginInvokeOnMainThread (async () => {

			//});
			var s = await Repository.GetQuotesAsync();
			listView.ItemsSource =s;
		}
		protected override void OnStart ()
		{
			WhatEver ();
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

