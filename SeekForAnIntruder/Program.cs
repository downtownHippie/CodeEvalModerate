using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace SeekForAnIntruder
{
    class Program
    {
        public static MyList ips = new MyList();

        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                        continue;
                    // get ride of all invalid characters
                    string line2 = Regex.Replace(line, @"[^0-9A-Fa-fxX\.]", "_");
                    // split resulting string on _ without returning empty elements
                    string[] elements = line2.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string item in elements)
                    {
                        // determine if item contains an ip address
                        if (isIP(item))
                        {
                            if (ips.ContainsIP(item))
                                ips[item]++;
                            else
                                ips.Add(new IPCounts(item));
                        }
                        // if it is see if it is in address
                        // increment count if so
                        // else add to list
                    }
                }
            ips.Sort(new IPComparer());
            Console.Write(ips[0].address);
            int maxCount = ips[0].count;
            for (int i = 1; i < ips.Count; i++)
            {
                if (ips[i].count == maxCount)
                {
                    Console.Write(" {0}", ips[i].address);
                }
            }
            Console.WriteLine(".");
            Console.ReadLine();
        }

        private static bool isIP(string item)
        {
            return false;
        }
    }

    public struct IPCounts
    {
        public int count;
        public string address;

        public IPCounts()
        {
            this.count = 1;
            this.address = String.Empty;
        }

        public IPCounts(string address)
        {
            this.address = address;
            this.count = 1;
        }


    }

    public class MyList : List<IPCounts>
    {
        public bool ContainsIP(string addr)
        {
            foreach (IPCounts item in this)
            {
                if (item.address == addr)
                    return true;
            }
            return false;
        }

        public int this[string address]
        {
            get
            {
                foreach (IPCounts item in this)
                {
                    if (item.address == address)
                        return item.count;
                }
                return -1;
            }
            set
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (this[i].address == address)
                    {
                        IPCounts newIPC = new IPCounts(this[i].address);
                        newIPC.count = value;
                        this[i] = newIPC;
                    }
                }
                //foreach (IPCounts item in this)
                //{
                //    if (item.address == address)
                //        item.count = value;
                //}
            }
        }
    }

    public class IPComparer : IComparer<IPCounts>
    {
        public int Compare(IPCounts x, IPCounts y)
        {
            int countDelta = x.count - y.count;
            if (countDelta == 0)
            {
                return y.address.CompareTo(x.address);
            }
            else
                return countDelta;
        }
    }
}
