using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ValidParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] opens = {'(', '{', '['};
            //char[] closes = {')', '}', ']'};
            //int lineCount = 1;
            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    //Console.WriteLine(lineCount++ + ":" + line);
                    if (string.IsNullOrEmpty(line))
                        continue;
                    Stack<char> stack = new Stack<char>();
                    bool good = true;
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (opens.Contains(line[i]))
                            stack.Push(line[i]);
                        else
                        {
                            if (stack.Count >= 1)
                            {
                                char element = stack.Pop();
                                if (line[i] == ')' && !(element == '('))
                                {
                                    Console.WriteLine(false);
                                    good = false;
                                    break;
                                }
                                else if (line[i] == '}' && !(element == '{'))
                                {
                                    Console.WriteLine(false);
                                    good = false;
                                    break;
                                }
                                else if (line[i] == ']' && !(element == '['))
                                {
                                    Console.WriteLine(false);
                                    good = false;
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine(false);
                                good = false;
                                break;
                            }
                        }
                        if (stack.Count == 0 && (i == line.Length - 1))
                            Console.WriteLine(true);
                    }
                    if (stack.Count != 0 && good)
                        Console.WriteLine(false);
                }
            //Console.ReadLine();
        }
    }
}
