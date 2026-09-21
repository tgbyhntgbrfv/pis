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
                From = properties[0],
                To = properties[1],
                Course = Convert.ToDouble(properties[2]),
                Date = Convert.ToDateTime(properties[3])
            };
        }
        public CryptoValue CreateCryptoValue(string line) 
        {
            List<string> properties = line.Split("\" ").ToList();
            properties[0]=properties[0].Substring(1);
            return new CryptoValue
            {
                Name = properties[0],
                Value = Convert.ToDouble(properties[1])
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
                Name = properties[0],
                Capital = Convert.ToInt32(properties[1]),
                Date = Convert.ToDateTime(properties[2])
            };
        }
        
    }
}
