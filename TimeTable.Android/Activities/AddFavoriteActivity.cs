using Android.App;
using Android.OS;
using Android.Widget;
using System.Collections.Generic;

namespace TimeTable.Droid
{
    [Activity(Label = "Megálló Hozzáadása")]
    public class AddFavoriteActivity : Activity
    {
        private EditText editStationIdentifier;
        private EditText editStationNick;
        private Button btnAddNewFavStation;
        private List<Favorite> favorites;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ScreenAddFavorite);

            favorites = Helpers.StorageHandler.Deserialize();

            editStationIdentifier = FindViewById<EditText>(Resource.Id.editStationIdentifier);
            editStationNick = FindViewById<EditText>(Resource.Id.editStationNick);
            btnAddNewFavStation = FindViewById<Button>(Resource.Id.btnAddNewFavStation);

            btnAddNewFavStation.Click += BtnAddNewFavStation_Click;
            


        }

        private void BtnAddNewFavStation_Click(object sender, System.EventArgs e)
        {
            var newFavorite = new Favorite();
            newFavorite.StationId = editStationIdentifier.Text;
            newFavorite.StationNickName = editStationNick.Text;
            favorites.Add(newFavorite);
            Helpers.StorageHandler.Serialize(favorites);
            Toast.MakeText(this, "Új megálló hozzáadva", ToastLength.Short).Show();
            Finish();
        }
    }
}