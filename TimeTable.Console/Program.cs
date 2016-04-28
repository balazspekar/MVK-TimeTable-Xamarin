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
            Station station = new Station("513");

            var schedules = station.Schedules;

            foreach (var shcedule in schedules)
            {
                System.Console.WriteLine(shcedule.ToString());
            }

            System.Console.WriteLine(DateTime.Now);
            

        }
    }
}
