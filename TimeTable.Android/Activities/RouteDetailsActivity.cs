using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using TimeTable.SharedProject;
using System.Collections.Generic;
using TimeTable.Droid.ListViewAdapters;
using Android.Support.V4.Widget;
using System.ComponentModel;
using System.Threading;
using Android.Support.V7.Widget;
using Android.Support.V7.App;

namespace TimeTable.Droid
{
    [Activity(Label = "Virtuális Megállótábla", Icon = "@android:color/transparent", Theme = "@style/MyTheme")]
    public class RouteDetailsActivity : ActionBarActivity
    {
        private SwipeRefreshLayout refresher;
        private ListView routeDetailsListView;
        private Station station;
        private string smartId;
        private StationDetailsListViewAdapter adapter;
        private List<Departure> schedules = new List<Departure>();
        private string stationNick;
        private Thread t;
        private int remain = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            // Reading SMART ID from previous Activity
            smartId = Intent.GetStringExtra("SMART_ID") ?? "Data not available";
            stationNick = Intent.GetStringExtra("STATION_NICK") ?? "Data not available";

            // Setting the layout
            SetContentView(Resource.Layout.ScreenRouteDetails);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbarRouteDetails);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = stationNick;
            

            refresher = FindViewById<SwipeRefreshLayout>(Resource.Id.refresher);
            routeDetailsListView = FindViewById<ListView>(Resource.Id.routeDetailsListView);

            // Instantiating a Station and requesting the schedules for the very first time
            station = new Station(smartId);
            
            // Displaying the details
            adapter = new StationDetailsListViewAdapter(this, schedules);
            routeDetailsListView.Adapter = adapter;

            var FirstTimeWorker = new BackgroundWorker();
            FirstTimeWorker.DoWork += FirstTimeWorker_DoWork;
            FirstTimeWorker.RunWorkerCompleted += FirstTimeWorker_RunWorkerCompleted;
            FirstTimeWorker.RunWorkerAsync();

            // Setting up an event handler for the RefreshLayout
            refresher.Refresh += Refresher_Refresh;

            Thread t = new Thread(AutoRefresher);
            t.Start();
        }

        private void AutoRefresher()
        {
            remain = 5;
            for (int i = 4; i >= 0; i--)
            {
                schedules = station.Schedules;
                System.Threading.Thread.Sleep(5000);
                remain = i;
                RunOnUiThread(RefreshUI);
            }
        }

        private void FirstTimeWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            schedules = station.Schedules;
        }

        private void FirstTimeWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RunOnUiThread(RefreshUI);
        }

        private void Refresher_Refresh(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            schedules = station.Schedules;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RunOnUiThread(RefreshUI);
            refresher.Refreshing = false;
        }

        private void RefreshUI()
        {
            adapter = new StationDetailsListViewAdapter(this, schedules);
            routeDetailsListView.Adapter = adapter;

            if (remain == 0)
            {
                Toast.MakeText(this, "Az automata frissítés befejezõdött. Simítsd lefelé a listát a manuális frissítéshez!", ToastLength.Long).Show();
            }
            else
            { 
                Toast.MakeText(this, "Még " + remain.ToString() + " alkalommal frissít.", ToastLength.Short).Show();
            }

        }

    }
}