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
            a = TrimZeroesFromLeft(a);
            b = TrimZeroesFromLeft(b);
            int comparison = Compare(a, b);
            if (comparison == 0)
                return "0";
            string smaller = "";
            string greater = "";
            if (comparison == -1)
            {
                smaller = a;
                greater = b;
            }
            else if (comparison == 1)
            {
                greater = a;
                smaller = b;
            }
            int subtract = 0;
            int remember = 0;
            string ret = "";
            string retR = "";
            for (int i = 0; i < greater.Length; i++)
            {
                if (i < smaller.Length)
                {
                    if (CharToInt(greater[greater.Length - i - 1]) + remember < CharToInt(smaller[smaller.Length - i - 1]))
                    {
                        subtract = CharToInt(greater[greater.Length - i - 1]) + remember + 10 - CharToInt(smaller[smaller.Length - i - 1]);
                        remember = -1;
                    }
                    else
                    {
                        subtract = CharToInt(greater[greater.Length - i - 1]) + remember - CharToInt(smaller[smaller.Length - i - 1]);
                        remember = 0;
                    }
                }
                else
                {
                    subtract = CharToInt(greater[greater.Length - i - 1]) + remember;
                    if (subtract >= 0)
                        remember = 0;
                    else
                        subtract = 10 + subtract;
                }
                retR += IntToChar(subtract);
            }
            for (int i = 1; i <= retR.Length; i++)
                ret += retR[retR.Length - i];
            return TrimZeroesFromLeft(ret);
        }

        public string Multiply(string a, string b)
        {
            a = TrimZeroesFromLeft(a);
            b = TrimZeroesFromLeft(b);
            if (Compare(b, "0") == -1 || Compare(b, "0") == 0)
                return "0";
            string sum = "0";
            //Iteration by digits of b
            for (int i = 1; i <= b.Length; i++)
            {
                //Select i-th digit in reverse order
                var tmp = b[b.Length - i];
                //Multiplicating a by i-th digit of b
                var multiplicated = MultiplySlow(a, tmp.ToString());
                //Multiplicating by 10^(i-1)
                for (int j = 0; j < i - 1; j++)
                    multiplicated += "0";
                //Adding calculated number to final result
                sum = Add(sum, multiplicated);
            }
            return sum;
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
            while (i < s.Length && s[i] == '0')
                i++;
            if (i > 0)
                return s.Substring(i - 1);
            else
                return s;
        }

        private int Compare(string a, string b)
        {
            a = TrimZeroesFromLeft(a);
            b = TrimZeroesFromLeft(b);
            if (a.Length == b.Length)
            {
                if (a == b)
                    return 0;
                else
                {
                    for (int i = 0; i < a.Length; i++)
                    {
                        if (a[i] < b[i])
                            return -1;
                        if (a[i] > b[i])
                            return 1;
                    }
                }
            }
            else //If length of numbers differs
            {
                string shorter = Shorter(a, b);
                string longer = Longer(a, b);
                //When a is shorter then we return a<b
                if (shorter == a)
                    return -1;
                //If b is shorter then we return a>b
                else
                    return 1;
            }
            return 0;
        }

        /// <summary>
        /// Function is multiplying by addition
        /// </summary>
        /// <param name="a">Number a</param>
        /// <param name="b">Number b</param>
        /// <returns>a*b</returns>
        private string MultiplySlow(string a, string b)
        {
            a = TrimZeroesFromLeft(a);
            b = TrimZeroesFromLeft(b);
            if (Compare(b, "0") == -1 || Compare(b, "0") == 0)
                return "0";
            string tmp = a;
            string i = "1";
            while (true)
            {
                if (Compare(i, b) != -1)
                    return tmp;
                i = Add(i, "1");
                tmp = Add(tmp, a);
            }
        }

        #endregion
    }
}