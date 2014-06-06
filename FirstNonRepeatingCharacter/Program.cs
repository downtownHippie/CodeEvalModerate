using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FirstNonRepeatingCharacter
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
                    List<char> word = line.ToCharArray().ToList();
                    List<char> group = new List<char>();
                    for (int i = 0; i < word.Count; i++)
                    {
                        char element = word.ElementAt(i);
                        int index = word.FindIndex(i + 1, x => x == element);
                        if ((index == -1) && !group.Contains(element))
                        {
                            Console.WriteLine(element);
                            break;
                        }
                        else
                            group.Add(element);
                    }
                }
            //Console.ReadLine();
        }
    }
}
