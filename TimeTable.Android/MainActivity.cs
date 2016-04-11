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
    [Activity(Label = "Menetrend Miskolc", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.Light.NoTitleBar")]
    public class MainActivity : Activity
    {
        private List<string> _myItems;
        private ListView _mainListView;
        private Station station;
         
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set Content View
            SetContentView(Resource.Layout.Main);

            // Setting up background stuff
            //station = new Station("513");
            //Queue<Departure> schedules = new Queue<Departure>();

            // Setting up screen elements
            _mainListView = FindViewById<ListView>(Resource.Id.mainListView);

            _myItems = new List<string>() { "Gergo", "Balazs", "Istok" };


            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, _myItems);
            _mainListView.Adapter = adapter;

        }

    }
}

