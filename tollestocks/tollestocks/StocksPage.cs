using System;

using Xamarin.Forms;

namespace tollestocks
{
	public class StocksPage : ContentPage
	{
		

		public StocksPage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" },
					//listView
				}
			};

		}
	}
}


