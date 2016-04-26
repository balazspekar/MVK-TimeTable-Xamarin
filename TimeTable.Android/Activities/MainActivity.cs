using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using TimeTable.Droid.ListViewAdapters;

namespace TimeTable.Droid
{
    [Activity(Label = "Megálló", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.Holo.Light")]

    public class MainActivity : Activity
    {
        // UI Fields
        private ListView listViewFavorites;
        private MainScreenListViewAdapter adapter;

        // Data Fields
        private List<Favorite> favorites;

        #region ActionBarMenu
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Layout.MenuMainScreenActionMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.actionBarBtnAdd:
                    var addFavoriteActivity = new Intent(this, typeof(AddFavoriteActivity));
                    StartActivity(addFavoriteActivity);
                    this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }
        #endregion

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ScreenMain);

            listViewFavorites = FindViewById<ListView>(Resource.Id.listViewFavorites);

            favorites = Helpers.StorageHandler.Deserialize();
            

            adapter = new MainScreenListViewAdapter(this, favorites);

            listViewFavorites.Adapter = adapter;

            listViewFavorites.ItemClick += ListViewFavorites_ItemClick;

        }

        private void ListViewFavorites_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var routeDetailsActivity = new Intent(this, typeof(RouteDetailsActivity));
            routeDetailsActivity.PutExtra("SMART_ID", favorites[e.Position].StationId);
            StartActivity(routeDetailsActivity);
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
        }

        
    }
}

