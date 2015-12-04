using System;

using Xamarin.Forms;

namespace XMFormsPage
{
	public class MasterDetailPageDemo : MasterDetailPage { 
		public MasterDetailPageDemo() {
			this.Master = MasterPage();
			this.Master.BackgroundColor = Color.Yellow;
			this.Detail = DetailPage ();
			this.Detail.BackgroundColor = Color.Lime;
		}
		public Page MasterPage() {
			return new ContentPage {
				Title = "Master",
				Content = new Label {
					Text = "Master Page",
					VerticalOptions = LayoutOptions.CenterAndExpand,
					HorizontalOptions = LayoutOptions.CenterAndExpand
				}
			};
		}
		public Page DetailPage() {
			return new ContentPage {
				Content = new Label {
					Text = "Detail Page",
					VerticalOptions = LayoutOptions.CenterAndExpand,
					HorizontalOptions = LayoutOptions.CenterAndExpand
				}	
			};
		}
	}
	public class App : Application
	{
		public App (string labelText)
		{
			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = labelText
						}
					}
				}
			};
			MainPage = new MasterDetailPageDemo ();
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

