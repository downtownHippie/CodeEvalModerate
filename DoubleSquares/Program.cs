using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DoubleSquares
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
            {
                int quantity = Convert.ToInt32(reader.ReadLine()); // like it matters?
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                        continue;
                    int number = Convert.ToInt32(line);
                    int count = 0;
                    for (int i = 0; i < ((int)Math.Sqrt(number) + 1); i++)
                    {
                        if (perfectSquare(number - (i*i)))
                            count++;
                    }
                    if (count % 2 == 0)
                        count /= 2;
                    else
                        count = (count / 2) + 1;
                    Console.WriteLine(count);
                }
            }
            //Console.ReadLine();
        }

        static bool perfectSquare(int x)
        {
            int v = (int)Math.Sqrt(x);
            return ((v * v) == x);
        }
    }
}
