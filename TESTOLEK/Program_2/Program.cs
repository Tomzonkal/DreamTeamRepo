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
   public class Program
    {
       static List<string> list = new List<string>();
        static Dictionary<string,string> functions = new Dictionary<string, string>();
        static public string []arg = { "test.h" };
        static void Main(string[] args)
        {
            files t = new files();
            t.Reader(arg);
            
            Connections();
        }

        public static void Connections()
        {
            int count=1;
            string regex = @"([a-zA-Z])+\s[a-zA-Z]+\s*\(.*\)\s*\{";
            using (StreamReader file = new StreamReader("test.h"))
            {
                string x; 
                while((x=file.ReadLine())!=null)
              
                file.Close();
            }
        }

        public class files
        {
            Dictionary<string, string> functions = new Dictionary<string, string>();
            public Dictionary<string, string> Reader(string [] args)           
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
                        if (!functions.ContainsKey(temp.Value.Split(" ")[1].Split("(")[0]))
                            functions.Add(temp.Value.Split(" ")[1].Split("(")[0], "0");
                        list.Add(temp.Value.Split(" ")[1].Split("(")[0]);
                    }

                    file.Close();
                }
                return functions;
            }
        }
    }
}
