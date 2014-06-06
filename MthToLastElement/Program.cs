using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MthToLastElement
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
                    string[] theLine = line.Split(' ');
                    int mThElement = Convert.ToInt32(theLine[theLine.Length - 1]);
                    if (mThElement <= (theLine.Length - 1))
                        Console.WriteLine(theLine[theLine.Length - mThElement - 1]);
                }
            //Console.ReadLine();
        }
    }
}
