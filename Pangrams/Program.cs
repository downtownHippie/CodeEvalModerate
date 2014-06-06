using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Pangrams
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
                    char[] chars = line.ToLower().ToCharArray();
                    Dictionary<char, int> dict = new Dictionary<char, int>();
                    for (char i = 'a'; i <= 'z'; i++)
                    {
                        dict.Add(i, 0);
                    }
                    for (int i = 0; i < chars.Length; i++)
                    {
                        if ((chars[i] >= 'a') && (chars[i] <= 'z'))
                            dict[chars[i]]++;
                    }
                    bool some = false;
                    foreach (char item in dict.Keys)
                    {
                        if (dict[item] == 0)
                        {
                            Console.Write(item);
                            some = true;
                        }
                    }
                    if (!some)
                        Console.WriteLine("NULL");
                    else
                        Console.WriteLine();
                }
            //Console.ReadLine();
        }
    }
}
