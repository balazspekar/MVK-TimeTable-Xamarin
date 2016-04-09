using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace TimeTable.SharedProject
{
    /// <summary>
    /// This is a bundle class and it's purpose is just encapsulating data that can be used in a queue later.
    /// </summary>
    class Departure
    {
        public string RouteName { get; }
        public string RouteDescription { get; } 
        public DateTime DepartureTime { get; }
        public int SecondsUntilDepartureTime { get; }

        public Departure(string routeName, string routeDescription, DateTime departureTime, int secondsUntilDepartureTime)
        {
            this.RouteName = routeName;
            this.RouteDescription = routeDescription;
            this.DepartureTime = departureTime;
            this.SecondsUntilDepartureTime = secondsUntilDepartureTime;
        }
    }
}
