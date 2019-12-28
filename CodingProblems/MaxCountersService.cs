using System;
using NUnit.Framework;

namespace MergeSort
{
    public class MaxCountersService
    {
        public void ConsoleRun()
        {
            //Array
            var array = string.Empty;
            while (array.ToLower() != "exit")
            {
                Console.WriteLine("Enter an array: ");
                array = Console.ReadLine();
                if (array == "exit")
                    break;
                Console.WriteLine("Enter number of times to shift: ");
                var line2 = Console.ReadLine();
                if (line2 == "exit")
                    break;
                else
                {
                    int[] arr = Array.ConvertAll(array.Split(" "), int.Parse);
                    var outputArray = GetCounterValues(arr, Convert.ToInt32(line2));
                    string output = outputArray[0].ToString();
                    for (int i = 1; i < outputArray.Length; i++)
                    {
                        output = output + ", " + outputArray[i].ToString();
                    }
                    Console.WriteLine($"Output: {output}");
                }
            }
        }

        public int[] GetCounterValues(int[] arr, int numberOfCounters)
        {
            var counterArray = new int[numberOfCounters];
            var maxCounterValue = 0;
            var effectiveMaxCounterValue = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > numberOfCounters)
                {
                    effectiveMaxCounterValue = maxCounterValue;
                }
                else
                {
                    counterArray[arr[i] - 1] = Math.Max(counterArray[arr[i] - 1], effectiveMaxCounterValue) + 1;
                    if (counterArray[arr[i] - 1] > maxCounterValue)
                        maxCounterValue = counterArray[arr[i] - 1];
                }
            }

            for (int y = 0; y < counterArray.Length; y++)
                counterArray[y] = Math.Max(counterArray[y], effectiveMaxCounterValue);

            return counterArray;
        }

        public int[] GetCounterValues2(int[] arr, int numberOfCounters)
        {
            int[] counterArray = new int[numberOfCounters];
            int maxCounterValue = 0;
            int effectivMaxCounter = 0;

            for (int x = 0; x < arr.Length; x++)
            {
                if (arr[x] > numberOfCounters)
                {
                    effectivMaxCounter = maxCounterValue;
                }
                else
                {
                    int index = arr[x] - 1;
                    counterArray[index] = counterArray[index] < effectivMaxCounter ? effectivMaxCounter + 1 : ++counterArray[index];
                    if (counterArray[index] > maxCounterValue)
                    {
                        maxCounterValue = counterArray[index];
                    }
                }

            }

            for (int y = 0; y < counterArray.Length; y++)
                counterArray[y] = counterArray[y] < effectivMaxCounter ? effectivMaxCounter : counterArray[y];

            return counterArray;
        }   
    }

    [TestFixture]
    public class MaxCountersServiceTests
    {
        public MaxCountersService service = new MaxCountersService();

        [Test]
        public void GetCounterValuesTest1()
        {
            var givenArray = new int[] { 3, 4, 4, 6, 1, 4, 4 };
            var expectedArray = new int[] { 3, 2, 2, 4, 2 }; ;
            Assert.AreEqual(expectedArray, service.GetCounterValues(givenArray, 5));
        }
    }
}
