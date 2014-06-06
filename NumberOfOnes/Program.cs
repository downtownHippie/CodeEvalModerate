using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NumberOfOnes
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
                    int number = Convert.ToInt32(line);
                    string binary = Convert.ToString(number, 2);
                    int count = 0;
                    for (int i = 0; i < binary.Length; i++)
                    {
                        if (binary[i] == '1')
                            count++;
                    }
                    Console.WriteLine(count);
                }
            //Console.ReadLine();
        }
    }
}
