using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StackImplementation
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
                    string[] theLine = line.Split(' ');
                    myStack theStack = new myStack();
                    for (int i = 0; i < theLine.Length; i++)
                    {
                        theStack.Push(Convert.ToInt32(theLine[i]));
                    }
                    while (theStack.Count > 0)
                    {
                        Console.Write(theStack.Pop());
                        if (theStack.Count > 0)
                            theStack.Pop();
                        if (theStack.Count >= 1)
                            Console.Write(" ");
                    }
                    Console.WriteLine();
                }
            Console.ReadLine();
        }
    }

    class myStack
    {
        private List<int> data = new List<int>();
        public int Count
        {
            get
            {
                return data.Count;
            }
        }

        public void Push(int i)
        {
            data.Insert(0, i);
        }

        public int Pop()
        {
            int popper = data.ElementAt(0);
            data.RemoveAt(0);
            return popper;
        }
    }
}
