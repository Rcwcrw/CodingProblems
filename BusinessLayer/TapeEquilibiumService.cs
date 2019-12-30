using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MergeSort
{
    public class TapeEquilibiumService
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
                    var output = GetTapeEquilibium(arr);                    
                    Console.WriteLine($"Output: {output}");
                }
            }
        }

        public int GetTapeEquilibium(int[] arr)
        {
            var leftSideTotal = arr[0];
            var rightSideTotal = arr.Skip(1).Sum();
            var minValue = Math.Abs(leftSideTotal - rightSideTotal);            

            for (int i = 1; i < arr.Length - 1; i++)
            {
                leftSideTotal += arr[i];                
                rightSideTotal -= arr[i];                

                minValue = Math.Min(Math.Abs(leftSideTotal - rightSideTotal), minValue);
            }
            return minValue;
        }

        public int GetTapeEquilibium2(int[] arr)
        {
            var minValue = Int32.MaxValue;
            var leftSideTotal = 0;
            var rightSideTotal = 0;

            for (var splitValue = 1; splitValue < arr.Length; splitValue++)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i >= splitValue)
                        rightSideTotal += arr[i];
                    else
                        leftSideTotal += arr[i];
                }

                minValue = Math.Min(Math.Abs(leftSideTotal - rightSideTotal), minValue);
                rightSideTotal = 0;
                leftSideTotal = 0;
            }

            return minValue;
        }
    }

    [TestFixture]
    public class TapeEquilibiumServiceTests
    {
        public TapeEquilibiumService service = new TapeEquilibiumService();

        [Test]
        public void TapeEquilibiumTest1()
        {
            var givenArray = new int[] { 3, 1, 2, 4, 3 };
            var expectedArray = 1;
            Assert.AreEqual(expectedArray, service.GetTapeEquilibium(givenArray));
        }

        [Test]
        public void TapeEquilibiumTest2()
        {
            var givenArray = new int[] { 100, 1, 2, 4, 3 };
            var expectedArray = 90;
            Assert.AreEqual(expectedArray, service.GetTapeEquilibium(givenArray));
        }

        [Test]
        public void TapeEquilibiumTest3()
        {
            var givenArray = new int[] { 1, 2, 4, 3, 100 };
            var expectedArray = 90;
            Assert.AreEqual(expectedArray, service.GetTapeEquilibium(givenArray));
        }

        [Test]
        public void TapeEquilibiumTest4()
        {
            var array = new int[90003];
            var number = 1;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = number;
                number++;
                if (number == 1001)
                    number = 0;
            }
            Assert.AreEqual(67, service.GetTapeEquilibium(array));
        }

        [Test]
        public void TapeEquilibiumTest5()
        {
            var givenArray = new int[] { -100, 2001};
            var expectedArray = 2101;
            Assert.AreEqual(expectedArray, service.GetTapeEquilibium(givenArray));
        }

        [Test]
        public void TapeEquilibiumTest6()
        {
            var random = new Random();
            var array = new int[90003];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-1000, 1000);
            }
            Assert.IsInstanceOf<int>(service.GetTapeEquilibium(array));
        }
    }
}
