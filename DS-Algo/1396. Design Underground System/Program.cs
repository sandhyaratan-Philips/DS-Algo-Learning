using System;
using System.Collections.Generic;

namespace _1396._Design_Underground_System
{
    public class station
    {
        public int totalTime { get; set; }
        public int count { get; set; }
        public station(int totalTime, int count)
        {
            this.totalTime = totalTime;
            this.count = count;
        }
    }
    class Program
    {
        Dictionary<int, KeyValuePair<string, int>> passangerCheckedIn;
        Dictionary<string, station> passangerCheckedOut;
        public Program()
        {
            passangerCheckedIn = new Dictionary<int, KeyValuePair<string, int>>();
            passangerCheckedOut = new Dictionary<string, station>();
        }

        public void CheckIn(int id, string stationName, int t)
        {
            passangerCheckedIn.Add(id, new KeyValuePair<string, int>(stationName, t));
        }

        public void CheckOut(int id, string stationName, int t)
        {
            string entryStation = passangerCheckedIn[id].Key;
            int entryStationTime = passangerCheckedIn[id].Value;

            string route = entryStation + "_" + stationName;

            int totalTime = t - entryStationTime;

            if (passangerCheckedOut.ContainsKey(route))
            {
                passangerCheckedOut[route].totalTime += totalTime;
                passangerCheckedOut[route].count++;
            }
            else
            {
                passangerCheckedOut.Add(route, new station(totalTime, 1));
            }

            passangerCheckedIn.Remove(id);
        }

        public double GetAverageTime(string startStation, string endStation)
        {
            string route = startStation + "_" + endStation;
            return passangerCheckedOut[route].totalTime / passangerCheckedOut[route].count;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
