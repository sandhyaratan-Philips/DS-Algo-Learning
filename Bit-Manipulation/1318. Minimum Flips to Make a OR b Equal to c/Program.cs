using System;

namespace _1318._Minimum_Flips_to_Make_a_OR_b_Equal_to_c
{
    class Program
    {
        //right shift -> 1100 >>=1    -> 0110; 1100 >>=2    -> 0011
        //find if Kth bit is 1;
        // (1<<Value) & 1
        public int MinFlips(int a, int b, int c)
        {
            int res = 0;
            //approch 1

            //while (a != 0 || b != 0 || c != 0)
            //{
            //    if ((c & 1) == 1)//c & 1=> gives the rigth most bit
            //    {
            //        if ((a & 1) == 0 && (b & 1) == 0)
            //        {
            //            res++;
            //        }
            //    }
            //    else
            //    {
            //        res += (a & 1) + (b & 1);
            //    }

            //    //right shift
            //    a >>= 1;
            //    b >>= 1;
            //    c >>= 1;
            //}

            //approch 2

            int orA_B = a | b;
            int andA_B = a & b;
            int xor_With_C = orA_B ^ c;
            int extraFlip = xor_With_C & andA_B;
            while (xor_With_C > 0 || extraFlip > 0)
            {
                res += (xor_With_C & 1) + (extraFlip & 1); //count no. of 1's
                xor_With_C >>= 1;
                extraFlip >>= 1;
            }

            return res;
        }
        //Input: a = 4, b = 2, c = 7
        //Output: 1
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.MinFlips(4, 2, 7));
        }
    }
}
