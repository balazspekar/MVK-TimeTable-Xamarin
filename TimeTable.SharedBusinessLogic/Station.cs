using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTable.SharedBusinessLogic
{
    public class Station
    {
        private readonly int stationID;

        public int StationID
        {
            get { return stationID; }
        }


        public Station(int stationID)
        {
            this.stationID = stationID;
        }

        

    }
}
