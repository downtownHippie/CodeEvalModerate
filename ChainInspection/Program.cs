using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace ChainInspection
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
                    // check to make sure there is a BEGIN and an END first
                    if (!Regex.IsMatch(line, "BEGIN-"))
                    {
                        Console.WriteLine("BAD");
                        continue;
                    }
                    if (!Regex.IsMatch(line, "-END"))
                    {
                        Console.WriteLine("BAD");
                        continue;
                    }
                    List<string> links = line.Split(';').ToList();
                    string linkEnd = String.Empty;
                    // find end of BEGIN link and remove it from list
                    //for (int i = 0; i < links.Count; i++)
                    //{
                    //    if (Regex.IsMatch(links[i], "BEGIN"))
                    //    {
                    //        linkEnd = links[i].Split('-')[1];
                    //        links.Remove(links[i]);
                    //        break;
                    //    }
                    //}
                    foreach (string link in links)
                    {
                        if (Regex.IsMatch(link, "BEGIN-"))
                        {
                            linkEnd = link.Split('-')[1];
                            links.Remove(link);
                            break;
                        }
                    }
                    while (links.Count != 0)
                    {
                        // find next link
                        // get linkEnd
                        // remove link
                        // if there is no link we have a problem!!!
                    }
                    if ((links.Count != 0) && (linkEnd != "END"))
                    {
                        Console.WriteLine("BAD");
                    }
                    else
                        Console.WriteLine("GOOD");
                }
        }
    }
}
