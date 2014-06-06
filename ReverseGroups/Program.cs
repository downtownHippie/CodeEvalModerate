using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ReverseGroups
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
                    string[] splits = line.Split(';');
                    int k = Convert.ToInt32(splits[1]);
                    string[] numbersS = splits[0].Split(',');
                    int i = 0;
                    while (i <= numbersS.Length)
                    {
                        // if k + i is greater or equal to lenght of array stop processing
                        if ((k + i) > numbersS.Length)
                            break;
                        Array.Reverse(numbersS, i, k);
                        i += k;
                    }
                    for (int j = 0; j < numbersS.Length; j++)
                    {
                        Console.Write(numbersS[j]);
                        if (j < (numbersS.Length - 1))
                            Console.Write(",");
                    }
                    Console.WriteLine();
                }
            //Console.ReadLine();
        }
    }
}
