using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Program_1;

namespace ConnectionSearching
{
   public  class Program
    {
      
       
        static void Main(string[] args)
        {
            var program1Helper = new Program1Helper();
            string[] arg = { "1.t", "2.t", "3.t", "4.t" };
           
           var list= program1Helper.Connections(arg);
            
            StreamWriter logWriter = new StreamWriter("Conections.txt");

            logWriter.WriteLine(JsonConvert.SerializeObject(list));
            logWriter.Dispose();
            System.Diagnostics.Process.Start("/bin/bash", "-c \"python Drawing.py\"");
        }

    }
}
