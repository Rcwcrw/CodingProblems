using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MergeSort
{
    public class MissingIntegerService
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
                else
                {
                    int[] arr = Array.ConvertAll(array.Split(" "), int.Parse);
                    var output = GetMissingInteger(arr);
                    Console.WriteLine($"Output: {output}");
                }
            }
        }

        public int GetMissingInteger(int[] arr)
        {
            var returnValue = 1;
            var badValues = new HashSet<int>();

            //iterate array
            for (int i = 0; i < arr.Length; i++)
            {
                badValues.Add(arr[i]);

                if (returnValue == arr[i])
                {
                    while (badValues.Contains(returnValue))
                    {
                        returnValue++;
                    }
                }                
            }

            return returnValue;
        }
    }

    [TestFixture]
    public class MissingIntegerServiceTests
    {
        public MissingIntegerService service = new MissingIntegerService();

        [Test]
        public void GetMissingIntegerTest1()
        {
            var givenArray = new int[] { 1, 3, 6, 4, 1, 2 };
            var expectedArray = 5;
            Assert.AreEqual(expectedArray, service.GetMissingInteger(givenArray));
        }
    }
}
