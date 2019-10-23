using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Authentication.ExtendedProtection;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class Program
    {
         static string functions="";
        static void Main(string[] args)
        {
            Reader();
            Reader2();
        }

        static void Reader()
        {
            string line = null;
            
            using (StreamReader file = new StreamReader("test.h") )
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains("("))
                    {
                        string[] tab = line.Split(' ');
                        foreach (var VARIABLE in tab)
                        {
                            if(VARIABLE.Contains('('))
                            {
                                functions += (VARIABLE.Split('(')[0] + '/');
                            }
                        }
                        
                    }
                  
                    
                    
                }
                file.Close();
            }
        }

        static void Reader2()
        {
            Dictionary<String,String> dir =new Dictionary<string, string>();
            string line = null;
            using (System.IO.StreamReader file = new System.IO.StreamReader(@"test.cpp") )
            {
                
                line = file.ReadToEnd();
                String[] tab = line.Split("{");
                string temp = tab[0].Split(" ")[1];
                foreach (var VARIABLE in tab)
                {
                    
                        if(VARIABLE.Split(" ").Length>1)
                        dir.Add(VARIABLE.Split(" ")[1], "");
                    foreach (var VARIABLE2 in functions.Split('/'))
                    {
                        if (VARIABLE.Contains(VARIABLE2))
                            dir[temp] += VARIABLE2;
                       
                    } 
                    if(VARIABLE.Split(" ").Length>1)

                    temp= VARIABLE.Split(" ")[1];
                    
                }

                file.Close();
            }
            
        }

    }
}