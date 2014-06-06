using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CountingPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                        continue;
                    string[] splits = line.Split(',');
                    int min = Convert.ToInt32(splits[0]);
                    int max = Convert.ToInt32(splits[1]);
                    int count = 0;
                    for (int i = min; i <= max; i++)
                    {
                        if (isPrime(i))
                            count++;
                    }
                    Console.WriteLine(count);
                }
            //Console.ReadLine();
        }

        private static bool isPrime(int number)
        {
            if (number == 2 || number == 3)
                return true;
            if ((number % 2 == 0) || (number % 3 == 0))
                return false;
            int i = 5;
            int w = 2;
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
