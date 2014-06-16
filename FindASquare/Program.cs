using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FindASquare
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
                    //Console.WriteLine(line);
                    string[] pointsS = line.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                    List<Point> points = new List<Point>();
                    for (int i = 0; i < pointsS.Length; i++)
                    {
                        string[] xys = pointsS[i].Split(new string[] { "(", ",", ")" }, StringSplitOptions.RemoveEmptyEntries);
                        points.Add(new Point(Convert.ToInt32(xys[0]), Convert.ToInt32(xys[1])));
                    }
                    //PointComparer pc = new PointComparer();
                    //points.Sort(pc);
                    List<double> distances = new List<double>();
                    foreach (Point item in points)
                    {
                        foreach (Point item2 in points)
                        {
                            if (!item.Eq(item2))
                            {
                                double distance = Math.Sqrt(Math.Pow(item.x - item2.x, 2) + Math.Pow(item.y - item2.y, 2));
                                distances.Add(distance);
                            }
                        }
                    }
                    // there should be n^2 - n distances
                    if (Math.Pow(points.Count, 2) - points.Count != distances.Count)
                    {
                        Console.WriteLine("false");
                        continue;
                    }
                    bool bad = false;
                    distances.Sort();
                    for (int i = 0; i < points.Count * 2; i++)
                    {
                        if (distances[i] != distances[(i + 1) % points.Count])
                        {
                            Console.WriteLine("false");
                            bad = true;
                            break;
                        }
                    }
                    if (bad)
                        continue;
                    for (int i = points.Count * 2; i < distances.Count; i++)
                    {
                        if (distances[i] != distances[((i + 1) % distances.Count) == 0 ? points.Count * 2 : (i + 1)])
                        {
                            Console.WriteLine("false");
                            bad = true;
                            break;
                        }
                    }
                    if (bad)
                        continue;
                    else
                        Console.WriteLine("true");
                    //for (int i = 0; i < points.Count; i++)
                    //{
                    //    Console.Write("({0},{1})", points[i].x, points[i].y);
                    //}
                    //Console.WriteLine();
                    // if any points are the same not a square
                    if ((points[0].Eq(points[1])) || (points[1].Eq(points[2])) || (points[2].Eq(points[3])) || (points[3].Eq(points[0])))
                        Console.WriteLine("false");
                    //    these values are 1 based, lists are 0 based!!!
                    // point 1 should be directly above point 3 (same x value)
                    // point 1 should be directly across from point 2 (same y value)
                    // point 2 should be directly above point 4 (same x value)
                    // point 3 should be directly across from point 4 (same y value)
                    else if ((points[0].x == points[2].x) && (points[0].y == points[1].y) && (points[1].x == points[3].x) && (points[2].y == points[3].y))
                    {
                        // this means we have atleast a rectangle, now to determine if the rectangle is a square
                        if ((points[0].x - points[1].x == points[2].x - points[3].x) && (points[0].y - points[2].y == points[1].y - points[3].y))
                            Console.WriteLine("true");
                        else
                            Console.WriteLine("false");
                    }
                    // rotated quadralateral...
                    //else if ((points[0].x == points[3].x) && (points[1].y == points[2].y))
                    //{
                    //    // here we might have a diamond but not a square
                    //    if ((points[0].y - points[3].y) == (points[1].x - points[2].x))
                    //    {
                    //        // so we check all 4 distances
                    //        // the name of these variables are 1 based lists are 0 based!!!
                    //        double distance21 = Math.Sqrt(Math.Pow(points[1].x - points[0].x, 2) + Math.Pow(points[1].y - points[0].y, 2));
                    //        double distance13 = Math.Sqrt(Math.Pow(points[2].x - points[0].x, 2) + Math.Pow(points[2].y - points[0].y, 2));
                    //        double distance34 = Math.Sqrt(Math.Pow(points[2].x - points[3].x, 2) + Math.Pow(points[2].y - points[3].y, 2));
                    //        double distance42 = Math.Sqrt(Math.Pow(points[3].x - points[1].x, 2) + Math.Pow(points[3].y - points[1].y, 2));
                    //        if (distance21.Equals(distance13) && distance13.Equals(distance34) && distance34.Equals(distance42))
                    //            Console.WriteLine("true");
                    //        else
                    //            Console.WriteLine("false");
                    //    }
                    //    else
                    //        Console.WriteLine("false");
                    //}
                    else
                    {
                        // so we check all 4 distances
                        // the name of these variables are 1 based lists are 0 based!!!
                        double distance21 = Math.Sqrt(Math.Pow(points[1].x - points[0].x, 2) + Math.Pow(points[1].y - points[0].y, 2));
                        double distance13 = Math.Sqrt(Math.Pow(points[2].x - points[0].x, 2) + Math.Pow(points[2].y - points[0].y, 2));
                        double distance34 = Math.Sqrt(Math.Pow(points[2].x - points[3].x, 2) + Math.Pow(points[2].y - points[3].y, 2));
                        double distance42 = Math.Sqrt(Math.Pow(points[3].x - points[1].x, 2) + Math.Pow(points[3].y - points[1].y, 2));
                        if (distance21.Equals(distance13) && distance13.Equals(distance34) && distance34.Equals(distance42))
                            Console.WriteLine("true");
                        else
                            Console.WriteLine("false");
                    }
                }
            //Console.ReadLine();
        }
    }

    class Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool Eq(Point B)
        {
            if ((B.x == this.x) && (B.y == this.y))
                return true;
            else
                return false;
        }

        public override bool Equals(object obj)
        {
            Point p = (Point)obj;
            if ((p.x == this.x) && (p.y == this.y))
                return true;
            else
                return false;
        }

    }

    class PointComparer : IComparer<Point>
    {
        public int Compare(Point A, Point B)
        {
             /* this compare orders points in a quatralateral into 
              *      1  2
              *    3      4 
              *       --or--
              *       1
              *     2  
              *        3
              *       4
              *  order - these are just quadralaterals (4 points) so spacing shown to indicate not "square"
             */
            int i = B.y - A.y;
            if (i == 0)
                return A.x - B.x;
            else
                return i;
        }
    }
}
