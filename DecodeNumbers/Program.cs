using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DecodeNumbers
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
                    if (line.Length == 1)
                    {
                        Console.WriteLine(1);
                        continue;
                    }
                    if ((line.Length == 2) && (Convert.ToInt32(line) <= 26))
                    {
                        Console.WriteLine(2);
                        continue;
                    }
                    if (line.Length == 2) // and greater than 26
                    {
                        Console.WriteLine(1);
                        continue;
                    }
                    // ok so now we have 3 or more digits
                    int decodes = 1; // all entries can be decoded as a list of single digit letters
                    for (int i = 0; i < line.Length - 1; i++)
                    {
                        char[] digits = { line[i], line[i + 1] };
                        //Console.WriteLine(":{0}", new string(digits));
                        if (Convert.ToInt32(new string(digits)) > 26)
                            continue;
                        else
                        {
                            if (i < digits.Length - 1)
                            {
                                //Console.WriteLine("i = {0}", i);
                                for (int k = i + 2; k < line.Length - 1; k++)
                                {
                                    char[] subDigits = { line[k], line[k + 1] };
                                    //Console.WriteLine(":{0}", new string(subDigits));
                                    if (Convert.ToInt32(new string(subDigits)) > 26)
                                        continue;
                                    else
                                        decodes++;
                                }
                            }
                            decodes++;
                        }
                    }
                    Console.WriteLine(decodes);
                }
            Console.ReadLine();
        }
    }
}
