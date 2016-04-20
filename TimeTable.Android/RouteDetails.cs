using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using TimeTable.SharedProject;
using System.Collections.Generic;
using TimeTable.Droid.ListViewAdapters;

namespace TimeTable.Droid
{
    [Activity(Label = "RouteDetails")]
    public class RouteDetails : Activity
    {
        ListView routeDetailsListView;
        Station station;
        string smartId;
        List<Departure> schedules;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            smartId = Intent.GetStringExtra("SMART_ID") ?? "Data not available";
            station = new Station(smartId);
            schedules = station.Schedules;

            SetContentView(Resource.Layout.RouteDetails);
            routeDetailsListView = FindViewById<ListView>(Resource.Id.routeDetailsListView);

            var adapter = new StationDetailsListViewAdapter(this, schedules);

            routeDetailsListView.Adapter = adapter;


            
        }
    }
}