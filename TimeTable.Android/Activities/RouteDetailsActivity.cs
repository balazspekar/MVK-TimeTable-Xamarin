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

namespace TimeTable.Droid
{
    [Activity(Label = "Virtuális Megállótábla", Icon = "@android:color/transparent", Theme = "@android:style/Theme.Material.Light.DarkActionBar")]
    public class RouteDetailsActivity : Activity
    {
        private SwipeRefreshLayout refresher;
        private ListView routeDetailsListView;
        private Station station;
        private string smartId;
        private StationDetailsListViewAdapter adapter;
        private List<Departure> schedules = new List<Departure>();
        private TextView txtLastUpdated;
        private TextView txtTitleMarquee;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            // Reading SMART ID from previous Activity
            smartId = Intent.GetStringExtra("SMART_ID") ?? "Data not available";

            // Setting the layout
            SetContentView(Resource.Layout.ScreenRouteDetails);
            refresher = FindViewById<SwipeRefreshLayout>(Resource.Id.refresher);
            txtLastUpdated = FindViewById<TextView>(Resource.Id.txtLastUpdated);
            txtTitleMarquee = FindViewById<TextView>(Resource.Id.txtTitleMarquee);
            txtTitleMarquee.Selected = true;
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
        }

        private void FirstTimeWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RunOnUiThread(RefreshUI);
        }

        private void FirstTimeWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            txtLastUpdated.SetTextColor(Android.Graphics.Color.Red);
            txtLastUpdated.Text = "Adatok letöltése...";
            schedules = station.Schedules;
        }

        private void Refresher_Refresh(object sender, EventArgs e)
        {
            txtLastUpdated.SetTextColor(Android.Graphics.Color.Red);
            txtLastUpdated.Text = "Adatok letöltése...";
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RunOnUiThread(RefreshUI);
            refresher.Refreshing = false;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            schedules = station.Schedules;
        }

        private void RefreshUI()
        {
            txtLastUpdated.SetTextColor(Android.Graphics.Color.Black);
            UpdateLastUpdateTextView();
            adapter = new StationDetailsListViewAdapter(this, schedules);
            routeDetailsListView.Adapter = adapter;

        }

        private void UpdateLastUpdateTextView()
        {
            txtLastUpdated.Text = "Utoljára Frissítve: " + DateTime.Now.ToString("HH:mm:ss");
        }
    }
}