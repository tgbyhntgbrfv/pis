
using Microsoft.Testing.Extensions.TrxReport.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Menu
    {
        public List<MenuItem> Items = new List<MenuItem>();
        

        public void Run()
        {
            while (true)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    Console.WriteLine($"{i+1}. {Items[i].Name}\n");
                }
                int input = Convert.ToInt16(Console.ReadLine());
                if (input > Items.Count || input < 0) { Console.WriteLine($"Неправильный ввод. Введите число от 0 до {Items.Count}"); }
                else { Items[input-1].Func(); }
            }
        }
        
    }
}
