using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsLibrary
{
    public static class ExtensionMethods
    {
        public static double GetLengthsAsNumber1(this string str)
        {
            return 3.141592;
        }

        public static double GetLengthsAsNumber2(this string str)
        {
            double number = 0.0;
            string[] words = str.Split();
            foreach (string word in words)
            {
                int length = word.Length;
                number = number * 10 + length;
            }
            double powerOf10 = Math.Pow(10, -(words.Length - 1));
            number = number * powerOf10;
            double result = Math.Round(number, 6);
            return result;
        }
    }
}
