using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic
{
    class Route
    {
        /// <summary>
        /// Route has start point A and end point B.
        /// All time in hours
        /// </summary>
        public int aBeginTime;//int fromfile 5:00 => 300
        public int aEndTime;//int from file 24:00 => 1439
        public int bBeginTime;//int from file 
        public int bEndTime;//int from file 
        public int busInterval;//int from file = 10
        public List<string> stations;
        public int betweenStationInterval;// int in file = 5
        public DateTime currentTimeInDateTime = DateTime.Now;

        public Route(int aBeginTime, int aEndTime)
        {
            this.aBeginTime = aBeginTime;
            this.aEndTime = aEndTime;
            this.bBeginTime = aBeginTime;
            this.bEndTime = aEndTime;
            this.busInterval = 120; //5
            this.stations = new List<string> { "Station1", "Station2", "Station3", "Station4" };//class Station
            this.betweenStationInterval = 5;// 10
        }

        public string GetNearestBusTime(string station)//получение текущего времени, когда придет ближайший автобус
        {
            int currenTime = currentTimeInDateTime.Hour*60 + currentTimeInDateTime.Minute;

            int stationIndex = stations.IndexOf(station);//getting by index
            int timeFromPointA = stationIndex * betweenStationInterval;//both parametrs should be in file; interval between stations will be random
            
            int time = aBeginTime;
            while (time <= aEndTime)
            {
                int stationTime = time + timeFromPointA;

                if (stationTime >= currenTime)
                {
                    int timeNeedToWait = stationTime - currenTime;
                    return "Nearest bus to Station 1 will be in - " + timeNeedToWait.ToString() + " minutes";
                }
                time += busInterval;
            }
            return "No buses for today";
        }
    }
}
