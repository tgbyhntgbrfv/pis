using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Value : Base
    {
        
        private double _course;
        public double Course { get { return _course; } set { if (value > 0) { _course = value; } else { _course = 7; } } }
        public DateTime Date { get; set; }
        public override string BaseName { get; set; } = "курс валют";
        
    }
}
