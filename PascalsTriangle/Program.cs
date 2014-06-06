using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PascalsTriangle
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
                    int depth = Convert.ToInt32(line);
                    for (int n = 0; n < depth; n++)
                    {
                        for (int k = 0; k <= n; k++)
                        {
                            Console.Write(pascal(n, k));
                            if (k < n)
                                Console.Write(" ");
                        }
                        if (n < (depth - 1))
                            Console.Write(" ");
                    }
                    Console.WriteLine();
                }
            Console.ReadLine();
        }

        static Int64 pascal(int n, int k)
        {
            if (k == 0)
                return 1;
            //return (int)(pascal(n, k - 1) * ((double)n - (double)k + 1d) / (double)k);
            return (int)(pascal(n, k - 1) * (n - k + 1.0) / k);
        }

        //static Int64 pascal2(Int64 n, Int64 k)
        //{
        //    return fact(n) / (fact(k) * fact(n - k));
        //}

        //static Int64 fact(Int64 i)
        //{
        //    if (i <= 1)
        //        return 1;
        //    return i * fact(i - 1);
        //}
    }
}
