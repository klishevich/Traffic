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
        public double aBeginTime;
        public double aEndTime;
        public double bBeginTime;
        public double bEndTime;
        public double busInterval;
        public List<string> stations;
        public double betweenStationInterval;

        public Route(double aBeginTime, double aEndTime)
        {
            this.aBeginTime = aBeginTime;
            this.aEndTime = aEndTime;
            this.bBeginTime = aBeginTime;
            this.bEndTime = aEndTime;
            this.busInterval = 1;
            this.stations = new List<string> { "Station1", "Station2", "Station3", "Station4" };
            this.betweenStationInterval = 0.5;
        }

        public string GetNearestBusTime(double currenTime, string station)
        {
            var stationIndex = stations.IndexOf(station);
            var timeFromPointA = stationIndex * betweenStationInterval;
            var time = aBeginTime;
            while (time <= aEndTime)
            {
                var stationTime = time + timeFromPointA;
                if (stationTime >= currenTime)
                {
                    return "Nearest bus time - " + stationTime.ToString() + " hours";
                }
                time += busInterval;
            }
            return "No buses for today";
        }
    }
}
