using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Locations;
using Android.Runtime;
using Android.Views;
using Android.Content;

namespace helloworld
{
	[Activity (Label = "helloworld", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity, ILocationListener
	{
		//int count = 1;
		LocationManager lm;
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			lm = (LocationManager)GetSystemService (LocationService);

			ConfigureClickables ();
			/*
			EditText txtName = FindViewById<EditText> (Resource.Id.txtName);
			Button btn = FindViewById<Button> (Resource.Id.btnOK);
			btn.Click += delegate {
				Toast.MakeText(this, "Tolle was here, " + txtName.Text, ToastLength.Long).Show();
			};
			*/
			Console.WriteLine ("In OnCreate() now");
		}
		public void ConfigureClickables() {
			FindViewById<Button>(Resource.Id.btnMakeCalls).Click += delegate {
				Intent i = new Intent(Intent.ActionDial);
				i.SetData(Android.Net.Uri.Parse("tel:+46727228210"));
				StartActivity(i);
			};
			FindViewById<Button>(Resource.Id.btnViewWebPages).Click += delegate {
				Intent i = new Intent(Intent.ActionView);
				i.SetData(Android.Net.Uri.Parse("http://google.se"));
				StartActivity(i);
			};
			FindViewById<Button>(Resource.Id.btnViewMaps).Click += delegate {
				Intent i = new Intent(Intent.ActionView);
				i.SetData(Android.Net.Uri.Parse("geo:37.827500, -122.481670"));
				StartActivity(i);
			};

			FindViewById<Button>(Resource.Id.btnGooglePlay).Click += delegate {
				Intent i = new Intent(Intent.ActionView);
				i.SetData(Android.Net.Uri.Parse("market://details?id=com.zinio.mobile.android.reader"));
				StartActivity(i);
			};
			FindViewById<Button>(Resource.Id.btnSendEmail).Click += delegate {
				Intent i = new Intent(Intent.ActionSend);
				i.SetData(Android.Net.Uri.Parse("mailto:"));
				String[] to = { "someone@example.com", "someone2@example.com" };
				String[] cc = { "bla@bla.com", "bla2@bla.com" };
				i.PutExtra(Intent.ExtraEmail, to);
				i.PutExtra(Intent.ExtraCc, cc);
				i.PutExtra(Intent.ExtraSubject, "Subject goes here...");
				i.PutExtra(Intent.ExtraText, "Message goes here...");
				i.SetType("message/rfc822");
				StartActivity(i);
			};
			FindViewById<Button>(Resource.Id.btnSendText).Click += delegate {
				Intent i = new Intent(Intent.ActionSend);
				i.SetType("text/plain");
				i.PutExtra(Intent.ExtraSubject, "Subject...");
				i.PutExtra(Intent.ExtraText, "Text...");
				StartActivity(Intent.CreateChooser(i, "Share via..."));
			};
			FindViewById<Button>(Resource.Id.btnSendBinary).Click += delegate {
				Android.Net.Uri uriToImage = Android.Net.Uri.Parse("android.resource://" + PackageName + "/drawable/" + Convert.ToString(Resource.Mipmap.Icon));
				Intent i = new Intent(Intent.ActionSend);
				i.SetType("image/jpeg");
				i.PutExtra(Intent.ExtraStream, uriToImage);
				i.PutExtra(Intent.ExtraText, "Text...");
				StartActivity(Intent.CreateChooser(i, "Share via..."));
			};
			FindViewById<Button> (Resource.Id.myButton).Click += delegate {
				Intent i = new Intent(Android.Content.Intent.ActionView);
				i.SetData(Android.Net.Uri.Parse("http://chuvash.eu"));
				StartActivity(i);

			} ;
			FindViewById<Button> (Resource.Id.btnFakeSms).Click += delegate {
				return;
				//http://stackoverflow.com/a/12489822/632117
				Intent intent = new Intent();
				intent.SetClassName("com.android.mms",
					"com.android.mms.transaction.SmsReceiverService");
				intent.SetAction("android.provider.Telephony.SMS_RECEIVED");
				intent.PutExtra("pdus", new string[] { "+46727228210" });
				intent.PutExtra("format", "3gpp");
				StartActivity(intent);
			} ;

		}


		protected override void OnStop() 
		{
			base.OnStop ();
			Console.WriteLine ("In OnStop() now");
		}
		protected override void OnPause() 
		{
			base.OnPause ();
			Console.WriteLine ("In OnPause() now");
			lm.RemoveUpdates (this);

		}
		protected override void OnStart() 
		{
			base.OnStart ();
			Console.WriteLine ("In OnStart() now");
		}
		protected override void OnResume() 
		{
			base.OnResume ();
			Console.WriteLine ("In OnResume() now");
			lm.RequestLocationUpdates (LocationManager.NetworkProvider, 0, 0, this);
		}
		protected override void OnDestroy() 
		{
			base.OnDestroy ();
			Console.WriteLine ("In OnDestroy() now");
		}
		protected override void OnRestart() 
		{
			base.OnRestart ();
			Console.WriteLine ("In OnRestart() now");
		}
		public void OnLocationChanged(Location loc)
		{
			if (loc != null) 
			{
				Toast.MakeText (this, "Location changed: Lat: " + loc.Latitude + " Lng: " + loc.Longitude, ToastLength.Long).Show ();
			}
		}
		public void OnProviderDisabled(string provider) {}
		public void OnProviderEnabled(string provider) {
		}
		public void OnStatusChanged(string provider, Availability status, Bundle extras) {
		}
	}
}


