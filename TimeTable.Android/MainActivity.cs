using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Javax.Security.Auth;
using TimeTable.Shared;

namespace TimeTable.Android
{
    [Activity(Label = "Menetrend Miskolc", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.Black")]
    public class MainActivity : Activity
    {
        private static int count;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.layout1);

            string _data;
            TextView myTextView = FindViewById<TextView>(Resource.Id.textView1);
            Button myButton = FindViewById<Button>(Resource.Id.button1);
            myTextView.Text = "VALAMI";


            Station station = new Station("513");

            
            station.Update();
            _data = station.RawData;
            //System.Threading.Thread.Sleep(3000);
            myTextView.Text = _data;


            myButton.Click += delegate {
                _data = station.RawData;
                myTextView.Text = _data;
            };

            myButton.Click += delegate
            {
                myButton.Text = string.Format("{0} clicks!", count++);
                _data = station.RawData;
                //System.Threading.Thread.Sleep(3000);
                myTextView.Text = _data;
            };


        }

        private void Refresh()
        {
            
        }
    }
}

