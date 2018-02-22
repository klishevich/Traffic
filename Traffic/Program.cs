using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            var route = new Route(10, 18);
            var stations = string.Join(",", route.stations.ToArray());
            Console.Write("aBeginTime = {0}\n" +
                "aEndTime = {1}\n" +
                "busInterval = {2} hours\n" +
                "betweenStationInterval = {3} hours\n" +
                "stations = {4}\n",
                route.aBeginTime, route.aEndTime, route.busInterval, route.betweenStationInterval, stations);

            Console.Write("\nEnter current time in hours\n");
            var time = Console.ReadLine();
            double currentTime = Convert.ToDouble(time);

            Console.Write("\nEnter station name (Station3)\n");
            var station = Console.ReadLine();

            var res = route.GetNearestBusTime(currentTime, station);
            Console.Write(res);

            Console.ReadLine();
        }
    }
}
