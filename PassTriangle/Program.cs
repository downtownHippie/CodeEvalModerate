using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

namespace PassTriangle
{
    class Program
    {

        // thanks to
        // http://hamidj.wordpress.com/tag/codeeval-pass-triangle/

        public static List<List<int>> tree = new List<List<int>>();

        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                        continue;
                    List<int> theLine = Array.ConvertAll(line.Trim().Split(' '), element => Convert.ToInt32(element)).ToList();
                    tree.Add(theLine);
                }
            Console.WriteLine(sumOfTree());
            Console.ReadLine();
        }

        private static int sumOfTree()
        {
            int depthOfTree = tree.Count;
            for (int i = depthOfTree - 2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (tree[i + 1][j] > tree[i + 1][j + 1])
                        tree[i][j] += tree[i + 1][j];
                    else
                        tree[i][j] += tree[i + 1][j + 1];
                }
            }
            return tree[0][0];
        }
    }

    //class nothing
    //{
    //    void method_test()
    //    {     
    //        Console.WriteLine(line);
    //                string[] numberS = line.Trim().Split(' ');
    //                if (sum == 0)
    //                {
    //                    sum = Convert.ToInt32(numberS[0]);
    //                    continue;
    //                }
    //                int[] numbers = new int[numberS.Length];
    //                for (int i = 0; i < numbers.Length; i++)
    //                {
    //                    numbers[i] = Convert.ToInt32(numberS[i]);
    //                }
    //                int left = numbers[index];
    //                int right = numbers[index + 1];
    //                Console.WriteLine("S:{0} L:{1} R:{2} I:{3}", sum, left, right, index);
    //                if (left > right)
    //                {
    //                    Console.WriteLine("adding left");
    //                    sum += left;
    //                }
    //                else if (right > left)
    //                {
    //                    Console.WriteLine("adding right");
    //                    sum += right;
    //                    index++;
    //                }
    //                else
    //                {
    //                    Console.WriteLine("Fucking equal!");
    //                    break;
    //                }
    //    }
    //}
}
