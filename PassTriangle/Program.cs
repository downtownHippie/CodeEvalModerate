using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PassTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int index = 0;
            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                        continue;
                    Console.WriteLine(line);
                    string[] numberS = line.Trim().Split(' ');
                    if (sum == 0)
                    {
                        sum = Convert.ToInt32(numberS[0]);
                        continue;
                    }
                    int[] numbers = new int[numberS.Length];
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] = Convert.ToInt32(numberS[i]);
                    }
                    int left = numbers[index];
                    int right = numbers[index + 1];
                    Console.WriteLine("S:{0} L:{1} R:{2} I:{3}", sum, left, right, index);
                    if (left > right)
                    {
                        Console.WriteLine("adding left");
                        sum += left;
                    }
                    else if (right > left)
                    {
                        Console.WriteLine("adding right");
                        sum += right;
                        index++;
                    }
                    else
                    {
                        Console.WriteLine("Fucking equal!");
                        break;
                    }
                }
            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}
