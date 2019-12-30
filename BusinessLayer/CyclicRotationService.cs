using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class CyclicRotationService : IBaseService
    {
        public void ConsoleRun()
        {
            var line = string.Empty;
            while (line.ToLower() != "exit")
            {
                Console.WriteLine("Enter an array: ");
                line = Console.ReadLine();
                if (line == "exit")
                    break;
                Console.WriteLine("Enter number of times to shift: ");
                var line2 = Console.ReadLine();
                if (line2 == "exit")
                    break;
                else
                {
                    int[] arr = Array.ConvertAll(line.Split(" "), int.Parse);
                    var outputArray = PerformCyclicRotation(arr, Convert.ToInt32(line2));
                    string output = outputArray[0].ToString();
                    for (int i = 1; i < arr.Length; i++)
                    {
                        output = output + ", " + outputArray[i].ToString();
                    }
                    Console.WriteLine($"Output: {output}");
                }
            }
        }

        public int[] PerformCyclicRotation(int[] array, int k)
        {
            if (array.Length < 2)
                return array;
            if (array.Length == 2)
            {
                while (k > 0)
                {
                    Swap(array, 0, 1);
                    k--;
                }
                return array;
            }

            while (k > 0)
            {
                ShiftRight(array);
                k--;
            }
            return array;
        }

        public void ShiftRight(int[] array)
        {
            var newValue = array[0];
            var right1Value = array[1];
            var right2Value = array[2];
            array[0] = array[array.Length - 1];

            for (int i = 1; i < array.Length; i++)
            {
                array[i] = newValue;
                newValue = right1Value;
                right1Value = right2Value;
                if ((i + 2) < array.Length)
                    right2Value = array[i + 2];
            }
        }

        private int[] Swap(int[] array, int index1, int index2)
        {
            var placeHolder = array[index1];
            array[index1] = array[index2];
            array[index2] = placeHolder;
            return array;
        }

        [TestFixture]
        public class CyclicRotationServiceTests
        {
            public CyclicRotationService service = new CyclicRotationService();

            [Test]
            public void PerformCyclicRotationTest1()
            {
                var givenArray = new int[] { 3, 8, 9, 7, 6 };
                var expectedArray = new int[] { 6, 3, 8, 9, 7 };
                Assert.AreEqual(expectedArray, service.PerformCyclicRotation(givenArray, 1));
            }

            [Test]
            public void PerformCyclicRotationTest2()
            {
                var givenArray = new int[] { 9, 3, 9, 3, 9, 7, 9, 1, 10, 19, 20, 10, 29, 19, 1, 29, 20, 13, 16, 18, 16, 18, 20, 13, 201, 102, 201, 102, 101, 99, 101, 7 };
                var expectedArray = new int[] { 99, 101, 7, 9, 3, 9, 3, 9, 7, 9, 1, 10, 19, 20, 10, 29, 19, 1, 29, 20, 13, 16, 18, 16, 18, 20, 13, 201, 102, 201, 102, 101 };

                Assert.AreEqual(expectedArray, service.PerformCyclicRotation(givenArray, 3));
            }

            [Test]
            public void PerformCyclicRotationTest3()
            {
                var givenArray = new int[] { 1, 2 };
                var expectedArray = new int[] { 1, 2 };
                Assert.AreEqual(expectedArray, service.PerformCyclicRotation(givenArray, 2));
            }
        }
    }
}
