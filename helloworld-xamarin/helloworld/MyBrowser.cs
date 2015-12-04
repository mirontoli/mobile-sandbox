using Android.App;
using Android.Widget;
using Android.OS;
using Android.Webkit;
using System;

namespace helloworld
{
	[Activity (Label = "IntentFilters", MainLauncher = true, Icon = "@mipmap/icon")]


	[IntentFilter(new [] {"android.intent.action.VIEW", "net.learn2develop.MyBrowser"}, 
		DataScheme = "http", 
		Categories = new[] { "android.intent.category.DEFAULT" })]

	/*
	[IntentFilter(new [] {"android.intent.action.VIEW", "net.learn2develop.MyBrowser"}, 
		DataMimeType="text/html", 
		Categories = new[] { "android.intent.category.DEFAULT" })]
    */

	public class MyBrowserActivity : Activity
	{

		protected override void OnCreate (Bundle savedInstanceState)
		{
			//Xamarin.Insights.Initialize (XamarinInsights.ApiKey, this);
			base.OnCreate (savedInstanceState);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Browser);


			WebView webView = FindViewById<WebView> (Resource.Id.webView);
			webView.SetWebViewClient(new Callback());


			string url = Intent.Data.ToString();
			if (url != "") {
				webView.LoadUrl (url);
			} else {
				webView.LoadUrl ("http://www.google.com");
			}


			/*
			string html = Intent.GetStringExtra ("html");
			if (html != "") {
				webView.LoadDataWithBaseURL (null, html, "text/html", "utf-8", null);
			}
			*/

		}

		class Callback: WebViewClient {
			public override bool ShouldOverrideUrlLoading (WebView view, string url)
			{
				return false;
			}
		}

	}
}

