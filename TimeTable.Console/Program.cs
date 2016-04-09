using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TimeTable.SharedProject;

namespace TimeTable.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Station tramStation = new Station("514");
            Queue<DateTime> schedules = new Queue<DateTime>();
            schedules = tramStation.Schedules;

            while (true)
            {
                foreach (var schedule in schedules)
                {
                    System.Console.WriteLine(schedule.ToString());
                }
                System.Threading.Thread.Sleep(3000);
                System.Console.Clear();
            }


        }
    }
}
