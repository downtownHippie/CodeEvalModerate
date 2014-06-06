using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NumberPairs
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
                    string[] splits = line.Split(';');
                    int sum = Convert.ToInt32(splits[1]);
                    string[] chars = splits[0].Split(',');
                    int[] numbers = new int[chars.Length];
                    for (int i = 0; i < chars.Length; i++)
                        numbers[i] = Convert.ToInt32(chars[i]);
                    bool some = false;
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        for (int k = i + 1; k < numbers.Length; k++)
                        {
                            if (numbers[i] + numbers[k] == sum)
                            {
                                if (some)
                                    Console.Write(";");
                                Console.Write("{0},{1}", numbers[i], numbers[k]);
                                some = true;
                            }
                        } 
                    }
                    if (!some)
                        Console.Write("NULL");
                    Console.WriteLine();
                }
            //Console.ReadLine();
        }
    }
}
