using System;
using Xunit;
using ConsoleApp2;

namespace ConsoleApp2.Tests
{
    public class FuncTests
    {
        
        [Fact]
        public void SumFirstNegativeAndLastPositive_TypicalArray_ReturnsCorrectSum()
        {
            
            int[] numbers = { 3, -5, 7, 2, -8, 4 };

            double result = ArraySummator.SumFirstNegativeAndLastPositive(numbers);

            Assert.Equal(-1, result);
        }

        [Fact]
        public void SumFirstNegativeAndLastPositive_OnlyOneNegativeAndOnePositive_ReturnsSum()
        {
            
            int[] numbers = { -10, 5 };

            double result = ArraySummator.SumFirstNegativeAndLastPositive(numbers);

            Assert.Equal(-5, result);
        }

        [Fact]
        public void SumFirstNegativeAndLastPositive_LastElementIsPositive()
        {
            
            int[] numbers = { 1, -2, 3, -4, 5 };

            double result = ArraySummator.SumFirstNegativeAndLastPositive(numbers);

            Assert.Equal(3, result);
        }

        [Fact]
        public void SumFirstNegativeAndLastPositive_FirstElementIsNegative()
        {
            
            int[] numbers = { -1, 2, 3 };

            double result = ArraySummator.SumFirstNegativeAndLastPositive(numbers);

            Assert.Equal(2, result);
        }

        [Fact]
        public void SumFirstNegativeAndLastPositive_SingleNegativeElement_ReturnsZero()
        {
            
            int[] numbers = { -5 };

            double result = ArraySummator.SumFirstNegativeAndLastPositive(numbers);

            Assert.Equal(0, result);
        }

        [Fact]
        public void SumFirstNegativeAndLastPositive_SinglePositiveElement_ReturnsZero()
        {
            
            int[] numbers = { 5 };

            double result = ArraySummator.SumFirstNegativeAndLastPositive(numbers);

            Assert.Equal(0, result);
        }

        [Fact]
        public void SumFirstNegativeAndLastPositive_EmptyArray_ReturnsZero()
        {
            int[] numbers = { };

            double result = ArraySummator.SumFirstNegativeAndLastPositive(numbers);

            Assert.Equal(0, result);
        }

        [Fact]
        public void SumFirstNegativeAndLastPositive_AllZeros_ReturnsZero()
        {
            
            int[] numbers = { 0, 0, 0 };

            double result = ArraySummator.SumFirstNegativeAndLastPositive(numbers);

            Assert.Equal(0, result);
        }

        [Fact]
        public void SumFirstNegativeAndLastPositive_ZeroIsIgnored()
        {
            
            int[] numbers = { 0, -3, 0, 0, 0, 7, 0 };

            double result = ArraySummator.SumFirstNegativeAndLastPositive(numbers);

            Assert.Equal(4, result);
        }

        [Fact]
        public void SumFirstNegativeAndLastPositive_OnlyPositiveElements_ReturnsZero()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            double result = ArraySummator.SumFirstNegativeAndLastPositive(numbers);

            Assert.Equal(0, result);
        }

        [Fact]
        public void SumFirstNegativeAndLastPositive_OnlyNegativeElements_ReturnsZero()
        {
            int[] numbers = { -1, -2, -3, -4, -5 };

            double result = ArraySummator.SumFirstNegativeAndLastPositive(numbers);

            Assert.Equal(0, result);
        }

        [Fact]
        public void SumFirstNegativeAndLastPositive_NullArray_ThrowsArgumentNullException()
        {
            int[]? numbers = null;

            Assert.Throws<ArgumentNullException>(
                () => ArraySummator.SumFirstNegativeAndLastPositive(numbers!));
        }

        [Fact]
        public void SumFirstNegativeAndLastPositive_LargeNumbers_ReturnsCorrectSum()
        {
            int[] numbers = { int.MaxValue, -100, int.MaxValue };

            double result = ArraySummator.SumFirstNegativeAndLastPositive(numbers);

            
            Assert.Equal(2147483547.0, result);
        }

        [Fact]
        public void SumFirstNegativeAndLastPositive_MultiplePositives_LastOneWins()
        {
            
            int[] numbers = { -1, 5, 10, 20, 30 };

            double result = ArraySummator.SumFirstNegativeAndLastPositive(numbers);

            Assert.Equal(29, result);
        }

        [Fact]
        public void SumFirstNegativeAndLastPositive_MultipleNegatives_FirstOneWins()
        {
            
            int[] numbers = { 10, -1, -5, -3, -2, 7 };

            double result = ArraySummator.SumFirstNegativeAndLastPositive(numbers);

            Assert.Equal(6, result);
        }

        [Fact]
        public void SumFirstNegativeAndLastPositive_NegativeBetweenPositives()
        {
            
            int[] numbers = { 1, 2, 3, -4, 5, 6, 7 };

            double result = ArraySummator.SumFirstNegativeAndLastPositive(numbers);

            Assert.Equal(3, result);
        }

        [Theory]
        [InlineData(new[] { 1, -2, 3 }, 1)]          
        [InlineData(new[] { -1, 2 }, 1)]             
        [InlineData(new[] { -5, -3, 10 }, 5)]        
        [InlineData(new[] { -1, 0, 0, 0, 5 }, 4)]    
        [InlineData(new[] { -1, 0, 0, 0, 0 }, 0)]    
        [InlineData(new[] { 0, 0, 0, 0, 5 }, 0)]     
        public void SumFirstNegativeAndLastPositive_VariousArrays_ReturnsExpected(int[] numbers, double expected)
        {
            double result = ArraySummator.SumFirstNegativeAndLastPositive(numbers);

            Assert.Equal(expected, result);
        }
    }
}