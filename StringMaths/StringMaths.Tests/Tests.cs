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
        #region Test methods

        [Test]
        public void TestAddSmall()
        {
            Arithmetic arithmetic = new Arithmetic();
            Random rnd = new Random();
            for (int i = 1; i <= 1000; i++)
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
            for (int i = 0; i < 1000; i++)
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
            for (int i = 0; i < 1000; i++)
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
            for (int i = 0; i < 1000; i++)
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

        [Test]
        public void TestAddLarge()
        {
            Arithmetic arithmetic = new Arithmetic();

            var a = "76428734608769874623948746958274356023479562384756091826437125638218072312947238946275478523479659287436598237569462347892";
            var b = "54678353985762587643958374563982647327053784563789456302847563784560387456308745627356028746507834560937456093767523672346";
            var properResult = "131107088594532462267907121522257003350533346948545548129284689422778459769255984573631507269987493848374054331336986020238";

            TestOperation(a, b, arithmetic.Add, properResult);
        }

        [Test]
        public void TestSubtractLarge()
        {
            Arithmetic arithmetic = new Arithmetic();

            var a = "76428734608769874623948746958274356023479562384756091826437125638218072312947238946275478523479659287436598237569462347892";
            var b = "54678353985762587643958374563982647327053784563789456302847563784560387456308745627356028746507834560937456093767523672346";
            var properResult = "21750380623007286979990372394291708696425777820966635523589561853657684856638493318919449776971824726499142143801938675546";

            TestOperation(a, b, arithmetic.Subtract, properResult);
        }

        [Test]
        public void TestMultiplyLarge()
        {
            Arithmetic arithmetic = new Arithmetic();

            var a = "76428734608769874623948746958274356023479562384756091826437125638218072312947238946275478523479659287436598237569462347892";
            var b = "54678353985762587643958374563982647327053784563789456302847563784560387456308745627356028746507834560937456093767523672346";
            var properResult = "4178997405622223298748360045707025146029148807903667430410184246240606496443886898877483460213567342811883826015964187325502542111522688009100621595483949717785283636477716016066270051661609516530912665652107136039058196226546192474843271794632";

            TestOperation(a, b, arithmetic.Multiply, properResult);
        }

        [Test]
        public void TestDivideLarge()
        {
            Arithmetic arithmetic = new Arithmetic();

            var a = "76428734608769874623948746958274356023479562384756091826437125638218072312947238946275478523479659287436598237569462347892";
            var b = "54678353985762587643958374563982647327053784563789456302847563784560387456308745627356028746507834560937456093767523672346";
            var properResult = "1";

            TestOperation(a, b, arithmetic.Divide, properResult);
        }

        #endregion

        #region Helpers

        delegate string ArithmeticOperation(string a, string b);

        private void TestOperation(string a, string b, ArithmeticOperation arithmeticOperation, string properResult)
        {
            Console.WriteLine("a: " + a.ToString());
            Console.WriteLine("b: " + b.ToString());

            var result = arithmeticOperation(a.ToString(), b.ToString());

            Console.WriteLine("Result: " + result);
            Console.WriteLine("Proper result: " + properResult);

            Assert.AreEqual(result, properResult);
        }

        #endregion
    }
}
