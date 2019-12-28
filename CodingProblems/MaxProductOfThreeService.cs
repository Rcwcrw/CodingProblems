using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class MaxProductOfThreeService
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

        public int GetMaxProductSlow(int[] arr)
        {
            //set maxValue to -1000^3
            var maxValue = -1000000000;
            var testValue = 0;
            //for loop 
            for (int i = 0; i < arr.Length - 2; i++)
            {
                for (int j = i + 1; j < arr.Length - 1; j++)
                {
                    for (int k = j + 1; k < arr.Length; k++)
                    {
                        //Find product
                        testValue = arr[i] * arr[j] * arr[k];
                        //if greater than current set to max
                        if (testValue > maxValue)
                            maxValue = testValue;
                    }
                }
            }

            //return maxValue
            return maxValue;
        }

        public int GetMaxProduct(int[] arr)
        {
            if (arr.Length == 3)
                return arr[0] * arr[1] * arr[2];
            Array.Sort(arr);

            //set maxValue to -1000^3
            var maxValue = arr[0] * arr[1] * arr[2];

            if (arr.Length > 3)
            {
                maxValue = Math.Max(maxValue, arr[0] * arr[1] * arr[arr.Length - 1]);
                maxValue = Math.Max(maxValue, arr[0] * arr[2] * arr[arr.Length - 1]);
                maxValue = Math.Max(maxValue, arr[1] * arr[2] * arr[arr.Length - 1]);
            }

            if (arr.Length > 4)
            {
                maxValue = Math.Max(maxValue, arr[0] * arr[1] * arr[arr.Length - 2]);
                maxValue = Math.Max(maxValue, arr[0] * arr[2] * arr[arr.Length - 2]);
                maxValue = Math.Max(maxValue, arr[1] * arr[2] * arr[arr.Length - 2]);
                maxValue = Math.Max(maxValue, arr[2] * arr[arr.Length - 2] * arr[arr.Length - 1]);
            }

            if (arr.Length > 5)
            {

                maxValue = Math.Max(maxValue, arr[0] * arr[1] * arr[arr.Length - 3]);
                maxValue = Math.Max(maxValue, arr[0] * arr[2] * arr[arr.Length - 3]);
                maxValue = Math.Max(maxValue, arr[0] * arr[arr.Length - 3] * arr[arr.Length - 2]);
                maxValue = Math.Max(maxValue, arr[0] * arr[arr.Length - 3] * arr[arr.Length - 1]);                
                maxValue = Math.Max(maxValue, arr[1] * arr[2] * arr[arr.Length - 3]);
                maxValue = Math.Max(maxValue, arr[1] * arr[arr.Length - 3] * arr[arr.Length - 1]);
                maxValue = Math.Max(maxValue, arr[1] * arr[arr.Length - 3] * arr[arr.Length - 2]);
                maxValue = Math.Max(maxValue, arr[2] * arr[arr.Length - 3] * arr[arr.Length - 1]);
                maxValue = Math.Max(maxValue, arr[2] * arr[arr.Length - 3] * arr[arr.Length - 2]);                
                maxValue = Math.Max(maxValue, arr[arr.Length - 3] * arr[arr.Length - 2] * arr[arr.Length - 1]);

            }

            return maxValue;
        }
    }

    [TestFixture]
    public class MaxProductOfThreeServiceTests
    {
        public MaxProductOfThreeService service = new MaxProductOfThreeService();

        [Test]
        public void GetMaxProductTest1()
        {
            var given = new int[] { -3, 1, 2, -2, 5, 6 };
            var expected = 60;
            Assert.AreEqual(expected, service.GetMaxProduct(given));
        }

        [Test]
        public void GetMaxProductTest2()
        {
            var given = new int[] { 4, 5, 1, 0 };
            var expected = 20;
            Assert.AreEqual(expected, service.GetMaxProduct(given));
        }
    }
}
