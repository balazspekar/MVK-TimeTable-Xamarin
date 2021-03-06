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
                row = LayoutInflater.From(context).Inflate(Resource.Layout.ListViewRowStationDetails, null, false);
            }

            TextView routeNameTextView = row.FindViewById<TextView>(Resource.Id.routeNameTextView);
            routeNameTextView.Text = departures[position].RouteName;

            TextView routeDescTextView = row.FindViewById<TextView>(Resource.Id.routeDescTextView);
            routeDescTextView.Text = "Viszonylat: " + departures[position].RouteDescription;

            TextView departureTimeTextView = row.FindViewById<TextView>(Resource.Id.departureTimeTextView);
            var departureTime = departures[position].DepartureTime.ToString("HH:mm");
            departureTimeTextView.Text = departureTime;

            TextView minsUntilDepartureTimeTextView = row.FindViewById<TextView>(Resource.Id.minsUntilDepartureTimeTextView);

            var secondsUntilDeparture = departures[position].SecondsUntilDepartureTime;

            if (secondsUntilDeparture <= 30)
            {
                minsUntilDepartureTimeTextView.SetTextColor(Android.Graphics.Color.Red);
                minsUntilDepartureTimeTextView.Text = "Esed�kes";
            } else if (secondsUntilDeparture <= 60) {
                minsUntilDepartureTimeTextView.SetTextColor(Android.Graphics.Color.Red);
                minsUntilDepartureTimeTextView.Text = "1 perc m�lva indul";
            } else
            {
                minsUntilDepartureTimeTextView.Text = (secondsUntilDeparture / 60).ToString() + " perc m�lva indul";
            }

            return row;

        }
    }
}