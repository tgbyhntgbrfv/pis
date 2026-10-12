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
                Console.WriteLine("\n0.выход\n1. добавить курс валют\n" +
                    "2. добавить криптовалюту\n3. добавить банк" +
                    "\n4. считать с файла\n5. сохранить в файл");
                Console.Write("> ");

                string? input = Console.ReadLine();
                if (!int.TryParse(input, out int a))
                {
                    Console.WriteLine("Неверный ввод. Введите число от 0 до 5.");
                    continue;
                }

                if (a == 0) break;

                try
                {
                    switch (a)
                    {
                        case 1:
                            Console.WriteLine("введите: \"Имя1\" \"Имя2\" курс дата");
                            string s = Console.ReadLine() ?? "";
                            values.Add(factory.CreateValue(s));
                            Console.WriteLine("удачно");
                            break;
                        case 2:
                            Console.WriteLine("введите: \"Имя\" значение");
                            string ss = Console.ReadLine() ?? "";
                            cryptoValues.Add(factory.CreateCryptoValue(ss));
                            Console.WriteLine("удачно");
                            break;
                        case 3:
                            Console.WriteLine("введите: \"Имя\" состояние дата");
                            string sss = Console.ReadLine() ?? "";
                            banks.Add(factory.CreateBank(sss));
                            Console.WriteLine("удачно");
                            break;
                        case 4:
                            Console.WriteLine("введите путь к файлу для считывания");
                            string p = Console.ReadLine() ?? "";
                            globallist.AddRange(factory.AddObjects(p));
                            Console.WriteLine("удачно");
                            break;
                        case 5:
                            Console.WriteLine("введите путь к файлу для сохранения");
                            string path = Console.ReadLine() ?? "";
                            factory.SaveToFile(globallist, path);
                            Console.WriteLine("удачно");
                            break;
                        default:
                            Console.WriteLine("неверный ввод");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Ошибка формата: {ex.Message}");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Недостаточно данных. Проверьте формат ввода.");
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Файл не найден. Проверьте путь.");
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine("Папка не существует. Проверьте путь.");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Нет прав на доступ к файлу.");
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
                }
            }
        }
    }
}