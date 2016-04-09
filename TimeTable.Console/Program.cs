using System;
using System.Text;
using System.Collections.Generic;
using TimeTable.SharedProject;

namespace TimeTable.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Station tramStation513 = new Station("513");
            Station tramStation514 = new Station("514");
            
            Queue<Departure> schedules513 = new Queue<Departure>();
            Queue<Departure> schedules514 = new Queue<Departure>();


            while (true)
            {
                foreach (var departure in schedules513)
                {
                    System.Console.WriteLine(departure.RouteName + "|" +
                                             departure.RouteDescription + "|" + departure.DepartureTime.ToString() + "|" +
                                             departure.SecondsUntilDepartureTime/ 60 + "|" + departure.SecondsUntilDepartureTime);
                }
                schedules513 = tramStation513.Schedules;

                System.Console.WriteLine();

                foreach (var departure in schedules514)
                {
                    System.Console.WriteLine(departure.RouteName + "|" +
                                             departure.RouteDescription + "|" + departure.DepartureTime.ToString() + "|" +
                                             departure.SecondsUntilDepartureTime / 60 + "|" + departure.SecondsUntilDepartureTime);
                }
                schedules514 = tramStation514.Schedules;


                System.Threading.Thread.Sleep(3000);
                System.Console.Clear();
            }

        }
    }
}
