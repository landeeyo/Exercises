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
                var a = rnd.Next(10000);
                var b = rnd.Next(10000);

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

        [Test]
        public void TestTrimZeroesFromLeft()
        {
            Arithmetic arithmetic = new Arithmetic();
            
            string testSequence = "0003782397424";
            string properResult = "3782397424";
            string result = "";

            result = arithmetic.TrimZeroesFromLeft(testSequence);
            Assert.AreEqual(result, properResult);

            testSequence = "0237812";
            properResult = "237812";
            result = arithmetic.TrimZeroesFromLeft(testSequence);
            Assert.AreEqual(result, properResult);

            testSequence = "0000000021837423864647";
            properResult = "21837423864647";
            result = arithmetic.TrimZeroesFromLeft(testSequence);
            Assert.AreEqual(result, properResult);

            testSequence = "000000000000000000000004723864189364423";
            properResult = "4723864189364423";
            result = arithmetic.TrimZeroesFromLeft(testSequence);
            Assert.AreEqual(result, properResult);
        }
    }
}
