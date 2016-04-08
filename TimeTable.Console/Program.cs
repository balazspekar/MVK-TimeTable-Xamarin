using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.SharedBusinessLogic;

namespace TimeTable.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Station station = new Station(513);
            System.Console.WriteLine(station.StationID);
        }
    }
}
