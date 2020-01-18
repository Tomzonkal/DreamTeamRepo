using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace ConnectionSearching
{
    class Program
    {
        static List<Source> list = new List<Source>();
        static string Main_string = null;
        static void Main(string[] args)
        {
            string[] arg = { "1.t", "2.t", "3.t", "4.t" };
            foreach (string temp in arg)
            {
                list.Add(new Source { name = temp });
                Main_string += temp;
            }
            Connections();
            
            StreamWriter logWriter = new StreamWriter("../../../../output/P_1.txt");

            logWriter.WriteLine(JsonConvert.SerializeObject(list));
            logWriter.Dispose();
            System.Diagnostics.Process.Start("/bin/bash", "-c \"python Drawing.py\"");
        }

        static void Connections()
        {


            string line = null;
            try
            {
                
                foreach (Source temp in list)
                    using (StreamReader sr = new StreamReader(temp.name))
                    {
                        FileInfo fileif = new FileInfo(temp.name);
                        
                           temp.size= fileif.Length;
                        
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line.Contains("using") || line.Contains("include") || line.Contains("import"))
                            {
                                List<string> listed = null;
                                if (line.Contains("using"))
                                {
                                    listed = new List<string>(line.Split(" "));
                                }

                                if (line.Contains("include"))
                                {
                                    listed = new List<string>(line.Split('"'));
                                }
                                if (line.Contains("import"))
                                {
                                    listed = new List<string>(line.Split(" "));
                                }
                                bool find = false;
                                foreach (string temp_2 in listed)
                                {

                                    if (find && Main_string.Contains(temp_2))
                                    {
                                        temp.connections.Add(temp_2);
                                        find = false;
                                        foreach (Source file in list)
                                        {
                                            if (file.name.Contains(temp_2))
                                                file.connected++;
                                        }
                                    }

                                    if (temp_2.Contains("using") || temp_2.Contains("include") || temp_2.Contains("import"))
                                        find = true;

                                }

                            }
                        }
                    }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

        }

        private class Source
        {
            public string name;
            public List<string> connections = new List<string>();
            public int connected = 0;
            public double size;

        }
    }
}
