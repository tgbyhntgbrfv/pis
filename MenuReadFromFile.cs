using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class MenuReadFromFile : MenuItem
    {
        public override string Name { get => "считать с файла"; }
        public override void Func()
        {
            Console.WriteLine("введите путь к файлу для считывания");
            string p = Console.ReadLine() ?? "";
            Factory.AddObjects(p);
        }
    }
}
