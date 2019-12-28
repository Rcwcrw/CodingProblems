using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class PermCheckService
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
                    Console.WriteLine($"Output: {PermCheck(arr)}");
                }
            }
        }

        public int PermCheck(int[] arr)
        {
            //Create hashset of array
            var hash = new HashSet<int>(arr);
            //iterate n (array.Length)
            for (int i = 1; i <= arr.Length; i++)
            {
                //If !Contains return 0;
                if (!hash.Contains(i))
                    return 0;
            }
            return 1;
        }
    }

    [TestFixture]
    public class PermCheckServiceTests
    {
        public PermCheckService service = new PermCheckService();

        [Test]
        public void PermCheckTest1()
        {
            var givenArray = new int[] { 4, 1, 3, 2 };
            var expected = 1;
            Assert.AreEqual(expected, service.PermCheck(givenArray));
        }

        [Test]
        public void PermCheckTest2()
        {
            var givenArray = new int[] { 4, 1, 3 };
            var expected = 0;

            Assert.AreEqual(expected, service.PermCheck(givenArray));
        }

        [Test]
        public void PermCheckTest3()
        {
            var givenArray = new int[] { 4, 1, 3, 2 };
            var expected = 1;
            Assert.AreEqual(expected, service.PermCheck(givenArray));
        }
    }
}
