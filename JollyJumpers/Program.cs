using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JollyJumpers
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
                        bool jolly = true;
                        string[] numbersS = line.Split(' ');
                        int[] numbers = new int[numbersS.Length - 1];
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            numbers[i] = Convert.ToInt32(numbersS[i + 1]);
                        }
                        int n = Convert.ToInt32(numbersS[0]);
                        int[] jollys = new int[n];
                        for (int i = 0; i < (n - 1); i++)
                        {
                            int ans = Math.Abs(numbers[i] - numbers[i + 1]);
                            if (ans < jollys.Length)
                                jollys[ans] = 1;
                            else
                            {
                                jolly = false;
                                break;
                            }
                        }
                        if (jolly)
                        {
                            for (int i = 1; i < jollys.Length; i++)
                            {
                                if (jollys[i] != 1)
                                {
                                    jolly = false;
                                    break;
                                }
                            }
                        }
                        if (jolly)
                            Console.WriteLine("Jolly");
                        else
                            Console.WriteLine("Not jolly");
                    }
                //Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //Console.ReadLine();
            }
        }

    }
}
