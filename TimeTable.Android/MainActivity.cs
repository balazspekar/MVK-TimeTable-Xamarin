using System;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using TimeTable.Droid.ListViewAdapters;

namespace TimeTable.Droid
{
    [Activity(Label = "Megálló", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.Holo.Light")]

    public class MainActivity : Activity
    {
        ListView watchedStations;
        List<Favorite> favorites;
        private MainScreenListViewAdapter adapter;

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
                case Resource.Id.actionBarBtnAdd:
                    //var AddFavStation = new Intent(this, typeof(AddFavStation));
                    //StartActivity(AddFavStation);
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

            favorites = new List<Favorite>();
            favorites.Add(new Favorite { StationNickName = "LAEV", StationId = "514"});
            favorites.Add(new Favorite { StationNickName = "Petőfi tér", StationId = "309"});
            favorites.Add(new Favorite { StationNickName = "Hősök tere", StationId = "569"});
            favorites.Add(new Favorite { StationNickName = "Egyetemi kollégium", StationId = "125"});
            favorites.Add(new Favorite { StationNickName = "Népkert", StationId = "282"});
            favorites.Add(new Favorite { StationNickName = "Centrum", StationId = "83"});
            favorites.Add(new Favorite { StationNickName = "Hajós Alfréd utca", StationId = "167"});
            favorites.Add(new Favorite { StationNickName = "Lévay József utca", StationId = "240"});
            favorites.Add(new Favorite { StationNickName = "Avas városközpont", StationId = "27"});
            favorites.Add(new Favorite { StationNickName = "Alsó-Majláth", StationId = "9"});
            favorites.Add(new Favorite { StationNickName = "Zoltán utca", StationId = "332" });
            favorites.Add(new Favorite { StationNickName = "Repülőtér", StationId = "318" });
            favorites.Add(new Favorite { StationNickName = "Megyei Kórház", StationId = "264" });
            favorites.Add(new Favorite { StationNickName = "Levente Vezér utca", StationId = "234" });
            favorites.Add(new Favorite { StationNickName = "Szondi György utca", StationId = "364" });
            favorites.Add(new Favorite { StationNickName = "Vörösmarty városrész", StationId = "448" });
            favorites.Add(new Favorite { StationNickName = "Auchan BORSOD", StationId = "587" });
            favorites.Add(new Favorite { StationNickName = "Tatárdomb", StationId = "378" });


            adapter = new MainScreenListViewAdapter(this, favorites);

            watchedStations.Adapter = adapter;

            watchedStations.ItemClick += WatchedStations_ItemClick;

        }

        private void WatchedStations_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var RouteDetails = new Intent(this, typeof(RouteDetails));
            RouteDetails.PutExtra("SMART_ID", favorites[e.Position].StationId);
            StartActivity(RouteDetails);
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
        }

        //private void SerializeSettingsToFile(Settings settings)
        //{
        //    var json = JsonConvert.SerializeObject(settings);
        //    var path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
        //    var file = Path.Combine(path, "megallo_settings.txt");

        //    using (var streamWriter = new StreamWriter(file))
        //    {
        //        streamWriter.WriteLine(json);
        //    }
        //}
    }
}

