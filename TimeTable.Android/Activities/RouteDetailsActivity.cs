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

namespace TimeTable.Droid
{
    [Activity(Label = "Virtuális Megállótábla", Icon = "@drawable/icon", Theme = "@android:style/Theme.Holo.Light")]
    public class RouteDetailsActivity : Activity
    {
        private SwipeRefreshLayout refresher;
        private ListView routeDetailsListView;
        private Station station;
        private string smartId;
        private StationDetailsListViewAdapter adapter;
        private List<Departure> schedules;
        private TextView txtLastUpdated;
        private ProgressBar progressbar;


        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            // Setting the layout
            SetContentView(Resource.Layout.ScreenRouteDetails);
            txtLastUpdated = FindViewById<TextView>(Resource.Id.txtLastUpdated);

            // Reading SMART ID from previous Activity
            smartId = Intent.GetStringExtra("SMART_ID") ?? "Data not available";

            // Instantiating a Station and requesting the schedules for the very first time
            station = new Station(smartId);

            refresher = FindViewById<SwipeRefreshLayout>(Resource.Id.refresher);
            routeDetailsListView = FindViewById<ListView>(Resource.Id.routeDetailsListView);


            // Delegate
            refresher.Refresh += Refresher_Refresh;

            schedules = station.Schedules;
            adapter = new StationDetailsListViewAdapter(this, schedules);
            routeDetailsListView.Adapter = adapter;
            UpdateLastUpdateTextView();

        }


        protected override void OnResume()
        {
            base.OnResume();
            UpdateLastUpdateTextView();
            schedules = station.Schedules;
            adapter = new StationDetailsListViewAdapter(this, schedules);
            routeDetailsListView.Adapter = adapter;

        }

        public virtual void onBackPressed()
        {
            base.OnBackPressed();
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
        }

        private void Refresher_Refresh(object sender, EventArgs e)
        {
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