using System.Collections.Generic;
using TimeTable.SharedProject;

namespace TimeTable.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Station tramStation = new Station("513");
            
            Queue<Departure> schedules = new Queue<Departure>();

            schedules = tramStation.Schedules;

            foreach (var departure in schedules)
            {
                System.Console.WriteLine(departure.RouteName + "|" + 
                    departure.RouteDescription + "|" + departure.DepartureTime.ToString() + "|" + departure.SecondsUntilDepartureTime / 60);
            }

        }
    }
}
