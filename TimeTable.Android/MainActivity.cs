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
         
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            _mainListView = FindViewById<ListView>(Resource.Id.mainListView);

            _myItems = new List<string>() { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven" };


            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, _myItems);
            _mainListView.Adapter = adapter;

        }

    }
}

