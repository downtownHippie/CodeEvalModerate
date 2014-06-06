using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PileOfBricks
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
                    Console.WriteLine(line);
                }
            Console.ReadLine();
        }
    }
}
