using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Json;

namespace JsonConsumer
{
    [Activity(Label = "JsonConsumer", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {


        public async void GetPlacesAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://api.icndb.com/jokes/random");
            var response = await client.GetAsync("");
            var jsonString = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonValue.Parse(jsonString);
            var joke = jsonObject["value"]["joke"].ToString();
            //postalCodesItems.ForEach(i => RunOnUiThread(() =>
            RunOnUiThread(() =>
            {
                Toast.MakeText(this, joke, ToastLength.Long).Show();
            });

        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Task t = new Task(GetPlacesAsync);
            t.Start();
        }
    }
}

