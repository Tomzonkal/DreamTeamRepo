using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Authentication.ExtendedProtection;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static Dictionary<string,string> functions = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            Reader();
            Connections();
        }

        private static void Connections()
        {
            string regex = @"([a-zA-Z])+\s[a-zA-Z]+\s*\(.*\)\s*\{";
            using (StreamReader file = new StreamReader("test.h"))
            {
                var x = file.ReadLine();
                var y = functions.Keys;
                for(int i=0;i<y.Count;i++)
                {
                   
                }

                file.Close();
            }
        }

        static void Reader()
        {
            string line = null;
            string regex = @"([a-zA-Z])+\s[a-zA-Z]+\s*\(.*\)\s*\{";
            using (StreamReader file = new StreamReader("test.h"))
            {

                line = file.ReadToEnd();
                int l = 0;
                var x = (Regex.Matches(line, regex));
                l += x.Count;
                foreach (Match temp in x)
                {
                    if(!functions.ContainsKey(temp.Value.Split(" ")[1].Split("(")[0]))
                    functions.Add(temp.Value.Split(" ")[1].Split("(")[0], "0");
                }

                file.Close();
            }
        }
    }
}
