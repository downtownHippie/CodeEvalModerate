using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ReverseAndAdd
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (StreamReader reader = File.OpenText(args[0]))
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (string.IsNullOrEmpty(line))
                            continue;
                        //Console.WriteLine(line);
                        Int64 count = 0;
                        Int64 ans = 0;
                        Int64 number = Convert.ToInt64(line);
                        do
                        {
                            Int64 reverse = Convert.ToInt64(new string(Convert.ToString(number).Reverse().ToArray()));
                            number = ans = number + reverse;
                            count++;
                        } while (!palindrome(ans));
                        Console.WriteLine("{0} {1}", count, ans);
                        //if (ans > UInt32.MaxValue)
                        //{
                        //    Console.WriteLine("{0} is huge", ans);
                        //}
                    }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //Console.ReadLine();
        }

        static bool palindrome(Int64 number)
        {
            string numberS = Convert.ToString(number);
            string reverseS = new string(numberS.Reverse().ToArray());
            return (numberS == reverseS);
        }
    }
}
