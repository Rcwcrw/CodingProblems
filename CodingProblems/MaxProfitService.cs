using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class MaxProfitService
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
            //        var outputArray = GetMaxProfit(arr, Convert.ToInt32(line2));
            //        string output = outputArray[0].ToString();
            //        for (int i = 1; i < arr.Length; i++)
            //        {
            //            output = output + ", " + outputArray[i].ToString();
            //        }
            //        Console.WriteLine($"Output: {output}");
            //    }
            //}
        }

        public int GetMaxProfitSlow(int[] arr)
        {
            //declare maxProfit = 0
            var maxProfit = 0;
            int currentProfit;
            //go through arr with i ending at n - 1
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    currentProfit = (arr[j] - arr[i]);
                    maxProfit = currentProfit > maxProfit ? currentProfit : maxProfit;
                }
            }

            return maxProfit;
        }

        public int GetMaxProfit(int[] arr)
        {

            //maxDifference
            //minValue
            var maxDifference = 0;
            var minValue = 200000;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < minValue)
                    minValue = arr[i];

                maxDifference = Math.Max(maxDifference, arr[i] - minValue);
            }

            return maxDifference;
        }
    }

    [TestFixture]
    public class MaxProfitServiceTests
    {
        public MaxProfitService service = new MaxProfitService();

        [Test]
        public void MaxProfitServiceTest1()
        {
            var given = new int[] { 23171, 21011, 21123, 21366, 21013, 21367 };
            var expected = 356;
            Assert.AreEqual(expected, service.GetMaxProfit(given));
        }

        [Test]
        public void MaxProfitServiceTest2()
        {
            var given = new int[] { 21171, 21011, 21123, 21366, 21013, 21367 };
            var expected = 356;
            Assert.AreEqual(expected, service.GetMaxProfit(given));
        }
    }
}
