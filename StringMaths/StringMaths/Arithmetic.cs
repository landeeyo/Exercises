using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringMaths
{
    /// <summary>
    /// Implementation of arithmetic library
    /// </summary>
    public class Arithmetic : IArithmetic
    {
        #region IArithmetic methods

        public string Add(string a, string b)
        {
            //Triming unwanted zeroes
            a = TrimZeroesFromLeft(a);
            b = TrimZeroesFromLeft(b);
            string shorter, longer;
            //Setting up shorter and longer args
            if (a.Length == b.Length)
            {
                shorter = a;
                longer = b;
            }
            else
            {
                shorter = Shorter(a, b);
                longer = Longer(a, b);
            }
            int sum = 0;
            int remember = 0;
            string resultRight = "";
            string result = "";
            for (int i = 0; i <= longer.Length; i++)
            {
                //If we've got two digits then we're adding them and remember from previous addition
                if (i < shorter.Length)
                    sum = CharToInt(longer[longer.Length - i - 1]) + CharToInt(shorter[shorter.Length - i - 1]) + remember;
                else if (i < longer.Length) //If we've got one digit then we add only remember
                    sum = CharToInt(longer[longer.Length - i - 1]) + remember;
                else if (i == longer.Length) //At last we add remember
                    sum = remember;
                if (sum >= 10) //If sum is over 10 then we set remember and decrease sum
                {
                    remember = 1;
                    sum = sum % 10;
                }
                else //Else we must reset remember
                    remember = 0;
                //Increase result
                resultRight += IntToChar(sum);
            }
            //Reversing result
            for (int i = 1; i <= resultRight.Length; i++)
                result += resultRight[resultRight.Length - i];
            return TrimZeroesFromLeft(result);
        }

        public string Subtract(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string Multiply(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string Divide(string a, string b)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Helpers

        private int CharToInt(char c)
        {
            return (int)(c - '0');
        }

        private char IntToChar(int i)
        {
            return (char)('0' + i);
        }

        private string Longer(string a, string b)
        {
            if (a.Length > b.Length)
                return a;
            else
                return b;
        }

        private string Shorter(string a, string b)
        {
            if (a.Length < b.Length)
                return a;
            else
                return b;
        }

        public string TrimZeroesFromLeft(string s)
        {
            int i = 0;
            while (s[i++] == '0')
                ;
            return s.Substring(i - 1);
        }

        #endregion
    }
}