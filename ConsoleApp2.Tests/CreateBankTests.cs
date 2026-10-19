using System;
using Xunit;
using ConsoleApp2;

namespace ConsoleApp2.Tests
{
    public class FactoryCreateBankTests
    {
        [Fact]
        public void CreateBank_ValidInput_ReturnsBank()
        {
            var factory = new Factory();
            string input = "\"Сбербанк\" 500000 2024-01-15";

            Bank result = Factory.CreateBank(input);

            Assert.NotNull(result);
            Assert.Equal("Сбербанк", result.ObjName);
            Assert.Equal(500000, result.BaseIntValue);
            Assert.Equal(new DateTime(2024, 1, 15), result.BaseDateTime);
            Assert.Equal("банк", result.BaseName);
        }

        [Fact]
        public void CreateBank_InvalidIntValue_ThrowsFormatException()
        {
            var factory = new Factory();
            string input = "\"Сбербанк\" abc 2024-01-15";

            Assert.Throws<FormatException>(() => Factory.CreateBank(input));
        }
    }
}