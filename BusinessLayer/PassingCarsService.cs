using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MergeSort
{
    public class PassingCarsService
    {
        public void ConsoleRun()
        {
            //Array
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

        public class Car
        {
            public int Direction { get; set; }

            public int Location { get; set; }
        }

        public int GetPairs(int[] arr)
        {
            var pairCount = 0;
            var oneCount = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 1)
                    oneCount++;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                    pairCount += oneCount;
                else
                    oneCount--;
                if (pairCount > 1000000000)
                    return -1;
            }

            return pairCount;
        }

        public int GetPairsFast(int[] arr)
        {
            var pairCount = 0;
            var zeroCount = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                    zeroCount++;
                else if (zeroCount > 0)
                    pairCount += zeroCount;
                if (pairCount > 1000000000)
                    return -1;
            }

            return pairCount;
        }

        public int GetPairsSlow2(int[] arr)
        {
            var hash = new HashSet<Car>();
            var pairCount = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                hash.Add(new Car()
                {
                    Direction = arr[i],
                    Location = i
                });
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                    pairCount += hash.Count(x => x.Location > i && x.Direction == 1);
            }

            return pairCount > 1000000000 ? -1 : pairCount;
        }

        public int GetPairsSlow(int[] arr)
        {
            var pairCount = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == 0 && arr[j] == 1)
                    {
                        pairCount++;
                    }
                }
            }

            return pairCount > 1000000000 ? -1 : pairCount;
        }
    }

    [TestFixture]
    public class PassingCarsServiceTests
    {
        public PassingCarsService service = new PassingCarsService();

        [Test]
        public void GetPairsTest1()
        {
            var givenArray = new int[] { 0, 1, 0, 1, 1 };
            var expectedArray = 5;
            Assert.AreEqual(expectedArray, service.GetPairs(givenArray));
        }

        [Test]
        public void GetPairsTest2()
        {
            var givenArray = new int[] { 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0 }; ;
            var expectedArray = 13; 

            Assert.AreEqual(expectedArray, service.GetPairs(givenArray));
        }
    }
}
