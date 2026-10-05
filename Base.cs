using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Base
    {
        public virtual string BaseName { get; set; }
        public string ObjName { get; set; }
        public string ObjName_2 { get; set; }
        public DateTime BaseDateTime { get; set; }
        public int BaseIntValue { get; set; }
        public double BaseDoubleValue { get; set; }
        public string BaseStringValue { get; set; }
    }
}
