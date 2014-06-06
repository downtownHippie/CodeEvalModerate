using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SumOfIntegers
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
                    int[] numbers = new int[splits.Length];
                    for (int i = 0; i < splits.Length; i++)
                    {
                        numbers[i] = Convert.ToInt32(splits[i].Trim());
                    }
                    int sum = 0;
                    int largest = Int32.MinValue;
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (sum <= 0)
                            sum = numbers[i];
                        else
                            sum += numbers[i];
                        if (sum > largest)
                            largest = sum;
                    }
                    Console.WriteLine(largest);
                }
            //Console.ReadLine();
        }
    }
}
