using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Factory
    {
        public Value CreateValue(string line)
        {
            
            
            List<string> properties = line.Split("\" ").ToList();

            for (int i = 0; i < 2; i++)
            {
                properties[i] = properties[i].Substring(1);
            }

            properties.AddRange(properties[2].Split(" "));
            properties.RemoveAt(2);
            //foreach (var property in properties) {Console.WriteLine(property); }
            return new Value
            {
                ObjName = properties[0],
                ObjName_2 = properties[1],
                BaseDoubleValue = Convert.ToDouble(properties[2]),
                BaseDateTime = Convert.ToDateTime(properties[3])
            };
        }
        public CryptoValue CreateCryptoValue(string line) 
        {
            List<string> properties = line.Split("\" ").ToList();
            properties[0]=properties[0].Substring(1);
            return new CryptoValue
            {
                ObjName = properties[0],
                BaseDoubleValue = Convert.ToDouble(properties[1])
            };
        }
        public Bank CreateBank(string line)
        {
            List<string> properties = line.Split("\" ").ToList();
            properties[0] = properties[0].Substring(1);
            
            properties.AddRange(properties[1].Split(" "));
            properties.RemoveAt(1);
            

            return new Bank
            {
                ObjName = properties[0],
                BaseIntValue = Convert.ToInt32(properties[1]),
                BaseDateTime = Convert.ToDateTime(properties[2])
            };
        }
        public List<Base> AddObjects(string path)
        {
            string[] res = File.ReadAllLines(path);
            List<Base> result = new List<Base>();
            foreach (string line in res)
            {
                string[] obj = line.Split(": ");

                switch (obj[0])
                {
                    case "курс валют":
                        Value v = CreateValue(obj[1]);
                        result.Add(v);
                        break;
                    case "банк":
                        Bank b = CreateBank(obj[1]);
                        result.Add(b);
                        break;
                    case "криптовалюта":
                        CryptoValue c = CreateCryptoValue(obj[1]);
                        result.Add(c);
                        break;
                }
            }
            return result;
        }
        public void SaveToFile(List<Base> input,string path)
        {
            List<string> result = new List<string>();
            foreach (var obj in input)
            {
                result.Add($"{obj.BaseName}:");
                switch (obj.BaseName)
                {
                    case "курс валют":
                        result.Add($"\"{obj.ObjName}\" \"{obj.ObjName_2}\" " +
                            $"{obj.BaseDoubleValue} {obj.BaseDateTime:yyyy-MM-dd}");
                        break;
                    case "банк":
                        result.Add($"\"{obj.ObjName}\" {obj.BaseDoubleValue} " +
                            $"{obj.BaseDateTime:yyyy-MM-dd}");
                        break;
                    case "криптовалюта":
                        result.Add($"\"{obj.ObjName}\" {obj.BaseDoubleValue}");
                        break;
                }
            }
            File.AppendAllLines(path,result);
        }
    }
}
