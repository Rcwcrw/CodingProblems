using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class MinAvgTwoSliceService
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
            //        var outputArray = GetMinStartingPoint(arr, Convert.ToInt32(line2));
            //        string output = outputArray[0].ToString();
            //        for (int i = 1; i < arr.Length; i++)
            //        {
            //            output = output + ", " + outputArray[i].ToString();
            //        }
            //        Console.WriteLine($"Output: {output}");
            //    }
            //}
        }

        public int GetMinStartingPoint(int[] arr)
        {
            var minStart = 0;
            decimal currentAverage = 10001;
            decimal minAverage = 10001;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                currentAverage = (decimal) (arr[i] + arr[i+1]) / 2;
                if (currentAverage < minAverage)
                {
                    minStart = i;
                    minAverage = currentAverage;
                }

                if (i < arr.Length - 2)
                {
                    currentAverage = (decimal)(arr[i] + arr[i + 1] + arr[i + 2]) / 3;
                    if (currentAverage < minAverage)
                    {
                        minStart = i;
                        minAverage = currentAverage;
                    }
                }
            }
            return minStart;
        }

        public int GetMinStartingPointSlow(int[] arr)
        {
            var minStart = 0;
            decimal currentAverage = 10000;
            decimal minAverage = 10000;

            var prefixSum = new int[arr.Length];
            prefixSum[0] = arr[0];

            //Create and populate prefix sum array
            for (int i = 1; i < arr.Length; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + arr[i];
            }

            //loop through prefix sum, starting at 1, divide by i + 1.
            for (int i = 1; i < prefixSum.Length; i++)
            {
                currentAverage = (decimal) prefixSum[i] / (i + 1);
                //if currentAverage < minAverage then minStart equals 0?
                //minAverage = min of currentAverage vs minAverage
                if (currentAverage < minAverage)
                {
                    minAverage = currentAverage;
                }
            }

            //loop through prefix sum, starting at 0, 
            for (int i = 0; i < prefixSum.Length - 2; i++)
            {
                //inner loop through prefix sum starting at 2
                for (int j = i + 2; j < prefixSum.Length; j++)
                {
                    //currentAverage = sum j minus sum i, divide by j - i
                    currentAverage = ((decimal) prefixSum[j] - prefixSum[i]) / (j - i);
                    //if currentAverage < minAverage then minStart equals i+1?
                    //minAverage = min of currentAverage vs minAverage
                    if (currentAverage < minAverage)
                    {
                        minStart = i + 1;
                        minAverage = currentAverage;
                    }
                }
            }

            //return minStart;
            return minStart;
        }
    }

    [TestFixture]
    public class MinAvgTwoSliceServiceTests
    {
        public MinAvgTwoSliceService service = new MinAvgTwoSliceService();

        [Test]
        public void GetMinStartingPointTest1()
        {
            var givenArray = new int[] { 4, 2, 2, 5, 1, 5, 8 };
            var expectedArray = 1;
            Assert.AreEqual(expectedArray, service.GetMinStartingPoint(givenArray));
        }
    }
}
