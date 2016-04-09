using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTable.SharedProject
{
    class Station
    {
        // Fields and Properties
        private string smartId;
        private string handlerAddress = "http://owa.mvkzrt.hu:8080/android/handler.php";

        public Queue<DateTime> Schedules
        {
            get { return UpdateQueue(); }
        }

        // Constructor
        public Station(string smartId)
        {
            this.smartId = "SMART=" + smartId;
        }

        // Methods
        public Queue<DateTime> UpdateQueue()
        {
            Queue<DateTime> queue = new Queue<DateTime>();
            string rawDataFromServer = GetRawDataFromServer();
            string[] rawDataSplittedToStringArray = SplitRawDataToStringArray(rawDataFromServer);

            for (int i = 0; i < rawDataSplittedToStringArray.Length; i++)
            {
                try
                {
                    DateTime actualTime = DateTime.Parse(rawDataSplittedToStringArray[i]);
                    queue.Enqueue(actualTime);
                }
                catch (Exception)
                {
                    // nothing
                }
            }
            
            return queue;
        }

        private string GetRawDataFromServer()
        {
            return Client.FetchRawDataFromServer(handlerAddress, smartId);
        }

        public string[] SplitRawDataToStringArray(string rawData)
        {
            return rawData.Split('|');
        }


    }
}
