using System;
using Xunit;
using ConsoleApp2;

namespace ConsoleApp2.Tests
{
    public class CreateValueTests
    {
        private readonly Factory _factory = new Factory();

        [Fact]
        public void CreateValue_ValidInput_ReturnsValueWithCorrectProperties()
        {
            string input = "\"USD\" \"EUR\" 92.5 2024-05-01";

            Value result = _factory.CreateValue(input);

            Assert.NotNull(result);
            Assert.Equal("USD", result.ObjName);
            Assert.Equal("EUR", result.ObjName_2);
            Assert.Equal(92.5, result.BaseDoubleValue);
            Assert.Equal(new DateTime(2024, 5, 1), result.BaseDateTime);
            Assert.Equal("курс валют", result.BaseName);
        }

        [Fact]
        public void CreateValue_WithRussianNames_ParsesCorrectly()
        {
            string input = "\"Доллар\" \"Евро\" 100.25 2023-12-31";

            Value result = _factory.CreateValue(input);

            Assert.Equal("Доллар", result.ObjName);
            Assert.Equal("Евро", result.ObjName_2);
            Assert.Equal(100.25, result.BaseDoubleValue);
            Assert.Equal(new DateTime(2023, 12, 31), result.BaseDateTime);
        }

        [Fact]
        public void CreateValue_InvalidDateFormat_ThrowsFormatException()
        {
            string input = "\"USD\" \"EUR\" 92.5 not-a-date";

            Assert.Throws<FormatException>(() => _factory.CreateValue(input));
        }

        [Fact]
        public void CreateValue_InvalidDouble_ThrowsFormatException()
        {
            string input = "\"USD\" \"EUR\" abc 2024-05-01";

            Assert.Throws<FormatException>(() => _factory.CreateValue(input));
        }
    }
}