using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class CountDivService
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

        public int GetDivCountSlow(int start, int end, int divisor)
        {
            var count = 0;

            for (decimal i = start; i <= end; i++)
            {
                if (i % divisor == 0)
                    count++;
            }
            return count;
        }

        public int GetDivCount(int start, int end, int divisor)
        {
            var count = (end / divisor) - (start / divisor);
            if (start % divisor == 0)
                count++;
            return count;
        }

        public int GetDivCountJava(int start, int end, int divisor)
        {
            return (end / divisor) - (start / divisor) + (start % divisor == 0 ? 1 : 0);
        }
    }

    [TestFixture]
    public class CountDivServiceTests
    {
        public CountDivService service = new CountDivService();

        [Test]
        public void GetDivCountTest1()
        {
            var start = 6;
            var end = 11;
            var divisor = 2;
            var expected = 3;
            Assert.AreEqual(expected, service.GetDivCount(start, end, divisor));
        }

        [Test]
        public void GetDivCountTest2()
        {
            var start = 1;
            var end = 1;
            var divisor = 11;
            var expected = 0;
            Assert.AreEqual(expected, service.GetDivCount(start, end, divisor));
        }
        
        [Test]
        public void GetDivCountTest3()
        {
            var start = 10;
            var end = 100;
            var divisor = 10;
            var expected = 10;
            Assert.AreEqual(expected, service.GetDivCount(start, end, divisor));
        }

        [Test]
        public void GetDivCountTest4()
        {
            var start = 10;
            var end = 1000;
            var divisor = 10;
            var expected = 100;
            Assert.AreEqual(expected, service.GetDivCount(start, end, divisor));
        }

        [Test]
        public void GetDivCountTest5()
        {
            var start = 1067;
            var end = 11000213;
            var divisor = 13;
            var expected = 846088;
            Assert.AreEqual(expected, service.GetDivCount(start, end, divisor));
        }

        [Test]
        public void GetDivCountTest6()
        {
            var start = 0;
            var end = 0;
            var divisor = 11;
            var expected = 1;
            Assert.AreEqual(expected, service.GetDivCount(start, end, divisor));
        }

        [Test]
        public void GetDivCountTest7()
        {
            var start = 10;
            var end = 10;
            var divisor = 5;
            var expected = 1;
            Assert.AreEqual(expected, service.GetDivCount(start, end, divisor));
        }

        [Test]
        public void GetDivCountTest8()
        {
            var start = 10;
            var end = 10;
            var divisor = 7;
            var expected = 0;
            Assert.AreEqual(expected, service.GetDivCount(start, end, divisor));
        }

        [Test]
        public void GetDivCountTest9()
        {
            var start = 11;
            var end = 345;
            var divisor = 17;
            var expected = 20;
            Assert.AreEqual(expected, service.GetDivCount(start, end, divisor));
        }
    }
}
