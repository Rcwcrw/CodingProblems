using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class MinPerimeterRectangleService
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
            //        Console.WriteLine($"Answer: {GetMinPerimeter(Convert.ToInt32(line))}");
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
            //        var outputArray = GetMinPerimeter(arr, Convert.ToInt32(line2));
            //        string output = outputArray[0].ToString();
            //        for (int i = 1; i < arr.Length; i++)
            //        {
            //            output = output + ", " + outputArray[i].ToString();
            //        }
            //        Console.WriteLine($"Output: {output}");
            //    }
            //}
        }

        public int GetMinPerimeter(int area)
        {
            var root = Math.Sqrt(area);

            if (root % 1 == 0)
                return Convert.ToInt32((root + root)) * 2;
            else
            {
                var factor1 = 1;
                var factor2 = area;

                var i = Convert.ToInt32(Math.Floor(root));
                for (; i > 0; i--)
                {
                    if (area % i == 0)
                    {
                        factor1 = i;
                        break;
                    }
                }

                factor2 = area / factor1;
                return (factor1 + factor2) * 2;
            }
        }
    }

    [TestFixture]
    public class MinPerimeterRectangleServiceTests
    {
        public MinPerimeterRectangleService service = new MinPerimeterRectangleService();

        [Test]
        public void MinPerimeterRectangleServiceTest1()
        {
            var given = 30;
            var expected = 22;
            Assert.AreEqual(expected, service.GetMinPerimeter(given));
        }

        [Test]
        public void MinPerimeterRectangleServiceTest2()
        {
            var given = 1;
            var expected = 4;

            Assert.AreEqual(expected, service.GetMinPerimeter(given));
        }

        [Test]
        public void MinPerimeterRectangleServiceTest3()
        {
            var given = 2;
            var expected = 6;

            Assert.AreEqual(expected, service.GetMinPerimeter(given));
        }

        [Test]
        public void MinPerimeterRectangleServiceTest4()
        {
            var given = 120000;
            var expected = 1390;
            Assert.AreEqual(expected, service.GetMinPerimeter(given));
        }
    }
}
