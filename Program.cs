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
                string[] properties = s.Split(',');
                values.Add(new Value { Name = properties[0], NameRus = properties[1], 
                    Course = Convert.ToDouble(properties[2]), Date = Convert.ToDateTime(properties[3])});
            }
            foreach (Value v in values) { Console.WriteLine($"имя:{v.Name}/{v.NameRus}, курс:{v.Course}, дата:{v.Date}"); }
        }
    }
}
