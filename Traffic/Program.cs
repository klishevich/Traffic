using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Traffic
{
    class Program
    {
        const string FileName = "../../Traffic.txt";

        /*static void SaveRoute(Route route, StreamWriter sw) 
        {
            sw.WriteLine($"{route.Id};{route.Name};{route.ABeginTime}; {route.AEndTime};{route.BusInterval};");

}*/

        static Route ReadRoute(StreamReader sr) 
        {
            var line = sr.ReadLine();
            var parts = line.Split(';');

            var route = new Route 
            {
                Id = int.Parse(parts[0]),
                Name = parts[1],
                ABeginTime = int.Parse(parts[2]),
                AEndTime = int.Parse(parts[3]),
                BusInterval = int.Parse(parts[4]),
                //StationInterval = new int[10].parts[5],
                //Stations = new List<string>.parts[6],
            };
            return route;
        }

       /* static void SaveData(List<Route> routes) {
            using (var sw = new StreamWriter(FileName)) {
            sw.WriteLine(routes.Count);
                foreach (var route in routes)
                    SaveRoute(route, sw);
            }
        }
        */
        static List<Route> ReadData() {
            var routesFromFile = new List<Route>();
            using (var sr = new StreamReader(FileName)) {
                while (!sr.EndOfStream) {
                    var routeFromFile = ReadRoute(sr);
                    routesFromFile.Add(routeFromFile);
                }
            }
            return routesFromFile;
        }

        static void Main(string[] args)
        {      

           
            List<Route> routes = new List<Route>()
                {
                    new Route
                    {
                        Id = 0,
                        Name = "Route 372",
                        ABeginTime = 300,
                        AEndTime = 1439,
                        BusInterval = 10,
                        BBeginTime = 301,
                        BEndTime = 1431,
                        StationInterval = new int[] {3,5,4},
                        Stations = new List<string> {"A","B","C","D"}

                        /*Stations = new List<Station>()
                        {
                            new Station
                            {
                                Id = 0,
                                Name = "A",
                            },
                            new Station
                            {
                                Id = 1,
                                Name = "B",
                            },
                            new Station
                            {
                                Id = 2,
                                Name = "C",
                            },
                            new Station
                            {
                                Id = 3,
                                Name = "D",
                            }
                        }*/
                    },
                    new Route
                    {
                        Id = 1,
                        Name = "Route 103",
                        ABeginTime = 305,
                        AEndTime = 1430,
                        BBeginTime = 302,
                        BEndTime = 1432,
                        BusInterval = 5,
                        StationInterval = new int[] {6,5,3,2},
                        Stations = new List<string> {"Q","W","Z","X","A"}
                    }
                }; 
            
            /*List<Route> routes;
                try {
                routes = ReadData();
            }
            catch {
                Console.WriteLine("Error reading file data");
                return;
            }
            Console.WriteLine(routes);
            Console.ReadLine();
                //SaveData(routes);*/
              /*  List<Route> routes = new List<Route>;
                ReadData();*/

            //добавить считование файла
            
           do
	        {
            Console.Clear();
            //var route = new Route(300, 1439);
                /*var stations = string.Join(",", route.stations.ToArray());
               Console.Write("aBeginTime = {0}\n minutes" +
                "aEndTime = {1}\n minutes" +
                "busInterval = {2} minutes\n" +
                "betweenStationInterval = {3} minutes\n" +
                "stations = {4}\n",
                routes[0].ABeginTime, routes[0].AEndTime, routes[0].BusInterval, routes[0].StationInterval, routes[0].Stations);*/

                /*Console.Write("\nEnter current time in hours\n");//nowTime
                var time = Console.ReadLine();
                double currentTime = Convert.ToDouble(time);*/
                
                DateTime today = DateTime.Now;
                Console.WriteLine("Current time: {0:t}", today);//timeOfDay

                Console.Write("\nEnter station name (A, Z): \n");
                var station = Console.ReadLine();

                for (int i = 0; i< routes.Count; i++) 
                {
                    if (routes[i].Stations.IndexOf(station)>=0) //if station exists in this route
                        {
                        var res = routes[i].GetNearestBusTime(station);
                        Console.WriteLine(res);
                    }
                }

                Console.WriteLine("Для повтора нажмите Enter");
                } while (Console.ReadKey().Key==ConsoleKey.Enter);
            
        }
    }
}
