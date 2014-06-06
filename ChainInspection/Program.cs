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
                    //Console.WriteLine(line);
                    if (string.IsNullOrEmpty(line))
                        continue;
                    // check to make sure there is a BEGIN and an END first
                    if (!Regex.IsMatch(line, "BEGIN-"))
                    {
                        //Console.WriteLine("BAD - no begin");
                        Console.WriteLine("BAD");
                        continue;
                    }
                    if (!Regex.IsMatch(line, "-END"))
                    {
                        //Console.WriteLine("BAD - no end");
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
                    // special case - 1 element chain of BEGIN-END
                    if ((links.Count == 0) && (linkEnd == "END"))
                    {
                        Console.WriteLine("GOOD");
                        continue;
                    }
                    while (links.Count != 0)
                    {
                        // find next link
                        // get linkEnd
                        // remove link
                        // if there is no link we have a problem!!!
                        bool lostSoul = false;
                        foreach (string link in links)
                        {
                            string[] splits = link.Split('-');
                            string begin = splits[0];
                            string end = splits[1];
                            if (begin == linkEnd)
                            {
                                linkEnd = end;
                                links.Remove(link);
                                lostSoul = false;
                                break;
                            }
                            // if we get to end of chain (without breaking)
                            lostSoul = true;
                        }
                        if ((links.Count == 0) && (linkEnd == "END"))
                        {
                            Console.WriteLine("GOOD");
                            break;
                        }
                        else if (lostSoul)
                        {
                            //Console.WriteLine("BAD - not at end, links still left");
                            Console.WriteLine("BAD");
                            break;
                        }
                        else if (linkEnd == "END")
                        {
                            //Console.WriteLine("BAD - still links left");
                            Console.WriteLine("BAD");
                            break;
                        }
                    }
                    
                }
            //Console.ReadLine();
        }
    }
}
