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
            //добавить считование файла
            
            do
	        {
            Console.Clear();
            var route = new Route(300, 1439);
            var stations = string.Join(",", route.stations.ToArray());
            Console.Write("aBeginTime = {0}\n minutes" +
                "aEndTime = {1}\n minutes" +
                "busInterval = {2} minutes\n" +
                "betweenStationInterval = {3} minutes\n" +
                "stations = {4}\n",
                route.aBeginTime, route.aEndTime, route.busInterval, route.betweenStationInterval, stations);

            /*Console.Write("\nEnter current time in hours\n");//nowTime
            var time = Console.ReadLine();
            double currentTime = Convert.ToDouble(time);*/
            DateTime today = DateTime.Now;
            Console.WriteLine("Current time: {0:t}", today);//timeOfDay

            Console.Write("\nEnter station name (Station3)\n");
            var station = Console.ReadLine();

            var res = route.GetNearestBusTime(station);//time = currentTime
            Console.WriteLine(res);
            Console.WriteLine("Для повтора нажмите Enter");
            } while (Console.ReadKey().Key==ConsoleKey.Enter);
        }
    }
}
