using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BatsChallenge
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
                    //Console.WriteLine(line);
                    string[] splits = line.Split(' ');
                    int l = Convert.ToInt32(splits[0]);
                    int d = Convert.ToInt32(splits[1]);
                    int n = Convert.ToInt32(splits[2]);
                    MyList bats = new MyList(); ;
                    if (n > 0)
                        for (int i = 3; i < n + 3; i++)
                            bats.Add(Convert.ToInt32(splits[i]));
                    // since I start from low point on wire and count up sort is irrelevant
                    //bats.Sort();
                    int count = 0;
                    for (int index = 6; index <= l - 6; index += d)
                        if (!bats.ContainsInRange(ref index, d))
                        {
                            //Console.Write("{0} ", index);
                            count++;
                        }
                    Console.WriteLine(count);
                }
            Console.ReadLine();
        }
    }

    public class MyList : List<int>
    {
        public bool ContainsInRange(ref int index, int range)
        {
            // bats are zero width, so go from index to index + range - 1
            for (int i = index; i <= index + range - 1; i++)
            {
                if (this.Contains(i))
                {
                    index = i;
                    return true;
                }
            }
            return false;
        }
    }
}
