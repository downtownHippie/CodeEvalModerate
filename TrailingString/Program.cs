using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TrailingString
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
                    if (splits[0].EndsWith(splits[1]))
                        Console.WriteLine(1);
                    else
                        Console.WriteLine(0);
                }
            //Console.ReadLine();
        }
    }
}
