using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class FrogRiverService
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
                Console.WriteLine("Enter destination point: ");
                var line2 = Console.ReadLine();
                if (line2 == "exit")
                    break;
                else
                {
                    int[] arr = Array.ConvertAll(array.Split(" "), int.Parse);
                    var output = FindMinSecond(Convert.ToInt32(line2), arr);                    
                    Console.WriteLine($"Output: {output}");
                }
            }
        }

        public int FindMinSecond(int x, int[] arr)
        {
            var hash = new HashSet<int>();
            for (int i = 1; i <= x; i++)
            {
                hash.Add(i);
            }

            for (int i = 0; i < arr.Length; i++)
            {
                hash.Remove(arr[i]);
                if (hash.Count == 0)
                    return i;
            }

            return -1;
        }
    }

    [TestFixture]
    public class FrogRiverServiceTests
    {
        public FrogRiverService service = new FrogRiverService();

        [Test]
        public void FindMinSecondTest1()
        {
            var givenArray = new int[] { 1, 2, 1, 4, 2, 3, 5, 4 };
            var destination = 5;
            var expected = 6;
            Assert.AreEqual(expected, service.FindMinSecond(destination, givenArray));
        }

        [Test]
        public void FindMinSecondTest2()
        {
            var givenArray = new int[] { 1, 2, 1, 4, 2, 3, 4, 4 };
            var destination = 5;
            var expected = -1;

            Assert.AreEqual(expected, service.FindMinSecond(destination, givenArray));
        }
    }
}
