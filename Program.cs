using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < args.Length; ++i)
            {
                Console.WriteLine(args[i] + "\n");
            }

            List<Value> values = new List<Value>();
            Factory factory = new Factory();

            Console.WriteLine("введите название валют (2 строки), курс (дробное), дату. для выхода введите пустую строку");

            while (true)
            {
                string s = Console.ReadLine();
                if (s.Length == 0) { break; }
                values.Add(factory.CreateValue(s));
            }

            foreach (Value v in values)
            {
                Console.WriteLine($"имя:{v.From}/{v.To}, курс:{v.Course}, дата:{v.Date}");
            }
            Value usdrub = new Value { From = "usd", To = "rub", Course = 35, Date = new DateTime(2007, 5, 6) };
            Console.WriteLine(F(values, usdrub));
            foreach (Value v in values)
            {
                Console.WriteLine($"имя:{v.From}/{v.To}, курс:{v.Course}, дата:{v.Date}");
            }

        }
        public static bool F(List<Value> currentvalues, Value toadd)
        {
            int index = 0;
            for (int i = 0; i < currentvalues.Count; i++)
            {
                if (currentvalues[i].From == toadd.From && currentvalues[i].To == toadd.To)
                {
                    currentvalues[i] = toadd;
                    return true;
                }
            }
            return false;
        }
    }
}