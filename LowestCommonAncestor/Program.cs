using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LowestCommonAncestor
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("beginning");
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            //Console.WriteLine("Constructor called");
            tree.Add(30);
            //Console.WriteLine("first value added");
            tree.Add(8);
            tree.Add(52);
            tree.Add(3);
            tree.Add(20);
            tree.Add(10);
            tree.Add(29);
            //Console.WriteLine("done adding");
            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                        continue;
                    //Console.WriteLine(line);
                    string[] splits = line.Split(' ');
                    int x = Convert.ToInt32(splits[0]);
                    int y = Convert.ToInt32(splits[1]);
                    if (x < y)
                        Console.WriteLine(tree.lca(x, y));
                    else
                        Console.WriteLine(tree.lca(y, x));
                }
            //Console.ReadLine();
        }
    }

    class Node<T>
    {
        public T data;
        public Node<T> left = null;
        public Node<T> right = null;

        public Node(T d)
        {
            this.data = d;
        }
    }

    class BinarySearchTree<T>
    {
        private Node<T> Root { get; set; }

        public BinarySearchTree()
        {
            this.Root = null;
        }

        public void Add(T x)
        {
            this.Root = Add(x, this.Root);
        }

        public T lca(T x, T y)
        {
            return lca(x, y, this.Root);
        }

        private T lca(T x, T y, Node<T> t)
        {
            if (((x as IComparable).CompareTo(t.data) <= 0) && ((y as IComparable).CompareTo(t.data) >= 0))
                return t.data;
            else if (((x as IComparable).CompareTo(t.data) < 0) && ((y as IComparable).CompareTo(t.data) < 0))
                return lca(x, y, t.left);
            else //if (((x as IComparable).CompareTo(t.data) > 0) && ((y as IComparable).CompareTo(t.data) > 0))
                return lca(x, y, t.right);
        }

        public Node<T> Add(T x, Node<T> t)
        {
            if (t == null)
                t = new Node<T>(x);
            else if ((x as IComparable).CompareTo(t.data) < 0)
                t.left = Add(x, t.left);
            else if ((x as IComparable).CompareTo(t.data) > 0)
                t.right = Add(x, t.right);
            return t;
        }
    }
}
