using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RemoveCharacters
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
                    List<char> input = splits[0].ToCharArray().ToList();
                    char[] removeThese = splits[1].Trim().ToCharArray();
                    for (int i = 0; i < removeThese.Length; i++)
                    {
                        while (input.Remove(removeThese[i])) ;
                    }
                    Console.WriteLine(new string(input.ToArray()).Trim());
                }
            //Console.ReadLine();
        }
    }
}
