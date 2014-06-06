using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OverlappingRectangles
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
                    string[] points = line.Split(',');
                    Rect A = new Rect(Convert.ToInt32(points[0]), Convert.ToInt32(points[1]), Convert.ToInt32(points[2]), Convert.ToInt32(points[3]));
                    Rect B = new Rect(Convert.ToInt32(points[4]), Convert.ToInt32(points[5]), Convert.ToInt32(points[6]), Convert.ToInt32(points[7]));
                    if (!(A.upperLeftX > B.upperRightX) && !(A.upperRightX < B.upperLeftX) && !(A.upperLeftY < B.lowerLeftY) && !(A.lowerLeftY > B.upperLeftY))
                        Console.WriteLine(true);
                    else
                        Console.WriteLine(false);
                }
            //Console.ReadLine();
        }
    }

    class Rect
    {
        public int upperLeftX;
        public int upperLeftY;
        public int upperRightX;
        public int upperRightY;
        public int lowerLeftX;
        public int lowerLeftY;
        public int lowerRightX;
        public int lowerRightY;
 
        public Rect(int upperLeftX, int upperLeftY, int lowerRightX, int lowerRightY)
        {
            this.upperLeftX = upperLeftX;
            this.upperLeftY = upperLeftY;

            this.lowerRightX = lowerRightX;
            this.lowerRightY = lowerRightY;

            this.upperRightX = lowerRightX;
            this.upperRightY = upperLeftY;

            this.lowerLeftX = upperLeftX;
            this.lowerLeftY = lowerRightY;
        }
    }
}
