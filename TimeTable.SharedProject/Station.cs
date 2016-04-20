using System;
using System.Collections.Generic;
using System.Text;
using TimeTable.SharedProject;

namespace TimeTable.SharedProject
{
    /// <summary>
    /// This class is representing an MVK Miskolc tram/bus station and provides departure information based on a special station ID.
    /// The constructor takes a so-called "SMART ID" which is advertised as "SMS code" in the stations for passengers.
    /// To get the soon-to-departuring lines (aka vehicles) data for an exact location you must provide the "SMART ID" first.
    /// You can get the following: 
    ///   - Route/Line Name (string)
    ///   - Route/Line Description (string)
    ///   - Departure Time (DateTime)
    ///   - Time in seconds until Departure Time based on DateTime.now (int)
    /// Instantiate an obect from this class and call the "Schedules" property whenever you want to get access to the latest schedule.
    /// This will return a Queue with a bundle, "Departure" objects.
    /// </summary>
    class Station
    {
        // Fields and Properties
        private readonly string _smartId;
        private const string HandlerAddress = "http://owa.mvkzrt.hu:8080/android/handler.php";
        public List<Departure> Schedules => UpdateSchedulesList();

        // Constructor
        public Station(string smartId)
        {
            this._smartId = "SMART=" + smartId;
        }

        // Methods
        private List<Departure> UpdateSchedulesList()
        {
            var result = new List<Departure>();
            var lines = GetLines();

            foreach (var line in lines)
            {
                // take a line of data and split it with a delimiter
                var actualLineSplitted = line.Split('|');

                // extract the valuable data to variables
                var actualRouteName = actualLineSplitted[0];
                var actualRouteDescription = actualLineSplitted[1].Trim();
                var actualDepartureTime = DateTime.Parse(actualLineSplitted[2]);
                var actualSecondsUntilDepartureTime = (int)((actualDepartureTime - DateTime.Now).TotalSeconds);

                // creating a bundle Departure object and enqueing it
                var departure = new Departure(actualRouteName, actualRouteDescription, actualDepartureTime, actualSecondsUntilDepartureTime);
                result.Add(departure);
            }
            
            return result;
        }

        private string[] GetLines()
        {
            var unformattedData = PullDataFromServer();
            var lines = SplitUnformattedDataByNewLine(unformattedData);
            return lines;
        }

        private string[] SplitUnformattedDataByNewLine(string rawData)
        {
            return rawData.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        }

        private string PullDataFromServer()
        {
            var rawData = Client.FetchRawDataFromServer(HandlerAddress, _smartId);
            return rawData;
        }
    }
}
