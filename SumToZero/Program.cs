using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SumToZero
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
                    //string[] numbersS = line.Split(',');
                    int[] numbers = Array.ConvertAll(line.Split(','), element => Convert.ToInt32(element));
                    int zeros = 0;
                    for (int a = 0; a < numbers.Length - 3; a++)
                    {
                        for (int b = 1; b < numbers.Length - 2; b++)
                        {
                            for (int c = 2; c < numbers.Length - 1; c++)
                            {
                                for (int d = 3; d < numbers.Length; d++)
                                {
                                    // prevent use of repeating elements =
                                    // prevent duplicate (alternate order) sets >
                                    if (a >= b || b >= c || c >= d)
                                        continue;
                                    if (numbers[a] + numbers[b] + numbers[c] + numbers[d] == 0)
                                        zeros++;
                                }
                            }
                        }
                    }
                    Console.WriteLine(zeros);
                }
            //Console.ReadLine();
        }
    }
}
