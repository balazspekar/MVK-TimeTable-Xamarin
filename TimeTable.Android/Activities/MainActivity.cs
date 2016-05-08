using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using TimeTable.Droid.ListViewAdapters;
using Android.Support.V7.App;
using Android.Support.V7.Widget;

namespace TimeTable.Droid
{
    [Activity(MainLauncher = true,  Theme = "@style/MyTheme")]

    public class MainActivity : ActionBarActivity
    {
        private ListView favoritesListView;
        private MainScreenListViewAdapter adapter;
        private List<Favorite> favorites;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            if (Helpers.StorageHandler.SettingsFileIsPresent())
            {
                var sampleList = new List<Favorite>();
                var sampleData = new Favorite { StationId = "89", StationNickName = "Centrum SAMPLE" };
                sampleList.Add(sampleData);
                Helpers.StorageHandler.Serialize(sampleList);
            }

            SetContentView(Resource.Layout.ScreenMain);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbarMain);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Megálló";
            favoritesListView = FindViewById<ListView>(Resource.Id.favoritesListView);

            favorites = Helpers.StorageHandler.Deserialize();
            adapter = new MainScreenListViewAdapter(this, favorites);
            favoritesListView.Adapter = adapter;
            favoritesListView.ItemClick += ListViewFavorites_ItemClick;
            favoritesListView.ItemLongClick += FavoritesListView_ItemLongClick;
        }

        protected override void OnResume()
        {
            base.OnResume();
            favorites = Helpers.StorageHandler.Deserialize();
            adapter = new MainScreenListViewAdapter(this, favorites);
            favoritesListView.Adapter = adapter;
        }

        private void FavoritesListView_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            var alert = new Android.Support.V7.App.AlertDialog.Builder(this);
            alert.SetTitle("Törlöd a megállót?");
            alert.SetPositiveButton("Törlöm", (senderAlert, args) => {
                favorites.Remove(favorites[e.Position]);
                Helpers.StorageHandler.Serialize(favorites);
                Toast.MakeText(this, "Megálló törölve", ToastLength.Short).Show();
                adapter = new MainScreenListViewAdapter(this, favorites);
                favoritesListView.Adapter = adapter;
            });

            alert.SetNegativeButton("Mégsem", (senderAlert, args) => {
                // do nothing
            });

            //run the alert in UI thread to display in the screen
            RunOnUiThread(() => {
                alert.Show();
            });
        }

        private void ListViewFavorites_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var routeDetailsActivity = new Intent(this, typeof(RouteDetailsActivity));
            routeDetailsActivity.PutExtra("SMART_ID", favorites[e.Position].StationId);
            routeDetailsActivity.PutExtra("STATION_NICK", favorites[e.Position].StationNickName);
            StartActivity(routeDetailsActivity);
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
        }

      

        #region ActionBarMenu
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.action_menu, menu);
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
    }
}

