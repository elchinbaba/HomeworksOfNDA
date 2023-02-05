using System;

namespace Homework1WhileLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            int bigNumber = 15;
            int smallNumber = 0;

            while (smallNumber < bigNumber)
            {
                Console.WriteLine("Number is {0}", smallNumber);

                smallNumber++;
            }
        }
    }
}
