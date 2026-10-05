using System.Collections.Generic;
using System.IO;
using Xunit;
using ConsoleApp2;

namespace ConsoleApp2.Tests
{
    public class FactoryAddObjectsTests
    {
        private readonly Factory _factory = new Factory();

        [Fact]
        public void AddObjects_MixedFile_ReturnsAllTypes()
        {
            string path = Path.GetTempFileName();
            File.WriteAllLines(path, new[]
            {
                "курс валют: \"USD\" \"EUR\" 92.5 2024-05-01",
                "банк: \"Сбербанк\" 500000 2024-01-15",
                "криптовалюта: \"Bitcoin\" 65000.75"
            });

            try
            {
                List<Base> result = _factory.AddObjects(path);

                Assert.Equal(3, result.Count);
                Assert.IsType<Value>(result[0]);
                Assert.IsType<Bank>(result[1]);
                Assert.IsType<CryptoValue>(result[2]);
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Fact]
        public void AddObjects_EmptyFile_ReturnsEmptyList()
        {
            string path = Path.GetTempFileName();
            File.WriteAllText(path, string.Empty);

            try
            {
                List<Base> result = _factory.AddObjects(path);
                Assert.Empty(result);
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Fact]
        public void AddObjects_UnknownType_IsIgnored()
        {
            string path = Path.GetTempFileName();
            File.WriteAllLines(path, new[]
            {
                "неизвестный: \"что-то\" 123",
                "банк: \"Тинькофф\" 100 2024-02-02"
            });

            try
            {
                List<Base> result = _factory.AddObjects(path);

                Assert.Single(result);
                Assert.IsType<Bank>(result[0]);
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Fact]
        public void AddObjects_NonExistentFile_ThrowsFileNotFoundException()
        {
            Assert.Throws<FileNotFoundException>(
                () => _factory.AddObjects(@"C:\nonexistent\path\file.txt"));
        }
    }
}