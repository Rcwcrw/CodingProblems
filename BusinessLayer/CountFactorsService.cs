using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class CountFactorsService
    {
        public void ConsoleRun()
        {
            ////Int
            //var line = string.Empty;
            //while (line.ToLower() != "exit")
            //{
            //    Console.WriteLine("Enter a number: ");
            //    line = Console.ReadLine();
            //    if (line == "exit")
            //        break;
            //    else
            //    {
            //        Console.WriteLine($"Answer: {MyMethod(Convert.ToInt32(line))}");
            //    }
            //}
        }

        public int GetFactorCount(int product)
        {
            if (product == 1)
                return 1;

            var factorCount = 0;
            var endpoint = Math.Floor(Math.Sqrt(product));
            var perfectSquare = 0;
            if (Math.Sqrt(product) % 1 == 0)
                perfectSquare++;

            for (int i = 1; i <= endpoint; i++)
            {
                if (product % i == 0)
                {
                    factorCount++;
                }
            }

            return (factorCount * 2) - perfectSquare;
        }
    }

    [TestFixture]
    public class CountFactorsServiceTests
    {
        public CountFactorsService service = new CountFactorsService();

        [Test]
        public void CountFactorsServiceTest1()
        {
            var given = 24;
            var expected = 8;
            Assert.AreEqual(expected, service.GetFactorCount(given));
        }

        [Test]
        public void CountFactorsServiceTest2()
        {
            var given = 27043111;
            var expected = 4;

            Assert.AreEqual(expected, service.GetFactorCount(given));
        }

        [Test]
        public void CountFactorsServiceTest3()
        {
            var given = 4;
            var expected = 3;
            Assert.AreEqual(expected, service.GetFactorCount(given));
        }

        [Test]
        public void CountFactorsServiceTest4()
        {
            var given = 16;
            var expected = 5;
            Assert.AreEqual(expected, service.GetFactorCount(given));
        }

        [Test]
        public void CountFactorsServiceTest5()
        {
            var given = 780291637;
            var expected = 2;
            Assert.AreEqual(expected, service.GetFactorCount(given));
        }
        
        [Test]
        public void CountFactorsServiceTest6()
        {
            var given = 2147483647;
            var expected = 2;
            Assert.AreEqual(expected, service.GetFactorCount(given));
        }
    }
}
