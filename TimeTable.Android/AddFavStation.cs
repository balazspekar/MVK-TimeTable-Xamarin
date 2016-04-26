using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TimeTable.Droid
{
    [Activity(Label = "Megálló Hozzáadása")]
    public class AddFavStation : Activity
    {
        EditText editStationIdentifier;
        EditText editStationNick;
        Button btnAddNewFavStation;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddFavStation);

           

        }

       
    }
}