using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class GeneInterviewService : IBaseService
    {
        public void ConsoleRun()
        {
            Console.WriteLine("Hello test:");
            var str = ReverseString("Hello");
            Console.WriteLine(str);

            var sumOfDigits = SumOfDigits(102);
            Console.WriteLine(sumOfDigits);

            //Reverse string
            //example <functionName>("Hello"); returns "olleH"

            //Sum of Digits
            //example <functionName>(102); returns 3
        }

        public string ReverseString(string str)
        {
            var returnStr = str.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                returnStr[i] = str[str.Length - (i + 1)];
            }

            return string.Join("", returnStr);
        }

        public int SumOfDigits(int sum)
        {
            var digits = sum.ToString().ToCharArray();
            var sumOfDigits = 0;

            for (int i = 0; i < digits.Length; i++)
            {
                sumOfDigits += Convert.ToInt32(digits[i].ToString());
            }

            return sumOfDigits;
        }
    }



    [TestFixture]
    public class GeneInterviewSeriveTests
    {
        public GeneInterviewService service = new GeneInterviewService();

        [Test]
        public void GeneInterviewSeriveTest1()
        {
            var given = "Hello";
            var expected = "olleH";
            Assert.AreEqual(expected, service.ReverseString(given));
        }

        [Test]
        public void GeneInterviewSeriveTest2()
        {
            var given = 102;
            var expected = 3;

            Assert.AreEqual(expected, service.SumOfDigits(given));
        }

        [Test]
        public void GeneInterviewSeriveTest3()
        {
            var given = 1;
            var expected = 1;
            Assert.AreEqual(expected, service.SumOfDigits(given));
        }
    }
}
