using System;
using Android.Views;
using Android.Widget;
using TimeTable.SharedProject;
using System.Collections.Generic;
using Android.Content;

namespace TimeTable.Droid.ListViewAdapters
{
    class StationDetailsListViewAdapter : BaseAdapter<Departure>
    {

        public List<Departure> departures;
        private Context context;

        public StationDetailsListViewAdapter(Context context, List<Departure> departures)
        {
            this.departures = departures;
            this.context = context;
        }

        public override Departure this[int position]
        {
            get { return departures[position]; }
        }

        public override int Count
        {
            get { return departures.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.StationDetailsListViewRow, null, false);
            }

            TextView routeNameTextView = row.FindViewById<TextView>(Resource.Id.routeNameTextView);
            routeNameTextView.Text = departures[position].RouteName;

            TextView routeDescTextView = row.FindViewById<TextView>(Resource.Id.routeDescTextView);
            routeDescTextView.Text = departures[position].RouteDescription;

            TextView departureTimeTextView = row.FindViewById<TextView>(Resource.Id.departureTimeTextView);
            departureTimeTextView.Text = departures[position].DepartureTime.ToString();

            TextView minsUntilDepartureTimeTextView = row.FindViewById<TextView>(Resource.Id.minsUntilDepartureTimeTextView);
            var minutesUntilDeparture = departures[position].SecondsUntilDepartureTime / 60;
            minsUntilDepartureTimeTextView.Text = minutesUntilDeparture.ToString();

            return row;

        }
    }
}