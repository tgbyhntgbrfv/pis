using Xunit;
using ConsoleApp2;

namespace ConsoleApp2.Tests
{
    public class ValueTests
    {
        [Fact]
        public void Course_PositiveValue_SetsCorrectly()
        {
            var v = new Value();
            v.Course = 100.5;
            Assert.Equal(100.5, v.Course);
        }

        [Fact]
        public void Course_Zero_DefaultsTo7()
        {
            var v = new Value();
            v.Course = 0;
            Assert.Equal(7, v.Course);
        }

        [Fact]
        public void Course_Negative_DefaultsTo7()
        {
            var v = new Value();
            v.Course = -5;
            Assert.Equal(7, v.Course);
        }

        [Fact]
        public void Value_BaseName_IsKursValut()
        {
            var v = new Value();
            Assert.Equal("курс валют", v.BaseName);
        }
    }

    public class BankAndCryptoValueTests
    {
        [Fact]
        public void Bank_BaseName_IsBank()
        {
            var b = new Bank();
            Assert.Equal("банк", b.BaseName);
        }

        [Fact]
        public void CryptoValue_BaseName_IsKriptoValuta()
        {
            var c = new CryptoValue();
            Assert.Equal("криптовалюта", c.BaseName);
        }

        [Fact]
        public void Bank_InheritsFromBase()
        {
            Assert.IsAssignableFrom<Base>(new Bank());
        }

        [Fact]
        public void CryptoValue_InheritsFromBase()
        {
            Assert.IsAssignableFrom<Base>(new CryptoValue());
        }

        [Fact]
        public void Value_InheritsFromBase()
        {
            Assert.IsAssignableFrom<Base>(new Value());
        }
    }
}