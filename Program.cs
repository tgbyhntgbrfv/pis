using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp2
{
    public class Program
    {
        public static List<Base> globallist = new List<Base>();
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Items = new List<MenuItem>()
            {
                new MenuAdd(),
            new MenuReadFromFile(),
            new MenuSaveToFile(),
            };
            menu.Run();

            





            /*Factory factory = new Factory();

            while (true)
            {
                Console.WriteLine("\n0.выход\n1. добавить значение" +
                    "\n2. считать с файла\n3. сохранить в файл");
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
                            Console.WriteLine("введите данные в формате имя объекта: свойства");
                            string s = Console.ReadLine() ?? "";
                            Console.WriteLine("удачно");
                            break;
                        case 2:
                            Console.WriteLine("введите путь к файлу для считывания");
                            string p = Console.ReadLine() ?? "";
                            Factory.AddObjects(p);
                            Console.WriteLine("удачно");
                            break;
                        case 3:
                            Console.WriteLine("введите путь к файлу для сохранения");
                            string path = Console.ReadLine() ?? "";
                            Factory.SaveToFile(globallist, path);
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
            }*/
        }
    }
}