using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MinimumCoins
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
                    //Console.WriteLine(line);
                    int number = Convert.ToInt32(line);
                    int coins = 0;
                    while (number >= 5)
                    {
                        number -= 5;
                        coins++;
                    }
                    while (number >= 3)
                    {
                        number -= 3;
                        coins++;
                    }
                    while (number > 0)
                    {
                        number--;
                        coins++;
                    }
                    Console.WriteLine(coins);
                }
            Console.ReadLine();
        }
    }
}
