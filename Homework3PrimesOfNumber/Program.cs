using System;
using System.IO;

namespace Homework3PrimesOfNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream filestream = new FileStream("out.txt", FileMode.Create);
            var streamwriter = new StreamWriter(filestream);
            streamwriter.AutoFlush = true;
            Console.SetOut(streamwriter);
            Console.SetError(streamwriter);

            int number = 5354167;
            
            // counting the digits of the number
            int duplicateNumber = number;
            int lengthOfNumber = 0;
            while (duplicateNumber != 0)
            {
                lengthOfNumber++;
                duplicateNumber /= 10;
            }

            // filling the array in the reverse order with the digits of the number
            int[] digitsInNumber = new int[lengthOfNumber];
            duplicateNumber = number;
            int i = 0;
            while (i < lengthOfNumber)
            {
                digitsInNumber[lengthOfNumber - 1 - i] = duplicateNumber % 10;
                duplicateNumber /= 10;

                i++;
            }

            int countPrimes = 0;
            bool isCheckingNumberPrime;
            int limitForCheckingPrimeness;

            int lengthOfCheckingNumber = 1;
            int checkingNumber;
            int[] digitsInCheckingNumber;

            int j, k, index;
            bool isEnd;
            while (lengthOfCheckingNumber <= lengthOfNumber)
            {
                digitsInCheckingNumber = new int[lengthOfCheckingNumber];

                // initialization of the indices: 0, 01, 012...
                k = 0;
                while (k < lengthOfCheckingNumber)
                {
                    digitsInCheckingNumber[k] = k;
                    //Console.Write(digitsInCheckingNumber[k] + " ");
                    k++;
                }

                // calculating the numbers based on the first indices and checking primeness
                {
                    checkingNumber = 0;
                    i = 0;
                    while (i < lengthOfCheckingNumber)
                    {
                        checkingNumber += (int)Math.Pow(10, lengthOfCheckingNumber - i - 1) * digitsInNumber[digitsInCheckingNumber[i]];

                        i++;
                    }
                    //Console.WriteLine("\n");
                    //Console.WriteLine("checkingNumber {0}\n", checkingNumber);

                    isCheckingNumberPrime = true;
                    limitForCheckingPrimeness = (int)Math.Ceiling(Math.Sqrt(checkingNumber));
                    j = 2;
                    while (j <= limitForCheckingPrimeness)
                    {
                        if (checkingNumber % j == 0)
                        {
                            isCheckingNumberPrime = false;
                            break;
                        }

                        j++;
                    }

                    if (isCheckingNumberPrime)
                    {
                        countPrimes++;
                        //Console.WriteLine(checkingNumber);
                    }
                }

                isEnd = false;
                index = digitsInCheckingNumber[lengthOfCheckingNumber - 1];
                while (true)
                {
                    // updating the main index
                    while (true)
                    {
                        digitsInCheckingNumber[index]++;

                        if (!(digitsInCheckingNumber[index] < lengthOfNumber))
                        {
                            index--;

                            if (index == -1)
                            {
                                isEnd = true;
                                break;
                            }

                            continue;
                        }
                        else
                        {
                            k = 0;
                            while (k < index)
                            {
                                if (digitsInCheckingNumber[k] == digitsInCheckingNumber[index])
                                {
                                    break;
                                }

                                k++;
                            }
                        }

                        if (k == index)
                        {
                            break;
                        }
                    }

                    if (isEnd)
                    {
                        break;
                    }

                    // updating the next indices if necessary
                    index = index + 1;
                    while (true)
                    {
                        if (!(index < lengthOfCheckingNumber))
                        {
                            break;
                        }

                        digitsInCheckingNumber[index] = -1;
                        while (true)
                        {
                            digitsInCheckingNumber[index]++;

                            j = 0;
                            while (j < index)
                            {
                                if (digitsInCheckingNumber[j] == digitsInCheckingNumber[index])
                                {
                                    break;
                                }

                                j++;
                            }

                            if (j == index)
                            {
                                break;
                            }
                        }

                        index++;
                    }
                    index--;

                    for (int y = 0; y < lengthOfCheckingNumber; y++)
                    {
                        //Console.Write(digitsInCheckingNumber[y] + " ");
                    }
                    //Console.WriteLine("\n");

                    // calculation of the number based on the current indices
                    checkingNumber = 0;
                    i = 0;
                    while (i < lengthOfCheckingNumber)
                    {
                        checkingNumber += (int)Math.Pow(10, lengthOfCheckingNumber - i - 1) * digitsInNumber[digitsInCheckingNumber[i]];

                        i++;
                    }
                    //Console.WriteLine("checkingNumber {0}\n", checkingNumber);

                    isCheckingNumberPrime = true;
                    limitForCheckingPrimeness = (int)Math.Ceiling(Math.Sqrt(checkingNumber));
                    j = 2;
                    while (j <= limitForCheckingPrimeness)
                    {
                        if (checkingNumber % j == 0)
                        {
                            isCheckingNumberPrime = false;
                            break;
                        }

                        j++;
                    }

                    if (isCheckingNumberPrime)
                    {
                        countPrimes++;
                    }
                }

                lengthOfCheckingNumber++;
            }
        }
    }
}
