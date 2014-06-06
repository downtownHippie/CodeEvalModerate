using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace MinistryOfTruth
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
                    line = Regex.Replace(line, @"\s+", " ");
                    Console.WriteLine(line);
                    string[] splits = line.Split(';');
                    string message = splits[0];
                    string utterance = splits[1];

                }
            Console.ReadLine();
        }
    }
}
