using System;

namespace Homework4PalindromeArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = { 1, 2, 3, 2, 5 };

            bool isNumberPrime = true;
            for (int i = 0; i < number.Length / 2; i++)
            {
                if (number[i] != number[number.Length - 1 - i])
                {
                    isNumberPrime = false;
                    break;
                }
            }
            if (isNumberPrime)
            {
                Console.WriteLine("The number is a palindrome!");
            }
            else
            {
                Console.WriteLine("The number is not a palindrome!");
            }
        }
    }
}
