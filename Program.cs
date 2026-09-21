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

            Console.WriteLine("1. добавить курс валют\n2. добавить криптовалюту\n3. добавить банк" +
                "\n4. считать с файла\n5. сохранить в файл");
            int a = Convert.ToInt32(Console.ReadLine());

            switch (a)
            {
                case 1:
                    while (true)
                    {
                        Console.WriteLine("введите название валют (2 строки), курс (дробное), дату. " +
                            "для выхода введите пустую строку");
                        string s = Console.ReadLine();
                        if (s.Length == 0) { break; }
                        values.Add(factory.CreateValue(s));
                    }
                    break;
                case 2:
                    while (true)
                    {
                        Console.WriteLine("введите название валюты, значение (дробное). " +
                            "для выхода введите пустую строку");
                        string ss = Console.ReadLine();
                        if (ss.Length == 0) { break; }
                        cryptoValues.Add(factory.CreateCryptoValue(ss));
                    }
                    break;
                case 3:
                    while (true)
                    {
                        Console.WriteLine("введите название банка, его состояние (дробное), дату. " +
                            "для выхода введите пустую строку");
                        string sss = Console.ReadLine();
                        if (sss.Length == 0) { break; }
                        banks.Add(factory.CreateBank(sss));
                    }
                    break;
                case 4:
                    Console.WriteLine("введите путь к файлу");
                    string path = Console.ReadLine();
                    string[] res = File.ReadAllLines(path);
                    foreach (string line in res)
                    {
                        string[] obj = line.Split(": ");

                        switch (obj[0])
                        {
                            case "курс валют":
                                Value v = factory.CreateValue(obj[1]);
                                values.Add(v);
                                globallist.Add(v);
                                break;
                            case "банк":
                                Bank b = factory.CreateBank(obj[1]);
                                banks.Add(b);
                                globallist.Add(b);
                                break;
                            case "криптовалюта":
                                CryptoValue c = factory.CreateCryptoValue(obj[1]);
                                cryptoValues.Add(c);
                                globallist.Add(c);
                                break;
                        }
                    }
                    break;
                case 5:
                    List<string> result = new List<string>();
                    foreach (var obj in globallist)
                    {
                        result.Add($"{obj.BaseName}:");
                        switch (obj.BaseName)
                        {
                            case "курс валют":
                                result.Add($"\"{obj.ObjName}\" \"{obj.ObjName_2}\" {obj.BaseDoubleValue} {obj.BaseDateTime}");
                                break;
                            case "банк":
                                result.Add($"");
                                break;
                            case "криптовалюта":
                                
                                break;
                        }
                    }
                    File.AppendAllLines("C:\\Users\\student\\Desktop\\pis\\Buffer.txt", result);
                    Console.WriteLine("удачно");
                    break;
                default:
                    Console.WriteLine("неверный ввод");
                    break;
            }
        }
        public static bool F(List<Value> currentvalues, Value toadd)
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
        }
    }
}