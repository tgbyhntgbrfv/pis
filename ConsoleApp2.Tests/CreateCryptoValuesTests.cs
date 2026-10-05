using System;
using Xunit;
using ConsoleApp2;

namespace ConsoleApp2.Tests
{
    public class CreateCryptoValueTests
    {
        private readonly Factory _factory = new Factory();

        [Fact]
        public void CreateCryptoValue_ValidInput_ReturnsCryptoValue()
        {
            string input = "\"Bitcoin\" 65000.75";

            CryptoValue result = _factory.CreateCryptoValue(input);

            Assert.NotNull(result);
            Assert.Equal("Bitcoin", result.ObjName);
            Assert.Equal(65000.75, result.BaseDoubleValue);
            Assert.Equal("криптовалюта", result.BaseName);
        }

        [Fact]
        public void CreateCryptoValue_IntegerValue_ParsesAsDouble()
        {
            string input = "\"Ethereum\" 3000";

            CryptoValue result = _factory.CreateCryptoValue(input);

            Assert.Equal("Ethereum", result.ObjName);
            Assert.Equal(3000.0, result.BaseDoubleValue);
        }

        [Fact]
        public void CreateCryptoValue_InvalidNumber_ThrowsFormatException()
        {
            string input = "\"Bitcoin\" not-a-number";

            Assert.Throws<FormatException>(() => _factory.CreateCryptoValue(input));
        }
    }
}