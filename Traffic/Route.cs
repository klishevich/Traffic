using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic
{
    [Serializable]
    public class Route
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
