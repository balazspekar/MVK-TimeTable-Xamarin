using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Shared;

namespace TimeTable.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Station station = new Station("513");
            while (true)
            {
                System.Console.Clear();
                station.Update();
                System.Console.WriteLine(station.RawData);
                System.Threading.Thread.Sleep(3000);
            }


        }
    }
}
