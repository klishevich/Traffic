using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic
{
    /*class Station
	{
        public int Id { get; set; }
        public string Name { get; set; }
        //public int StationInterval { get; set; }

        public Station(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Station()
        {

        }
	}*/    
    class Route
    {
        /// <summary>
        /// Route has start point A and end point B.
        /// All time in hours
        /// </summary>
        public int Id {get; set;}
        public string Name { get; set; }
        public int ABeginTime {get; set;}//int fromfile 5:00 => 300, from file
        public int AEndTime {get; set;}//int from file 24:00 => 1439, from file
        public int BBeginTime {get; set;}
        public int BEndTime {get; set;}
        //public int bBeginTime;//int from file 
        //public int bEndTime;//int from file 
        public int BusInterval{get; set;}//int from file = 10
        public List<string> Stations { get; set; }
        public int[] StationInterval { get; set; }
        //public List<string> stations;
        //public int betweenStationInterval;// int in file = 5, from file according to Station Index from 0 (to number of station +1)*/

        public Route(int id, string name, int aBeginTime, int aEndTime, int busInterval, List<string> stations, int[] stationInterval)
        {
            Id=id;
            Name = name;
            ABeginTime = aBeginTime;
            AEndTime = aEndTime;
            //this.bBeginTime = aBeginTime;
            //this.bEndTime = aEndTime;
            BusInterval = busInterval; //10 minutes, from file 
            Stations = stations;
            //{ "Station1", "Station2", "Station3", "Station4" };//from class Station
            StationInterval = stationInterval;// 5 minutes, from file
        }
        
        public Route()
        {

        }


        /*public Station GetStationByName(Route routes, string givenStationName)
        {
            Station ourStation;
            foreach (var route in routes)
                foreach (var station in stations)
                    if (givenStationName==route.station.Name)
                    {
                        ourStation = this.route.station;
                    }
            else return "Do not understand you!";
        }*/

        public string GetNearestBusTime(string station)
        {
            int stationIndex = Stations.IndexOf(station);
            int timeFromPointA = 0;
            int timeFromPointB = 0;
            int indexOfLastStation = Stations.Count-1;
            
            //if (stationIndex<0) return ;
                    
            //int stationIndex = stations.IndexOf(station);//getting by index, will be changed!!! instead srations.IndexOf put stations.Id
            //int timeFromPoint = stationIndex * betweenStationInterval;//both parametrs should be in file; interval between stations will be random
           
            for (int i = 0; i < stationIndex; i++)
			{
                timeFromPointA +=StationInterval[i];
			}

            for (int i = indexOfLastStation; i > stationIndex; i--)
			{
                timeFromPointB +=StationInterval[indexOfLastStation-1];
			}
            GetNearestTime(AbeginTime, AendTime, timeFromPointA, indexOfLastStation);
            GetNearestTime(BbeginTime, BendTime, timeFromPointB, Stations[0]);
        }

        public string GetNearestTime(int beginTime, int endTime, int timeFromPoint, string indexOfLastStation) //в процессе
        {
            DateTime currentTimeInDateTime = DateTime.Now;
            int currenTime = currentTimeInDateTime.Hour*60 + currentTimeInDateTime.Minute;

            int time = beginTime;
            while (time <= endTime)
            {
                int stationTime = time + timeFromPoint;

                if (stationTime >= currenTime)
                {
                    int timeNeedToWait = stationTime - currenTime;
                    return "Nearest bus to Station "+ indexOfLastStation+ " will be in - " + timeNeedToWait.ToString() + " minutes";
                }
                time += BusInterval;
            }
            return "No buses for today";
           }
        }
        
    }
