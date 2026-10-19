using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class MenuAdd : MenuItem
    {
        public override string Name { get => "добавить значение"; }
        public override void Func()
        {
            Console.WriteLine("введите данные в формате имя объекта: свойства");
            string s = Console.ReadLine() ?? "";
            Factory.AddObject(s);
        }
    }
}
