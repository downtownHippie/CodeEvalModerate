using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DetectingCycles
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    try
                    {
                        string line = reader.ReadLine();
                        if (string.IsNullOrEmpty(line))
                            continue;
                        //Console.WriteLine(":" + line);
                        string[] numbersS = line.Trim().Split(' ');
                        int[] numbers = new int[numbersS.Length];
                        for (int i = 0; i < numbersS.Length; i++)
                            numbers[i] = Convert.ToInt32(numbersS[i]);
                        int tortoiseP = 1;
                        int hareP = 2;
                        int tortoise = numbers[tortoiseP];
                        int hare = numbers[hareP];
                        while (tortoise != hare)
                        {
                            tortoise = numbers[++tortoiseP];
                            hare = numbers[hareP = (hareP + 2 >= numbers.Length ? Array.FindIndex(numbers, x => x == hare) + 2 : hareP += 2)];
                        }
                        int mu = 0;
                        tortoise = numbers[tortoiseP = 0];
                        while (tortoise != hare)
                        {
                            tortoise = numbers[++tortoiseP];
                            hare = numbers[hareP = (hareP + 1 >= numbers.Length ? Array.FindIndex(numbers, x => x == hare) + 1 : ++hareP)];
                            mu++;
                        }
                        int lam = 1;
                        hare = numbers[++tortoiseP];
                        while (tortoise != hare)
                        {
                            hare = numbers[++tortoiseP];
                            lam++;
                        }
                        for (int i = mu; i < mu + lam; i++)
                        {
                            Console.Write(numbers[i]);
                            if (i < (mu + lam - 1))
                                Console.Write(" ");
                        }
                        Console.WriteLine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }
            //Console.ReadLine();
        }
    }
}
