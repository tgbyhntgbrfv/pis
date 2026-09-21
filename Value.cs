using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Value : Base
    {
        public string From { get; set; }
        public string To { get; set; }
        private double _course;
        public double Course { get { return _course; } set { if (value > 0) { _course = value; } else { _course = 7; } } }
        public DateTime Date { get; set; }
        public string BaseName = "курс валют";
        public string ObjName { get { return From; } set; }
        public string ObjName_2 { get { return To; } set; }
    }
}
