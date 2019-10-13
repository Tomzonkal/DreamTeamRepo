using System;
using System.IO;
using System.Collections.Generic;

namespace ConnectionSearching
{
    class Program
    {
        static void Main(string[] args)
        {
            string file;
            

        }





        List<string> Connections(string file)
        {
            List<string> connections=new List<string>();
            string[] includes=null;
          string line=null;
            try
            {
                using(StreamReader sr = new StreamReader(file))
                {
                   while((line = sr.ReadLine()) != null)  
                        {  
                            if (line.Contains("using")||line.Contains("include")||line.Contains("import"))
                            {
                             List <string> list =new List<string>(line.Split(" "));
                             bool find=false;
                             foreach(string temp in list)
                             {
                                 
                                 if(find)
                                 {
                                    connections.Add(temp);
                                    find=false;
                                 }
                                 
                                 if (temp.Contains("using")||temp.Contains("include")||temp.Contains("import"))
                                find=true;

                             }

                            }
                        }   
                }
            } catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
        
        return connections;
        }
    }
}
