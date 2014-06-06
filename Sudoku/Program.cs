using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Sudoku
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
                    string[] splits = line.Split(';');
                    int gridSize = Convert.ToInt32(splits[0]);
                    int subGridSize = (int)Math.Sqrt(gridSize);
                    if (subGridSize * subGridSize != gridSize)
                    {
                        Console.WriteLine("invalid grid size: {0}", gridSize);
                        continue;
                    }
                    string[] numbers = splits[1].Split(',');
                    int[,] puzzle = new int[gridSize, gridSize];
                    int k = 0;
                    while (k < numbers.Length)
                    {
                        for (int row = 0; row < gridSize; row++)
                        {
                            for (int column = 0; column < gridSize; column++)
                            {
                                puzzle[row, column] = Convert.ToInt32(numbers[k++]);
                            }
                        }
                    }
                    bool bad = false;
                    // iterate through each row checking for validity
                    for (int row = 0; row < gridSize; row++)
                    {
                        // create array to hold each number in solution, so gridsize + 1 -- we'll ignore checks[0]
                        int[] checks = new int[gridSize + 1];
                        for (int column = 0; column < gridSize; column++)
                        {
                            checks[puzzle[row, column]] = 1;
                        }
                        for (int i = 1; i < gridSize + 1; i++)
                        {
                            if (checks[i] != 1)
                            {
                                Console.WriteLine("False");
                                bad = true;
                                break;
                            }
                        }
                        if (bad)
                            break;
                    }
                    if (bad)
                        continue;
                    // iterate through each column checking for validity
                    for (int column = 0; column < gridSize; column++)
                    {
                        // create array to hold each number in solution, so gridsize + 1 -- we'll ignore checks[0]
                        int[] checks = new int[gridSize + 1];
                        for (int row = 0; row < gridSize; row++)
                        {
                            checks[puzzle[row, column]] = 1;
                        }
                        for (int i = 1; i < gridSize + 1; i++)
                        {
                            if (checks[i] != 1)
                            {
                                Console.WriteLine("False");
                                bad = true;
                                break;
                            }
                        }
                        if (bad)
                            break;
                    }
                    if (bad)
                        continue;
                    // iterate through each subgrid checking for validity
                    for (int gridsAcross = 1; gridsAcross <= subGridSize; gridsAcross++)
                    {
                        for (int gridsDown = 1; gridsDown <= subGridSize; gridsDown++)
                        {
                            // create array to hold each number in solution, so gridsize + 1 -- we'll ignore checks[0]
                            int[] checks = new int[gridSize + 1];
                            for (int row = (gridsAcross - 1) * subGridSize; row < gridsAcross * subGridSize; row++)
                            {
                                for (int column = (gridsDown - 1) * subGridSize; column < gridsDown * subGridSize; column++)
                                {
                                    checks[puzzle[row, column]] = 1;
                                }
                            }
                            for (int i = 1; i < gridSize + 1; i++)
                            {
                                if (checks[i] != 1)
                                {
                                    Console.WriteLine("False");
                                    bad = true;
                                    break;
                                }
                            }
                            if (bad)
                                break;
                        }
                        if (bad)
                            break;
                    }
                    if (bad)
                        continue;
                    if (!bad)
                        Console.WriteLine("True");
                }
            //Console.ReadLine();
        }
    }
}
