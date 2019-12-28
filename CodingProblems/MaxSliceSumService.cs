using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class MaxSliceSumService
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
            //        var outputArray = GetMaxSliceSum(arr, Convert.ToInt32(line2));
            //        string output = outputArray[0].ToString();
            //        for (int i = 1; i < arr.Length; i++)
            //        {
            //            output = output + ", " + outputArray[i].ToString();
            //        }
            //        Console.WriteLine($"Output: {output}");
            //    }
            //}
        }
        
        public int GetMaxSliceSumSlow(int[] arr)
        {
            var maxSum = int.MinValue;
            var currentSum = int.MinValue;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                currentSum = arr[i];
                if (currentSum > maxSum)
                    maxSum = currentSum;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    currentSum += arr[j];
                    if (currentSum > maxSum)
                        maxSum = currentSum;
                }
            }

            if (arr[arr.Length - 1] > maxSum)
                maxSum = arr[arr.Length - 1];

            return maxSum;
        }

        public int GetMaxSliceSum(int[] arr)
        {
            var maxSum = arr[0];
            var maxSumEndingHere = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                maxSumEndingHere = Math.Max(arr[i], maxSumEndingHere + arr[i]);
                maxSum = Math.Max(maxSum, maxSumEndingHere);
            }

            return maxSum;
        }
    }

    [TestFixture]
    public class MaxSliceSumServiceTests
    {
        public MaxSliceSumService service = new MaxSliceSumService();

        [Test]
        public void MaxSliceSumServiceTest6()
        {
            var given = new int[] { 2, 3, 2, -1, -1, -1, 1, -1 };
            var expected = 7;
            Assert.AreEqual(expected, service.GetMaxSliceSum(given));
        }

        [Test]
        public void MaxSliceSumServiceTest5()
        {
            var given = new int[] { -6, 3, 2, -6, 4, 0 };
            var expected = 5;
            Assert.AreEqual(expected, service.GetMaxSliceSum(given));
        }

        [Test]
        public void MaxSliceSumServiceTest1()
        {
            var given = new int[] { 3, 2, -6, 4, 0 };
            var expected = 5;
            Assert.AreEqual(expected, service.GetMaxSliceSum(given));
        }

        [Test]
        public void MaxSliceSumServiceTest2()
        {
            var given = new int[] { -10 };
            var expected = -10;

            Assert.AreEqual(expected, service.GetMaxSliceSum(given));
        }

        [Test]
        public void MaxSliceSumServiceTest3()
        {
            var given = new int[] { -1, 1 };
            var expected = 1;

            Assert.AreEqual(expected, service.GetMaxSliceSum(given));
        }

        [Test]
        public void MaxSliceSumServiceTest4()
        {
            var given = new int[] { 1, 3, -5, 3, 7, 14, 29 };
            var expected = 53;

            Assert.AreEqual(expected, service.GetMaxSliceSum(given));
        }        
    }
}
