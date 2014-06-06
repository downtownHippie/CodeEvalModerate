using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections;

namespace SimpleCalculator
{
    class Program
    {

        static Stack<double> stack = new Stack<double>();
        static char[] input;

        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                        continue;
                    //Console.WriteLine(line);
                    //continue;
                    // get rid of all white space in line
                    line = Regex.Replace(line, @"\s", "");
                    input = line.ToCharArray();
                    int index = 0;
                    stack.Clear();
                    double result = parseInput(ref index);
                    Console.WriteLine("{0:0.#####}", result);
                }
            Console.ReadLine();
        }

        private static double parseInput(ref int index)
        {
            double result = 0;
            while (index < input.Length)
            {
                if (input[index] == '(')
                {
                    index++;
                    result = parseInput(ref index);
                }
                else if (input[index] == ')')
                {
                    index++;
                    result = stack.Pop();
                }
                else if (input[index] == '-')
                {
                    // if the previous character was a ) a numeric or a decimal point this is sutraction
                    // unless the first character
                    if (index == 0 || input[index - 1] == ')' || (input[index - 1] >= '0' && input[index] <= '9') || input[index - 1] == '.')
                    {
                        index++;
                        result = stack.Pop() - parseInput(ref index);
                    }
                    else // unary minus
                    {
                        index++;
                        result = parseInput(ref index) * -1;
                    }
                }
                else if (input[index] == '^')
                {
                    index++;
                    double baseNumber = stack.Pop();
                    result = Math.Pow(baseNumber, parseInput(ref index));
                }
                else if (input[index] == '*')
                {
                    index++;
                    result = stack.Pop() * parseInput(ref index);
                }
                else if (input[index] == '/')
                {
                    index++;
                    result = stack.Pop() / parseInput(ref index);
                }
                else if (input[index] == '+')
                {
                    index++;
                    result = stack.Pop() + parseInput(ref index);
                }
                else if ((input[index] >= '0') && (input[index] <= '9') || input[index] == '.')
                {
                    List<char> numberC = new List<char>();
                    while (index < input.Length && ((input[index] >= '0' && input[index] <= '9') || input[index] == '.'))
                        numberC.Add(input[index++]);
                    result = Double.Parse(new string(numberC.ToArray()));
                }
                stack.Push(result);
            }
            return result;
        }

        //static double getNextElement(ref int i)
        //{
        //    List<char> number = new List<char>();
        //    while ((input[i] >= '0') || (input[i] <= '9') || input[i] == '.')
        //    {
        //        number.Add(input[i++]);
        //    }
        //    return Double.Parse(new string(number.ToArray()));
        //}


        // these methods were part of version 1 of this program
        static string getNextElement(char[] input, ref int i)
        {
            List<char> number = new List<char>();
            while ((input[i] >= '0') || (input[i] <= '9') || input[i] == '.')
            {
                number.Add(input[i++]);
            }
            return new string(number.ToArray());
        }

        static string myPop(Stack<string> stack)
        {
            return "me";
        }

        static void garbage()
        {
            char[] input = { 'a' };
            Stack<string> stack = new Stack<string>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push("(");
                    i++;
                    string nextElement = getNextElement(input, ref i);
                    if (!String.IsNullOrEmpty(nextElement))
                        stack.Push(nextElement);
                }
                else if (input[i] == ')')
                {
                    stack.Push(")");
                }
                else if (input[i] == '-')
                {
                    i++;
                    string nextElement = getNextElement(input, ref i);
                    if (!String.IsNullOrEmpty(nextElement))
                        stack.Push((Convert.ToDouble(nextElement) * -1).ToString());
                    else
                        stack.Push("-");
                }
                else if (input[i] == '^')
                {
                    i++;
                    if (input[i] == '(')
                    {
                    }
                    else
                    {
                        string nextElement = getNextElement(input, ref i);
                        string lastElement = stack.Pop();
                        stack.Push((Math.Pow(Convert.ToDouble(lastElement), Convert.ToDouble(nextElement))).ToString());
                    }
                }
                else if (input[i] == '*')
                {
                    i++;
                    string nextElement = getNextElement(input, ref i);
                    if (!String.IsNullOrEmpty(nextElement))
                    {
                        string lastElement = stack.Pop();
                        stack.Push((Convert.ToDouble(nextElement) * Convert.ToDouble(lastElement)).ToString());
                    }
                    else
                        stack.Push("*");
                }
                else if (input[i] == '/')
                {
                    i++;
                    string nextElement = getNextElement(input, ref i);
                    if (!String.IsNullOrEmpty(nextElement))
                    {
                        string lastElement = stack.Pop();
                        stack.Push((Convert.ToDouble(nextElement) * Convert.ToDouble(lastElement)).ToString());
                    }
                    else
                        stack.Push("/");
                }
                else if (input[i] == '+')
                {
                }
                else if ((input[i] >= '0') && (input[i] <= '9') || input[i] == '.')
                    stack.Push(getNextElement(input, ref i));
            }
        }
    }
}
