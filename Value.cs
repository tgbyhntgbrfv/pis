using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Value
    {
        private string _name;
        private string _name2;
        public string From { get { return _name; } set { _name = value; } }
        public string To { get { return _name2; } set {  _name2 = value; } }
        private double _course;
        public double Course { get { return _course; } set { if (value > 0) { _course = value; } else { _course = 7; } } }
        private DateTime _date;
        public DateTime Date { get { return _date; } set { _date = value; } }
    }
}
