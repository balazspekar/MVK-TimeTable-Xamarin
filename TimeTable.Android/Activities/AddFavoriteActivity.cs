using Android.App;
using Android.OS;
using Android.Widget;

namespace TimeTable.Droid
{
    [Activity(Label = "Megálló Hozzáadása")]
    public class AddFavoriteActivity : Activity
    {
        EditText editStationIdentifier;
        EditText editStationNick;
        Button btnAddNewFavStation;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ScreenAddFavorite);
        }
       
    }
}