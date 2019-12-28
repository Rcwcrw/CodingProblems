using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class TriangleService
    {
        public void ConsoleRun()
        {
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

        public int TriangleTripletExistsSlow(int[] arr)
        {
            for (int i = 0; i < arr.Length - 2; i++)
            {
                for (int j = i + 1; j < arr.Length - 1; j++)
                {
                    for (int k = j + 1; k < arr.Length; k++)
                    {
                        if (TestIfTriangle(arr[i], arr[j], arr[k]))
                            return 1;
                    }
                }
            }

            return 0;
        }

        public int TriangleTripletExists(int[] arr)
        {
            Array.Sort(arr);
            for (int i = 0; i < arr.Length - 2; i++)
            {                
                if (TestIfTriangle(arr[i], arr[i + 1], arr[i + 2]))
                    return 1;
            }

            return 0;
        }

        public bool TestIfTriangle(long v1, long v2, long v3)
        {
            return (v1 + v2 > v3);
        }
    }

    [TestFixture]
    public class TriangleServiceTests
    {
        public TriangleService service = new TriangleService();

        [Test]
        public void TriangleServiceTest1()
        {
            var given = new int[] { 10, 2, 5, 1, 8, 20 };
            var expected = 1;
            Assert.AreEqual(expected, service.TriangleTripletExists(given));
        }

        [Test]
        public void TriangleServiceTest2()
        {
            var given = new int[] { 10, 50, 5, 1 };
            var expected = 0;
            Assert.AreEqual(expected, service.TriangleTripletExists(given));
        }
        
        [Test]
        public void TriangleServiceTest3()
        {
            var given = new int[] { int.MaxValue - 2, int.MaxValue - 1, int.MaxValue };
            var expected = 1;
            Assert.AreEqual(expected, service.TriangleTripletExists(given));
        }
    }
}
