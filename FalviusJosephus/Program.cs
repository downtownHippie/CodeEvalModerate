using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FalviusJosephus
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
                    string[] splits = line.Split(',');
                    int people = Convert.ToInt32(splits[0]);
                    int j = Convert.ToInt32(splits[1]);
                    int[] dead = new int[people];
                    int number = -1;
                    int count = 0;
                    while (count < people)
                    {

                        Console.Write(number = whichKill(number, j, dead));
                        count++;
                        if (count < (people))
                            Console.Write(" ");
                    }
                    Console.WriteLine();
                }
            //Console.ReadLine();
        }

        private static int whichKill(int number, int j, int[] dead)
        {
            if (number == -1)
            {
                number += j;
                dead[number] = 1;
                return number;
            }
            int count = 0;
            int index = number;
            while (count < j)
            {
                index++;
                index %= dead.Length;
                if (dead[index] == 0)
                    count++;
            }
            dead[index] = 1;
            return index;
        }
    }
}
