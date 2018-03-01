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
            var stations = new List<string> { "Station1", "Station2", "Station3", "Station4" };

            // Create object, just need it once, to serialize into route.xml
            var routeFromClass = new Route { aBeginTime = 10, aEndTime = 18, bBeginTime = 10, bEndTime = 18, betweenStationInterval = 0.5, busInterval = 1, stations = stations };
            // Serialize object to xml
            Serializer.WriteToXmlFile(@"C:\temp\route.xml", routeFromClass);
            // Create object from file
            var routeFromFile = Serializer.ReadFromXmlFile<Route>(@"C:\temp\route.xml");

            var stationsPrint = string.Join(",", stations);
            Console.Write("aBeginTime = {0}\n" +
                "aEndTime = {1}\n" +
                "busInterval = {2} hours\n" +
                "betweenStationInterval = {3} hours\n" +
                "stations = {4}\n",
                routeFromFile.aBeginTime, routeFromFile.aEndTime, routeFromFile.busInterval, routeFromFile.betweenStationInterval, stationsPrint);

            Console.Write("\nEnter current time in hours\n");
            var time = Console.ReadLine();
            double currentTime = Convert.ToDouble(time);

            Console.Write("\nEnter station name (Station3)\n");
            var station = Console.ReadLine();

            var res = routeFromFile.GetNearestBusTime(currentTime, station);
            Console.Write(res);

            Console.ReadLine();
        }
    }
}
