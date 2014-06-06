using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace URIComparison
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
                    string[] splits = line.Split(';');
                    string uri1 = splits[0];
                    string uri2 = splits[1];

                    // check schemes
                    //   we assume only http and https
                    string schemeUri1 = uri1.Substring(0, uri1.IndexOf(':')).ToLower();
                    string schemeUri2 = uri2.Substring(0, uri2.IndexOf(':')).ToLower();
                    if (schemeUri1 != schemeUri2)
                    {
                        Console.WriteLine("False");
                        continue;
                    }

                    // remove scheme and :// from uri
                    uri1 = uri1.Remove(0, uri1.IndexOf(':') + 3);
                    uri2 = uri2.Remove(0, uri2.IndexOf(':') + 3);

                    // check hostname with ports
                    //   since we are assuming http and https hostname follows :// (just removed) and ends with a / -- maybe...
                    int index;
                    string hostnameUri1;
                    string hostnameUri2;
                    index = uri1.IndexOf('/');
                    if (index != -1)
                        hostnameUri1 = uri1.Substring(0, index).ToLower();
                    else // NO PATH!
                        hostnameUri1 = uri1.ToLower();
                    index = uri2.IndexOf('/');
                    if (index != -1)
                        hostnameUri2 = uri2.Substring(0, index).ToLower();
                    else // NO PATH!!!
                        hostnameUri2 = uri2.ToLower();

                    // check ports if necessary
                    bool setPort1 = false;
                    bool setPort2 = false;
                    string port1 = String.Empty;
                    string port2 = String.Empty;
                    if (hostnameUri1 != hostnameUri2)
                    {
                        int indexOfHostNameColon;
                        indexOfHostNameColon = hostnameUri1.IndexOf(':');
                        if (indexOfHostNameColon == -1)
                            port1 = "80";
                        else
                        {
                            port1 = hostnameUri1.Substring(indexOfHostNameColon + 1);
                            hostnameUri1 = hostnameUri1.Substring(0, indexOfHostNameColon);
                            setPort1 = true;
                        }
                        indexOfHostNameColon = hostnameUri2.IndexOf(':');
                        if (indexOfHostNameColon == -1)
                            port2 = "80";
                        else
                        {
                            port2 = hostnameUri2.Substring(indexOfHostNameColon + 1);
                            hostnameUri2 = hostnameUri2.Substring(0, indexOfHostNameColon);
                            setPort2 = true;
                        }
                        if ((hostnameUri1 != hostnameUri2) && (port1 != port2))
                        {
                            Console.WriteLine("False");
                            continue;
                        }
                        //if (port1 != port2)
                        //{
                        //    Console.WriteLine("False");
                        //    continue;
                        //}
                    }
                    // hostnameUri[12] are equal (with or without port specified)
                    // remove hostnames (with ports) from uris
                    if (setPort1)
                        uri1 = uri1.Remove(0, (hostnameUri1.Length + port1.Length + 1)); // + 1 don't forget :
                    else
                        uri1 = uri1.Remove(0, hostnameUri1.Length);
                    if (setPort2)
                        uri2 = uri2.Remove(0, (hostnameUri2.Length + port2.Length + 1)); // + 1 don't forget :
                    else
                        uri2 = uri2.Remove(0, hostnameUri2.Length);
                    // if empty strings then no path's so continue
                    if (String.IsNullOrEmpty(uri1) && String.IsNullOrEmpty(uri2))
                    {
                        Console.WriteLine("True");
                        continue;
                    }
                    // now path is everything after the /
                    string path1 = uri1.Remove(0, 1);
                    string path2 = uri2.Remove(0, 1);
                    // check path
                    path1 = fixHex(path1);
                    path2 = fixHex(path2);
                    if (path1 != path2)
                    {
                        Console.WriteLine("False");
                        continue;
                    }
                    Console.WriteLine("True");
                }
            //Console.ReadLine();
        }

        private static string fixHex(string path)
        {
            List<char> chars = path.ToCharArray().ToList();
            // iterate through path as a list of char
            // if find " find next "
            // otherwise if % get next 2 chars, remove % and 2 chars insert real char
            int index = 0;
            do
            {
                // if a backslash, skip it and next char
                if (chars[index] == '\\')
                {
                    index += 2;
                }
                //else if (chars[index] == '"')
                //{
                //    // find next "
                //    while (chars[++index] != '"')
                //        ;
                //    // then skip it
                //    index++;
                //}
                else if (chars[index] == '%')
                {
                    string unFixedChar = new string(chars.GetRange(index + 1, 2).ToArray());
                    try
                    {
                        int fixedChar = Int32.Parse(unFixedChar, System.Globalization.NumberStyles.AllowHexSpecifier);
                        chars.RemoveRange(index, 3);
                        chars.Insert(index, (char)fixedChar);
                        index++;
                    }
                    catch (FormatException fE)
                    {
                        index++;
                    }
                }
                else
                    index++;
            } while (index < chars.Count);

            return new string(chars.ToArray());
        }
    }
}
