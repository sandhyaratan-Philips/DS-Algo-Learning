using System;

namespace _1700._Number_of_Students_Unable_to_Eat_Lunch
{
    //Input: students = [1,1,0,0], sandwiches = [0,1,0,1]
    //Output: 0 
    //Explanation:
    //- Front student leaves the top sandwich and returns to the end of the line making students = [1, 0, 0, 1].
    //- Front student leaves the top sandwich and returns to the end of the line making students = [0,0,1,1].
    //- Front student takes the top sandwich and leaves the line making students = [0, 1, 1] and sandwiches = [1, 0, 1].
    //  - Front student leaves the top sandwich and returns to the end of the line making students = [1,1,0].
    //- Front student takes the top sandwich and leaves the line making students = [1, 0] and sandwiches = [0, 1].
    // - Front student leaves the top sandwich and returns to the end of the line making students = [0,1].
    //- Front student takes the top sandwich and leaves the line making students = [1] and sandwiches = [1].
    //- Front student takes the top sandwich and leaves the line making students = []
    //    and sandwiches = [].
    //Hence all students are able to eat.
    class Program
    {
        public int CountStudents(int[] students, int[] sandwiches)
        {

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
