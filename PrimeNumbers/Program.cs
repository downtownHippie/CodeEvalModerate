using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    //Console.WriteLine(line);
                    if (string.IsNullOrEmpty(line))
                        continue;
                    Int64 n = Convert.ToInt64(line);
                    if (n == 2)
                        Console.Write("2");
                    //else if (n == 3)
                    //    Console.Write("2,3");
                    else
                        Console.Write("2,3");
                    for (Int64 i = 5; i <= n; i++)
                    {
                        if (isPrime(i))
                            Console.Write(",{0}", i);
                    }
                    Console.WriteLine();
                }
            //Console.ReadLine();
        }

        private static bool isPrime(Int64 number)
        {
            if (number == 2 || number == 3)
                return true;
            if ((number % 2 == 0) || (number % 3 == 0))
                return false;
            Int64 i = 5;
            Int64 w = 2;
            while (i * i <= number)
            {
                if (number % i == 0)
                    return false;
                i += w;
                w = 6 - w;
            }
            return true;
        }
    }
}
