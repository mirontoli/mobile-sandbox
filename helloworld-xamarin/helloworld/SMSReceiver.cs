
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Telephony;
using Android.Locations;

namespace helloworld
{
	[BroadcastReceiver]
	[IntentFilter (new[] { "android.provider.Telephony.SMS_RECEIVED" }, Priority = 1000)]
	public class SMSReceiver : BroadcastReceiver, ILocationListener
	{
		
		LocationManager lm;
		string msg = string.Empty;
		string tel = string.Empty;
		Context _context = null;
		public void OnLocationChanged (Location location)
		{
			lm.RemoveUpdates (this);
			SmsManager smsManager = SmsManager.Default;
			var url = "http://maps.google.com/maps?q=" + location.Latitude + "," + location.Longitude;
			smsManager.SendTextMessage(tel, null, "aja baja", null, null);
			Toast.MakeText(_context, "SMS sent.", ToastLength.Short).Show();
			//Console.WriteLine ("");
			//throw new NotImplementedException ();
		}

		public void OnProviderDisabled (string provider)
		{
			Console.WriteLine ("");
		}

		public void OnProviderEnabled (string provider)
		{
			Console.WriteLine ("");
		}

		public void OnStatusChanged (string provider, Availability status, Bundle extras)
		{
			Console.WriteLine ("");
		}

		public override void OnReceive (Context context, Intent intent)
		{
			_context = context;
			lm = (LocationManager) context.GetSystemService (Context.LocationService);
			Bundle bundle = intent.Extras;
			SmsMessage[] msgs = null;
			if (bundle != null) {
				Java.Lang.Object[] pdus = (Java.Lang.Object[])bundle.Get ("pdus");
				msgs = new SmsMessage[pdus.Length];
				for (var i = 0; i < msgs.Length; i++) {
					msgs[i] = SmsMessage.CreateFromPdu((byte[])pdus[i]);
					if (i == 0) {
						tel = msgs [i].OriginatingAddress;
					}
					msg += msgs [i].MessageBody;
				}
			}


			Toast.MakeText (context, tel + ": " + msg, ToastLength.Short).Show ();
			if (msg.StartsWith ("intercept")) {
				//InvokeAbortBroadcast ();
				lm.RequestLocationUpdates(LocationManager.NetworkProvider, 0, 0, this);
			}
		}
	}
}

