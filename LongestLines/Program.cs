using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LongestLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
            {
                int quantity = Convert.ToInt32(reader.ReadLine());
                Dictionary<string, int> dict = new Dictionary<string, int>();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                        continue;
                    dict.Add(line, line.Length);
                }
                var sorted = from pair in dict
                             orderby pair.Value descending
                             select pair;
                for (int i = 0; i < quantity; i++)
                {
                    Console.WriteLine(sorted.ElementAt(i).Key);
                }
            }
            //Console.ReadLine();
        }
    }
}
