using System;
using Xunit;
using ConsoleApp2;

namespace ConsoleApp2.Tests
{
    public class FactoryCreateCryptoValueTests
    {
        [Fact]
        public void CreateCryptoValue_ValidInput_ReturnsCryptoValue()
        {
            var factory = new Factory();
            string input = "\"Bitcoin\" 65000.75";

            CryptoValue result = Factory.CreateCryptoValue(input);

            Assert.NotNull(result);
            Assert.Equal("Bitcoin", result.ObjName);
            Assert.Equal(65000.75, result.BaseDoubleValue);
            Assert.Equal("криптовалюта", result.BaseName);
        }

        [Fact]
        public void CreateCryptoValue_IntegerValue_ParsesAsDouble()
        {
            var factory = new Factory();
            string input = "\"Ethereum\" 3000";

            CryptoValue result = Factory.CreateCryptoValue(input);

            Assert.Equal("Ethereum", result.ObjName);
            Assert.Equal(3000.0, result.BaseDoubleValue);
        }

        [Fact]
        public void CreateCryptoValue_InvalidNumber_ThrowsFormatException()
        {
            var factory = new Factory();
            string input = "\"Bitcoin\" not-a-number";

            Assert.Throws<FormatException>(() => Factory.CreateCryptoValue(input));
        }
    }
}