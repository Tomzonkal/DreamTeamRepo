using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
namespace Modules_realtionsship
{
    class node
    {
        public string name;
        public Dictionary<string, int> functions = new Dictionary<string, int>();
        public int liczba_odwołań = 0;
        public string context;
        public string odwolywujący = "";
    }
    class Program
    {

        static List<node> list = new List<node>();
        static Dictionary<string, int> Reader(string tekst)
        {
            string line = null;
            string regex = @"([a-zA-Z])+\s[a-zA-Z]+\s*\(.*\)\s*\{";
            Dictionary<string, int> functions = new Dictionary<string, int>();
            {

                line = tekst;
                int l = 0;
                var x = (Regex.Matches(line, regex));
                l += x.Count;
                foreach (Match temp in x)
                {

                    functions.Add((temp.Value.Split(" ")[1] + '('), 0);
                }

                return functions;
            }
        }


        static void Main(string[] args)
        {
            string[] namespacess;
            using (StreamReader file = new StreamReader("test.h"))
            {
                namespacess = file.ReadToEnd().Split("namespace");
                file.Close();
                int i = 0;
                foreach (var VARIABLE in namespacess)
                {
                    if (i != 0)
                        list.Add(new node() { name = VARIABLE.Split('\n')[0], functions = Reader(VARIABLE), context = VARIABLE });
                    i++;
                }

            }

            foreach (var node in list)
            {
                foreach (var node_function in list)
                {
                    foreach (var function in node_function.functions.Keys.ToList())
                    {
                        if (node.context.Contains(function))
                        {
                            node_function.functions[function]++;
                            node_function.liczba_odwołań++;
                            node_function.odwolywujący += (node.name + '/');
                        }
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter("ext.txt"))
            {
                writer.Write(JsonConvert.SerializeObject(list));
            }
        }
    }
}