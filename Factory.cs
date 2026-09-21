using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Factory
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
        
    }
}
