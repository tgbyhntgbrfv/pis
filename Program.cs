using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp2
{
    class Program
    {
        
        static void Main(string[] args)
        {

            List<Value> values = new List<Value>();
            List<CryptoValue> cryptoValues = new List<CryptoValue>();
            List<Bank> banks = new List<Bank>();
            List<Base> globallist = new List<Base>();
            Factory factory = new Factory();
            
            while (true)
            {
                Console.WriteLine("0.выход\n1. добавить курс валют\n" +
                    "2. добавить криптовалюту\n3. добавить банк" +
                    "\n4. считать с файла\n5. сохранить в файл");
                int a = Convert.ToInt16(Console.ReadLine());

                if (a == 0) { break;}
                switch (a)
                {
                    case 1:
                        Console.WriteLine("введите название валют (2 строки), курс (дробное), дату. ");
                        string s = Console.ReadLine();
                        values.Add(factory.CreateValue(s));
                        break;
                    case 2:
                        Console.WriteLine("введите название валюты, значение (дробное).");
                        string ss = Console.ReadLine();
                        cryptoValues.Add(factory.CreateCryptoValue(ss));
                        break;
                    case 3:
                        Console.WriteLine("введите название банка, его состояние (дробное), дату. ");
                        string sss = Console.ReadLine();
                        banks.Add(factory.CreateBank(sss));
                        break;
                    case 4:
                        Console.WriteLine("введите путь к файлу для считывания");
                        string p = Console.ReadLine();
                        globallist.AddRange(factory.AddObjects(p));
                        Console.WriteLine("удачно");
                        break;
                    case 5:
                        Console.WriteLine("введите путь к файлу для сохранения");
                        string path = Console.ReadLine();
                        factory.SaveToFile(globallist,path);
                        Console.WriteLine("удачно");
                        break;
                    default:
                        Console.WriteLine("неверный ввод");
                        break;
                }
            }
        }
        /*public static bool F(List<Value> currentvalues, Value toadd)
        {
            int index = 0;
            for (int i = 0; i < currentvalues.Count; i++)
            {
                if (currentvalues[i].ObjName == toadd.ObjName && currentvalues[i].ObjName_2 == toadd.ObjName_2)
                {
                    currentvalues[i] = toadd;
                    return true;
                }
            }
            return false;
        }*/
    }
}