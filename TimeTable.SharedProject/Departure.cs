﻿using System;
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
        public string RouteName { get; set; }
        public string RouteDescription { get; set; } 
        public DateTime DepartureTime { get; set; }
        public int SecondsUntilDepartureTime { get; set; }

        public Departure()
        {

        }

        public Departure(string routeName, string routeDescription, DateTime departureTime, int secondsUntilDepartureTime)
        {
            this.RouteName = routeName;
            this.RouteDescription = routeDescription;
            this.DepartureTime = departureTime;
            this.SecondsUntilDepartureTime = secondsUntilDepartureTime;
        }

        public override string ToString()
        {
            return RouteName + ", " + RouteDescription + ", " + DepartureTime + ", " + SecondsUntilDepartureTime.ToString();
        }
    }
}
