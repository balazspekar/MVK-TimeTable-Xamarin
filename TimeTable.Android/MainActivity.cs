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
using TimeTable.SharedProject;
using System.Collections.Generic;
using Android;

namespace TimeTable.Droid
{
    [Activity(Label = "Menetrend", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.DeviceDefault.Light.DarkActionBar")]

    public class MainActivity : Activity
    {
        ListView watchedStations;
        List<string> watchedStationDetails;
        string[] items;

        #region ActionBarMenu
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Layout.ActionMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.actionBarBtnSettings:
                    Console.WriteLine("ActionBar Setting Button Pressed");
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
        #endregion

        
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            watchedStations = FindViewById<ListView>(Resource.Id.watchedStationsListView);

            items = new string[] { "513", "514" };
            var adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);

            watchedStations.Adapter = adapter;

            watchedStations.ItemClick += WatchedStations_ItemClick;

        }

        private void WatchedStations_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var RouteDetails = new Intent(this, typeof(RouteDetails));
            RouteDetails.PutExtra("SMART_ID", items[e.Position]);
            
            StartActivity(RouteDetails);
        }
    }
}

