using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Endianness
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 256;
            byte b = (byte)i;
            if (b == 0)
                Console.WriteLine("LittleEndian");
            else
                Console.WriteLine("BigEndian");
            //Console.ReadLine();
        }
        
    }
}
