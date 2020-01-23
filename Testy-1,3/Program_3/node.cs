using System;
using System.Collections.Generic;
using System.Text;

namespace Program_3
{
    public class node
    {
        public string name;
        public Dictionary<string, int> functions = new Dictionary<string, int>();
        public int liczba_odwołań = 0;
        public string context;
        public string odwolywujący = "";
    }
}
