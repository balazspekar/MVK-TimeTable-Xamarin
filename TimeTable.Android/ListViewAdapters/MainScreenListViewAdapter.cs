using System;
using Android.Views;
using Android.Widget;
using TimeTable.SharedProject;
using System.Collections.Generic;
using Android.Content;

namespace TimeTable.Droid.ListViewAdapters
{
    class MainScreenListViewAdapter : BaseAdapter<Favorite>
    {

        public List<Favorite> favorites;
        private Context context;

        public MainScreenListViewAdapter(Context context, List<Favorite> favorites)
        {
            this.favorites = favorites;
            this.context = context;
        }

        public override Favorite this[int position]
        {
            get
            {
                return favorites[position];
            }
        }

        public override int Count
        {
            get
            {
                return favorites.Count;
            }
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
                row = LayoutInflater.From(context).Inflate(Resource.Layout.ListViewRowMainScreen2, null, false);
            }

            TextView txtStationNick = row.FindViewById<TextView>(Resource.Id.txtStationNick);
            txtStationNick.Text = favorites[position].StationNickName;

            TextView txtStationId = row.FindViewById<TextView>(Resource.Id.txtStationId);
            txtStationId.Text = "Megállóazonosító: " + favorites[position].StationId;

            ImageView imgView = row.FindViewById<ImageView>(Resource.Id.imageView1);
            imgView.SetImageResource(Resource.Drawable.locationpin);

            return row;
        }
    }
}