using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ArrayAbsurdity
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
                    int n = Convert.ToInt32(splits[0]);
                    string[] numbersS = splits[1].Split(',');
                    List<int> list = new List<int>();
                    for (int i = 0; i < n; i++)
                    {
                        int k = Convert.ToInt32(numbersS[i]);
                        if (list.Contains(k))
                        {
                            Console.WriteLine(k);
                            break;
                        }
                        else
                            list.Add(k);
                    }
                }
            //Console.ReadLine();
        }
    }
}
