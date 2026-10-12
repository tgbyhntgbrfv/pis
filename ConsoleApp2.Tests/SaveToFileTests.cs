using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using ConsoleApp2;

namespace ConsoleApp2.Tests
{
    public class FactorySaveToFileTests
    {
        private readonly Factory _factory = new Factory();

        [Fact]
        public void SaveToFile_AllTypes_WritesCorrectLines()
        {
            string path = Path.GetTempFileName();
            var objects = new List<Base>
            {
                new Value
                {
                    ObjName = "USD", ObjName_2 = "EUR",
                    BaseDoubleValue = 92.5,
                    BaseDateTime = new DateTime(2024, 5, 1)
                },
                new Bank
                {
                    ObjName = "Сбербанк",
                    BaseDoubleValue = 500000,
                    BaseDateTime = new DateTime(2024, 1, 15)
                },
                new CryptoValue
                {
                    ObjName = "Bitcoin", BaseDoubleValue = 65000.75
                }
            };

            try
            {
                _factory.SaveToFile(objects, path);
                string content = File.ReadAllText(path);

                Assert.Contains("курс валют:", content);
                Assert.Contains("банк:", content);
                Assert.Contains("криптовалюта:", content);
                Assert.Contains("USD", content);
                Assert.Contains("EUR", content);
                Assert.Contains("92,5", content);
                Assert.Contains("Bitcoin", content);
                Assert.Contains("65000,75", content);
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Fact]
        public void SaveToFile_AppendsToExistingFile()
        {
            string path = Path.GetTempFileName();
            File.WriteAllText(path, "existing line\n");

            try
            {
                _factory.SaveToFile(new List<Base>
                {
                    new CryptoValue { ObjName = "BTC", BaseDoubleValue = 1 }
                }, path);

                string[] lines = File.ReadAllLines(path);
                Assert.Equal("existing line", lines[0]);
                Assert.Equal("криптовалюта:", lines[1]);
                Assert.Equal("\"BTC\" 1", lines[2]);
            }
            finally
            {
                File.Delete(path);
            }
        }
        [Fact]
        public void Debug_CryptoValue_BaseName()
        {
            var cv = new CryptoValue { ObjName = "Bitcoin", BaseDoubleValue = 65000.75 };
            Assert.Equal("криптовалюта", cv.BaseName);  // ← если упадёт — вот причина
        }
        [Fact]
        public void Debug_ListContents()
        {
            var objects = new List<Base>
    {
        new Value { ObjName = "USD", ObjName_2 = "EUR", BaseDoubleValue = 92.5, BaseDateTime = new DateTime(2024, 5, 1) },
        new Bank { ObjName = "Сбербанк", BaseDoubleValue = 500000, BaseDateTime = new DateTime(2024, 1, 15) },
        new CryptoValue { ObjName = "Bitcoin", BaseDoubleValue = 65000.75 }
    };

            Assert.Equal(3, objects.Count);
            Assert.Equal("курс валют", objects[0].BaseName);
            Assert.Equal("банк", objects[1].BaseName);
            Assert.Equal("криптовалюта", objects[2].BaseName);  // ← если упадёт, вот причина
        }
    }
}