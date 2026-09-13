using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Value> values = new List<Value>();

            Console.WriteLine("введите название валют (2 строки), курс (дробное), дату. для выхода введите пустую строку");

            while (true)
            {
                string s = Console.ReadLine();
                if (s.Length == 0) { break; }
                List<string> properties = s.Split("\" ").ToList();

                for (int i = 0; i < 2; i++)
                {
                    properties[i] = properties[i].Substring(1);
                }

                properties.AddRange(properties[2].Split(" "));
                properties.RemoveAt(2);
                //foreach (var property in properties) {Console.WriteLine(property); }
                values.Add(new Value
                {
                    Name = properties[0],
                    Name2 = properties[1],
                    Course = Convert.ToDouble(properties[2]),
                    Date = Convert.ToDateTime(properties[3])
                });
            }
            
            foreach (Value v in values) { Console.WriteLine($"имя:{v.Name}/{v.Name2}, курс:{v.Course}, дата:{v.Date}"); }
            Value usdrub = new Value {Name="usd",Name2="rub", Course=35, Date=new DateTime(2007,5,6) };
            Console.WriteLine(F(values, usdrub));
            foreach (Value v in values) { Console.WriteLine($"имя:{v.Name}/{v.Name2}, курс:{v.Course}, дата:{v.Date}"); }

        }
        public static bool F(List<Value> currentvalues, Value toadd) 
        { 
            bool res = false;
            int index = 0;
            for (int i=0;i<currentvalues.Count;i++)
            {
                if (currentvalues[i].Name == toadd.Name && currentvalues[i].Name2 == toadd.Name2) 
                {   
                    currentvalues[i] = toadd;
                    return true;
                }
            }
            return res;
        }
    }
}