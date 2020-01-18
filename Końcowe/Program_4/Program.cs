using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Program_4
{
    class Program
    {
        static Dictionary<string, List<string>> functions = new Dictionary<string, List<string>>();
       static string[] arg = { "test1.h","test.h" };
        static void Main(string[] args)
        {
            Reader();

            StreamWriter logWriter = new StreamWriter(@"../../../../output/P_4.txt");

            logWriter.WriteLine(JsonConvert.SerializeObject(functions));
            logWriter.Dispose();
        }










        static void Reader()
        {
            string line = null;
            string regex = @"([a-zA-Z])+\s[a-zA-Z]+\s*\(.*\)\s*\{";
            foreach(string file_name in arg )
            using (StreamReader file = new StreamReader(file_name))
            {
                    functions.Add(file_name, new List<string>());
                line = file.ReadToEnd();
                int l = 0;
                var x = (Regex.Matches(line, regex));
                l += x.Count;
                foreach (Match temp in x)
                {
                        functions[file_name].Add(temp.Value.Substring(0, temp.Length - 1));
                }

                file.Close();
            }
        }
    }
}
