using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Program_3;

namespace Modules_realtionsship
{
  public  class Program
    {
        public static void Main(string[] args)
        {
            var fileName = "test.h";
            var program3helper = new Program3Helper();
            var list = program3helper.GetList(fileName);

            using (StreamWriter writer = new StreamWriter("ext.txt"))
            {
                writer.Write(JsonConvert.SerializeObject(list));
            }
        }


    }
}