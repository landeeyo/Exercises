using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringMaths;
using NUnit.Framework;

namespace StringMaths.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestAddSmall()
        {
            Arithmetic arithmetic = new Arithmetic();
            Random rnd = new Random();
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine("Test no. " + i.ToString());
                var a = rnd.Next(int.MaxValue);
                var b = rnd.Next(int.MaxValue);

                Console.WriteLine("a: " + a.ToString());
                Console.WriteLine("b: " + b.ToString());

                var result = arithmetic.Add(a.ToString(), b.ToString());
                var properResult = (a + b).ToString();

                Console.WriteLine("Result: " + result);
                Console.WriteLine("Proper result: " + properResult);

                Assert.AreEqual(result, properResult);
            }
        }

        [Test]
        public void TestSubtractSmall()
        {
            Arithmetic arithmetic = new Arithmetic();
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Test no. " + i.ToString());
                var a = rnd.Next(int.MaxValue);
                var b = rnd.Next(10000);

                Console.WriteLine("a: " + a.ToString());
                Console.WriteLine("b: " + b.ToString());

                var result = arithmetic.Subtract(a.ToString(), b.ToString());
                var properResult = (a - b).ToString();

                Console.WriteLine("Result: " + result);
                Console.WriteLine("Proper result: " + properResult);

                Assert.AreEqual(result, properResult);
            }
        }

        [Test]
        public void TestMultiplySmall()
        {
            Arithmetic arithmetic = new Arithmetic();
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Test no. " + i.ToString());
                var a = rnd.Next(1000);
                var b = rnd.Next(1000);

                Console.WriteLine("a: " + a.ToString());
                Console.WriteLine("b: " + b.ToString());

                var result = arithmetic.Multiply(a.ToString(), b.ToString());
                var properResult = (a * b).ToString();

                Console.WriteLine("Result: " + result);
                Console.WriteLine("Proper result: " + properResult);

                Assert.AreEqual(result, properResult);
            }
        }

        [Test]
        public void TestDivideSmall()
        {
            Arithmetic arithmetic = new Arithmetic();
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Test no. " + i.ToString());
                var a = rnd.Next(int.MaxValue);
                var b = rnd.Next(int.MaxValue) + 1;

                Console.WriteLine("a: " + a.ToString());
                Console.WriteLine("b: " + b.ToString());

                var result = arithmetic.Divide(a.ToString(), b.ToString());
                var properResult = (a / b).ToString();

                Console.WriteLine("Result: " + result);
                Console.WriteLine("Proper result: " + properResult);

                Assert.AreEqual(result, properResult);
            }
        }
    }
}
