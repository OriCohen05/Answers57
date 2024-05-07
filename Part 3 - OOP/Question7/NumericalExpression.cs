using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Answers57
{
    public class NumericalExpression
    {
        private readonly long value;

        private const long MAX_VALUE = 999999999999;

        public NumericalExpression(long value)
        {
            if (value < 0 || value > MAX_VALUE)
            {
                throw new ArgumentOutOfRangeException("value", "Value must be between 0 and " + MAX_VALUE);
            }

            this.value = value;
        }

        public override string ToString()
        {
            return "The number " + value + " is:\n" +  NumberToWords(value);
        }

        public long GetValue()
        {
            return value;
        }

        private static string NumberToWords(long number)
        {
            if (number == 0)
            {
                return "Zero";
            }

            string[] numNames = { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            string[] tensNames = { "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            string[] groupNames = { "", "Thousand", "Million", "Billion", "Trillion" };

            string result = "";
            long remaining = number;

            for (int i = groupNames.Length - 1; i >= 0; i--)
            {
                long groupValue = remaining / (long)Math.Pow(1000, i);
                string groupWords = ConvertGroup(groupValue, numNames, tensNames);
                if (!string.IsNullOrEmpty(groupWords))
                {
                    result = groupWords + (i > 0 ? " " + groupNames[i] : "") + " " + result;
                }
                remaining %= (long)Math.Pow(1000, i);
            }

            result = ConvertGroup(remaining, numNames, tensNames) + " " + result;

            return result.Trim();
        }

        private static string ConvertGroup(long groupValue, string[] numNames, string[] tensNames)
        {
            string groupWords = "";
            if (groupValue > 0)
            {
                if (groupValue >= 100)
                {
                    groupWords = numNames[groupValue / 100 - 1] + " Hundred";
                }

                long remainingInGroup = groupValue % 100;
                if (remainingInGroup > 0)
                {
                    if (remainingInGroup < 10)
                    {
                        groupWords += (groupWords.Length > 0 ? " " : "") + numNames[remainingInGroup - 1];
                    }
                    else
                    {
                        groupWords += (groupWords.Length > 0 ? " " : "") + tensNames[remainingInGroup / 10 - 1];
                        if (remainingInGroup % 10 > 0)
                        {
                            groupWords += " " + numNames[remainingInGroup % 10 - 1];
                        }
                    }
                }
            }
            return groupWords;
        }

        /*
         Two options:
         1.The SumLetters function is like polymorphism in OOP
         Polymorphism allows methods with the same name to show different behaviors depending on the type of object they are called upon.
         2. The SumLetters function is a simple method overloading in the NumericalExpression class.
         */
        public static int SumLetters(NumericalExpression numExpr)
        {
            return SumLetters(numExpr.GetValue());
        }

        public static int SumLetters(long number)
        {
            string expression = NumberToWords(number);
            expression = expression.Replace(" ", String.Empty);
            return expression.Length;
        }
    }

}
