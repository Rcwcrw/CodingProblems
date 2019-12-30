using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class MaxDoubleSliceService
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
            //        Console.WriteLine($"Answer: {GetMaxDoubleSlice(Convert.ToInt32(line))}");
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
            //        var outputArray = GetMaxDoubleSlice(arr, Convert.ToInt32(line2));
            //        string output = outputArray[0].ToString();
            //        for (int i = 1; i < arr.Length; i++)
            //        {
            //            output = output + ", " + outputArray[i].ToString();
            //        }
            //        Console.WriteLine($"Output: {output}");
            //    }
            //}
        }

        public int GetMaxDoubleSlice(int[] arr)
        {
            var head = new int[arr.Length];
            var tail = new int[arr.Length];

            for (int i = 1; i < arr.Length; i++)
            {
                head[i] = Math.Max(0, head[i - 1] + arr[i]);
            }

            for (int i = arr.Length - 2; i > 0; i--)
            {
                tail[i] = Math.Max(0, tail[i + 1] + arr[i]);
            }

            int max = 0;

            for (int i = 1; i < arr.Length - 1; i++)
            {
                max = Math.Max(max, head[i - 1] + tail[i + 1]);
            }
            return max;
        }

        public int GetMaxDoubleSliceSlow(int[] arr)
        {
            var x = 0;
            var y = 1;
            var z = 2;
            var maxSum = 0;

            while (x < y && y < z && z < arr.Length)
            {
                var slice1 = GetSliceSum(x, y, arr);
                var slice2 = GetSliceSum(y, z, arr);

                maxSum = Math.Max(maxSum, (slice1 + slice2));

                if (z < arr.Length - 1)
                    z++;
                else if (y < z - 1)
                {
                    y++;
                    z = y + 1;
                }
                else if (x < y - 1)
                {
                    x++;
                    y = x + 1;
                }
                else
                    break;
            }
            return maxSum;
        }

        private int GetSliceSum(int x, int y, int[] arr)
        {
            var sum = 0;
            for (int i = x + 1; i < y; i++)
            {
                sum += arr[i];
            }

            return sum;
        }
    }

    [TestFixture]
    public class MaxDoubleSliceServiceTests
    {
        public MaxDoubleSliceService service = new MaxDoubleSliceService();

        [Test]
        public void MaxDoubleSliceServiceTest1()
        {
            var given = new int[] { 3, 2, 6, -1, 4, 5, -1, 2 };
            var expected = 17;
            Assert.AreEqual(expected, service.GetMaxDoubleSlice(given));
        }

        [Test]
        public void MaxDoubleSliceServiceTest2()
        {
            var given = new int[] { 3, 2, 6, -1, 4, 5, -1, 2 };
            var expected = 17;
            Assert.AreEqual(expected, service.GetMaxDoubleSlice(given));
        }

        [Test]
        public void MaxDoubleSliceServiceTest3()
        {
            var given = new int[] { 3, 2, 6, -1, 4, 5, -1, 2 };
            var expected = 17;
            Assert.AreEqual(expected, service.GetMaxDoubleSlice(given));
        }
    }
}
