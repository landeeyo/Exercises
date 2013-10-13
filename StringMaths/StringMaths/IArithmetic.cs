using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringMaths
{
    /// <summary>
    /// Interface of arithmetic library
    /// </summary>
    interface IArithmetic
    {
        string Add(string a, string b);
        string Subtract(string a, string b);
        string Multiply(string a, string b);
        string Divide(string a, string b);
        string TrimZeroesFromLeft(string s);
    }
}
