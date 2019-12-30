using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class SampleService
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

            ////Array
            //var array = string.Empty;
            //while (array.ToLower() != "exit")
            //{
            //    Console.WriteLine("Enter an array: ");
            //    array = Console.ReadLine();
            //    if (array == "exit")
            //        break;
            //    Console.WriteLine("Enter number of times to shift: ");
            //    var line2 = Console.ReadLine();
            //    if (line2 == "exit")
            //        break;
            //    else
            //    {
            //        int[] arr = Array.ConvertAll(array.Split(" "), int.Parse);
            //        var outputArray = MyMethod(arr, Convert.ToInt32(line2));
            //        string output = outputArray[0].ToString();
            //        for (int i = 1; i < arr.Length; i++)
            //        {
            //            output = output + ", " + outputArray[i].ToString();
            //        }
            //        Console.WriteLine($"Output: {output}");
            //    }
            //}
        }

        public int MyMethod(int v1)
        {
            return 0;
        }

        public int MyMethod(int[] arr, int v)
        {
            return 0;
        }
    }

    [TestFixture]
    public class SampleServiceTests
    {
        public SampleService service = new SampleService();

        [Test]
        public void SampleServiceTest1()
        {
            var given = 1;
            var expected = 0;
            Assert.AreEqual(expected, service.MyMethod(given));
        }

        [Test]
        public void SampleServiceTest2()
        {
            var given = 1;
            var expected = 0;

            Assert.AreEqual(expected, service.MyMethod(given));
        }

        [Test]
        public void SampleServiceTest3()
        {
            var given = 1;
            var expected = 0;
            Assert.AreEqual(expected, service.MyMethod(given));
        }
    }
}
