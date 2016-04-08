using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace TimeTable.PCL
{
    public class Station
    {
        
        // Backing Fields & Properties
        private string rawDataFromServer;
        public int StationId { get; }
        
        // Constructors
        public Station(int stationId)
        {
            StationId = stationId;
        }

        // Methods
        public void UpdateRawData()
        {
            WebRequest request = WebRequest.Create("http://www.contoso.com/");
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "POST";


        }

    }
}
