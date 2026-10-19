using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class MenuSaveToFile : MenuItem
    {
        public override string Name { get => "сохранить в файл"; }
        public override void Func()
        {
            Console.WriteLine("введите путь к файлу для сохранения");
            string path = Console.ReadLine() ?? "";
            Factory.SaveToFile(Program.globallist, path);
        }
    }
}
