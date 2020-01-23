using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Program_1
{
    public class Program1Helper
    {
        public List<Source> Connections( string[] fileNames)
        {
            var sourcelist = new List<Source>();
            foreach (string temp in fileNames)
            {
                sourcelist.Add(new Source { name = temp });
            }
            string line = null;
            try
            {

                foreach (Source temp in sourcelist)
                    using (StreamReader sr = new StreamReader(temp.name))
                    {
                        FileInfo fileif = new FileInfo(temp.name);

                        temp.size = fileif.Length;

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

                                    if (find && Array.IndexOf(fileNames, temp_2)>-1)
                                    {
                                        temp.connections.Add(temp_2);
                                        find = false;
                                        foreach (Source file in sourcelist)
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
            return sourcelist;
        }
    }
}
