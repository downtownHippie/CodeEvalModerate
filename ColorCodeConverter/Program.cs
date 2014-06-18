using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading.Tasks;

namespace ColorCodeConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine().Trim();
                    if (string.IsNullOrEmpty(line))
                        continue;
                    //Console.WriteLine(line);
                    if (Regex.IsMatch(line, @"^HSL\((\d{1,3},){2}\d{1,3}\)$"))
                    {
                        // https://github.com/imathis/hsl-picker/blob/master/assets/javascripts/modules/color.coffee
                        //Console.Write("HSL: ");
                        string[] hsl = Regex.Split(line, @"^HSL\((\d{1,3}),(\d{1,3}),(\d{1,3})\)$");
                        double h = Convert.ToDouble(hsl[1]) / 360;
                        double s = Convert.ToDouble(hsl[2]) / 100;
                        double l = Convert.ToDouble(hsl[3]) / 100;

                        double q;
                        if (l <= 0.5)
                            q = l * (1 + s);
                        else
                            q = l + s - (l * s);

                        double p = 2 * l - q;

                        double rt = h + (1.0 / 3.0);
                        double gt = h;
                        double bt = h - (1.0 / 3.0);

                        int r = (int)Math.Round(hueToRGB(p, q, rt) * 255);
                        int g = (int)Math.Round(hueToRGB(p, q, gt) * 255);
                        int b = (int)Math.Round(hueToRGB(p, q, bt) * 255);
                        
                        Console.WriteLine("RGB({0},{1},{2})", r, g, b);
                    }
                    else if (Regex.IsMatch(line, @"^HSV\((\d{1,3},){2}\d{1,3}\)$"))
                    {
                        // this is from wikipedia - EXCEPT for the "* 255" part!!! I added that
                        //Console.Write("HSV: ");
                        string[] hsv = Regex.Split(line, @"^HSV\((\d{1,3}),(\d{1,3}),(\d{1,3})\)$");
                        double h = Convert.ToDouble(hsv[1]) / 60;
                        double s = Convert.ToDouble(hsv[2]) / 100;
                        double v = Convert.ToDouble(hsv[3]) / 100;
                        double c = v * s;
                        double x = c * (1 - Math.Abs(h % 2 - 1));
                        double m = v - c;
                        int r = 0;
                        int g = 0;
                        int b = 0;
                        if (0 <= h && h < 1)
                        {
                            r = (int)Math.Round((c + m) * 255);
                            g = (int)Math.Round((x + m) * 255);
                            b = (int)Math.Round((m) * 255);
                        }
                        else if (1 <= h && h < 2)
                        {
                            r = (int)Math.Round((x + m) * 255);
                            g = (int)Math.Round((c + m) * 255);
                            b = (int)Math.Round((m) * 255);
                        }
                        else if (2 <= h && h < 3)
                        {
                            r = (int)Math.Round((m) * 255);
                            g = (int)Math.Round((c + m) * 255);
                            b = (int)Math.Round((x + m) * 255);
                        }
                        else if (3 <= h && h < 4)
                        {
                            r = (int)Math.Round((m) * 255);
                            g = (int)Math.Round((x + m) * 255);
                            b = (int)Math.Round((c + m) * 255);
                        }
                        else if (4 <= h && h < 5)
                        {
                            r = (int)Math.Round((x + m) * 255);
                            g = (int)Math.Round((m) * 255);
                            b = (int)Math.Round((c + m) * 255);
                        }
                        else if (5 <= h && h < 6)
                        {
                            r = (int)Math.Round((c + m) * 255);
                            g = (int)Math.Round((m) * 255);
                            b = (int)Math.Round((x + m) * 255);
                        }
                        else
                        {
                            Console.WriteLine("something wonky: {0}", line);
                            continue;
                        }
                        Console.WriteLine("RGB({0},{1},{2})", r, g, b);
                    }
                    else if (Regex.IsMatch(line, @"^#[\dA-Fa-f]{6}$"))
                    {
                        //Console.Write("Hex: ");
                        string[] rgbHex = Regex.Split(line, @"^#([\dA-Fa-f]{2})([\dA-Fa-f]{2})([\dA-Fa-f]{2})$");
                        int r = Convert.ToInt32(rgbHex[1], 16);
                        int g = Convert.ToInt32(rgbHex[2], 16);
                        int b = Convert.ToInt32(rgbHex[3], 16);
                        Console.WriteLine("RGB({0},{1},{2})", r, g, b);
                    }
                    else if (Regex.IsMatch(line, @"^\((([01]\.[\d]{2}),){3}[01]\.[\d]{2}\)$"))
                    {
                        // http://www.ginifab.com/feeds/pms/colorconverter.js
                        //Console.Write("CYMK: ");
                        string[] cymk = Regex.Split(line, @"^\(([01]\.\d{2}),([01]\.\d{2}),([01]\.\d{2}),([01]\.\d{2})\)$");
                        double C = Convert.ToDouble(cymk[1]);
                        double Y = Convert.ToDouble(cymk[2]);
                        double M = Convert.ToDouble(cymk[3]);
                        double K = Convert.ToDouble(cymk[4]);
                        int r = (int)Math.Round((1 - Math.Min(1d, (C * (1 - K) + K))) * 255);
                        int g = (int)Math.Round((1 - Math.Min(1d, (Y * (1 - K) + K))) * 255);
                        int b = (int)Math.Round((1 - Math.Min(1d, (M * (1 - K) + K))) * 255);
                        Console.WriteLine("RGB({0},{1},{2})", r, g, b);
                    }
                    else
                        Console.WriteLine("Unknown color system: {0}", line);
                }
            //Console.ReadLine();
        }

        private static double hueToRGB(double p, double q, double h)
        {
            if (h < 0)
                h++;
            else if (h > 1)
                h--;

            if ((h * 6) < 1)
                return p + (q - p) * h * 6;
            else if ((h * 2) < 1)
                return q;
            else if ((h * 3) < 2)
                return p + (q - p) * ((2.0 / 3.0) - h) * 6;
            else
                return p;
        }
    }
}
