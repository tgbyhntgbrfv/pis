using ConsoleApp2;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace ConsoleApp2.Tests
{
    public class FactoryAddObjectsTests
    {
        
        public FactoryAddObjectsTests()
        {
            Program.globallist.Clear();
        }

        [Fact]
        public void AddObjects_MixedFile_AddsAllTypes()
        {
            var factory = new Factory();
            string path = Path.GetTempFileName();

            File.WriteAllLines(path, new[]
            {
                "курс валют: \"USD\" \"EUR\" 92.5 2024-05-01",
                "банк: \"Сбербанк\" 500000 2024-01-15",
                "криптовалюта: \"Bitcoin\" 65000.75"
            });

            try
            {
                Factory.AddObjects(path);

                Assert.Equal(3, Program.globallist.Count);
                Assert.IsType<Value>(Program.globallist[0]);
                Assert.IsType<Bank>(Program.globallist[1]);
                Assert.IsType<CryptoValue>(Program.globallist[2]);
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Fact]
        public void AddObjects_EmptyFile_AddsNothing()
        {
            var factory = new Factory();
            string path = Path.GetTempFileName();
            File.WriteAllText(path, string.Empty);

            try
            {
                Factory.AddObjects(path);

                Assert.Empty(Program.globallist);
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Fact]
        public void AddObjects_UnknownType_IsIgnored()
        {
            var factory = new Factory();
            string path = Path.GetTempFileName();

            File.WriteAllLines(path, new[]
            {
                "неизвестный: \"что-то\" 123",
                "банк: \"Тинькофф\" 100 2024-02-02"
            });

            try
            {
                Factory.AddObjects(path);

                Assert.Single(Program.globallist);
                Assert.IsType<Bank>(Program.globallist[0]);
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Fact]
        public void AddObjects_NonExistentFile_ThrowsDirectoryNotFoundException()
        {
            var factory = new Factory();

            Assert.Throws<DirectoryNotFoundException>(
                () => Factory.AddObjects(@"C:\nonexistent\path\file.txt"));
        }

        

        [Fact]
        public void AddObject_ValueLine_AddsValue()
        {
            var factory = new Factory();
            string line = "курс валют: \"USD\" \"EUR\" 92.5 2024-05-01";

            Factory.AddObject(line);

            Assert.Single(Program.globallist);
            Assert.IsType<Value>(Program.globallist[0]);
        }

        [Fact]
        public void AddObject_BankLine_AddsBank()
        {
            var factory = new Factory();
            string line = "банк: \"Сбербанк\" 500000 2024-01-15";

            Factory.AddObject(line);

            Assert.Single(Program.globallist);
            Assert.IsType<Bank>(Program.globallist[0]);
        }

        [Fact]
        public void AddObject_CryptoLine_AddsCrypto()
        {
            var factory = new Factory();
            string line = "криптовалюта: \"Bitcoin\" 65000.75";

            Factory.AddObject(line);

            Assert.Single(Program.globallist);
            Assert.IsType<CryptoValue>(Program.globallist[0]);
        }

        [Fact]
        public void AddObject_UnknownType_AddsNothing()
        {
            var factory = new Factory();
            string line = "неизвестный: \"что-то\" 123";

            Factory.AddObject(line);

            Assert.Empty(Program.globallist);
        }
    }
}