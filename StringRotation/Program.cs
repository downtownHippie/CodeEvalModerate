using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StringRotation
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
                    string A = splits[0];
                    string B = splits[1];
                    if (A.Length != B.Length)
                    {
                        Console.WriteLine("False: strings different lengths");
                        continue;
                    }
                    if (A == B)
                    {
                        Console.WriteLine("True: strings are same");
                        continue;
                    }
                    // brute force
                    int i = 0;
                    while (i < A.Length)
                    {
                        string sub = A.Substring(0, 1);
                        A = A.Remove(0, 1);
                        A = A + sub;
                        if (A == B)
                        {
                            Console.WriteLine("True");
                            break;
                        }
                        i++;
                    }
                    if (i == A.Length)
                        Console.WriteLine("False");
                }
            //Console.ReadLine();
        }
    }
}
