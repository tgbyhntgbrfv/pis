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
        private string _name_2;
        public string Name { get { return _name; } set { _name = value; } }
        public string NameRus { get { return _name; } set {  _name_2 = value; } }
        private float _course;
        public float Course { get { return _course; } set { _course = value; } }
        private DateTime _date;
        public DateTime Date { get { return _date; } set { _date = value; } }

    }
}
