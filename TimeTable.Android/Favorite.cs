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

namespace TimeTable.Droid
{
    class Favorite
    {
        private string stationNickName;
        private string stationId;

        public string StationNickName
        {
            get { return stationNickName; }
            set { stationNickName = value; }
        }

        public string StationId
        {
            get { return stationId; }
            set { stationId = value; }
        }

    }
}