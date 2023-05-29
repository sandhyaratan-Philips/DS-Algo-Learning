using System;

namespace _1603._Design_Parking_System
{
    class Program
    {
        int _big, _medium, _small;

        public Program(int big, int medium, int small)
        {
            this._big = big;
            this._medium = medium;
            this._small = small;
        }

        public bool AddCar(int carType)
        {
            switch (carType)
            {
                case 1:
                    if (_big > 0)
                    {
                        _big--;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 2:
                    if (_medium > 0)
                    {
                        _medium--;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 3:
                    if (_small > 0)
                    {
                        _small--;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
            }
            return false;
        }
        //Input
        //["ParkingSystem", "addCar", "addCar", "addCar", "addCar"]
        //[[1, 1, 0], [1], [2], [3], [1]]
        //Output
        //[null, true, true, false, false]
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
