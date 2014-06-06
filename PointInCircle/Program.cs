using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PointInCircle
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
                    string[] splits = line.Split(new string[] { "; " }, StringSplitOptions.RemoveEmptyEntries);
                    string[] centerS = splits[0].Substring(line.IndexOf('(')).Split(new string[] { "(", ",", " ", ")" }, StringSplitOptions.RemoveEmptyEntries);
                    double radius = Convert.ToDouble(splits[1].Substring(splits[1].IndexOf(' ')));
                    string[] pointS = splits[2].Substring(line.IndexOf('(')).Split(new string[] { "(", ",", " ", ")" }, StringSplitOptions.RemoveEmptyEntries);
                    double distance = Math.Sqrt(Math.Pow((Convert.ToDouble(centerS[0]) - Convert.ToDouble(pointS[0])), 2) + Math.Pow((Convert.ToDouble(centerS[1]) - Convert.ToDouble(pointS[1])), 2));
                    if (distance <= radius)
                        Console.WriteLine("true");
                    else
                        Console.WriteLine("false");
                }
            //Console.ReadLine();
        }
    }
}
