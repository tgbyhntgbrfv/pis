using System;

namespace ConsoleApp2
{
    public static class ArraySummator
    {
        
        public static double SumFirstNegativeAndLastPositive(int[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException(nameof(numbers));

            if (numbers.Length == 0)
                return 0;

            int? firstNegative = null;
            int? lastPositive = null;

            
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    firstNegative = numbers[i];
                    break;
                }
            }

            
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (numbers[i] > 0)
                {
                    lastPositive = numbers[i];
                    break;
                }
            }

            // если хоть одного нет то 0
            if (firstNegative == null || lastPositive == null)
                return 0;

            return firstNegative.Value + lastPositive.Value;
        }
    }
}