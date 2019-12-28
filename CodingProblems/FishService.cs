using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class FishService
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
            //        var outputArray = GetNumberOfRemainingFish(arr, Convert.ToInt32(line2));
            //        string output = outputArray[0].ToString();
            //        for (int i = 1; i < arr.Length; i++)
            //        {
            //            output = output + ", " + outputArray[i].ToString();
            //        }
            //        Console.WriteLine($"Output: {output}");
            //    }
            //}
        }

        public int GetNumberOfRemainingFish(int[] arrSize, int[] arrDirection)
        {
            var count = arrSize.Length;
            var stack = new Stack<int>();

            //Loop through arrays looking for B[P] = 1
            for (int i = 0; i < arrSize.Length; i++)
            {
                //Stack B[P] = 1  //continue;
                if (arrDirection[i] == 1)
                {
                    stack.Push(i);
                    continue;
                }
                
                while (stack.Count > 0)
                {
                    var downFish = stack.Pop();
                    if (arrSize[i] < arrSize[downFish])
                    {
                        count--;
                        stack.Push(downFish);
                        break;
                    }
                    else
                        count--;
                }
            }
            return count;
        }
    }

    [TestFixture]
    public class FishServiceTests
    {
        public FishService service = new FishService();

        [Test]
        public void FishServiceTest1()
        {
            var given   = new int[] { 4, 3, 2, 1, 5 };
            var given2  = new int[] { 0, 1, 0, 0, 0 };
            var expected = 2;
            Assert.AreEqual(expected, service.GetNumberOfRemainingFish(given, given2));
        }

        [Test]
        public void FishServiceTest2()
        {
            var given = new int[] { 4, 3, 2, 1, 5 };
            var given2 = new int[] { 0, 1, 0, 0, 0 };
            var expected = 2;
            Assert.AreEqual(expected, service.GetNumberOfRemainingFish(given, given2));
        }

        [Test]
        public void FishServiceTest3()
        {
            var given = new int[] { 4, 3, 2, 1, 5 };
            var given2 = new int[] { 0, 1, 0, 0, 0 };
            var expected = 2;
            Assert.AreEqual(expected, service.GetNumberOfRemainingFish(given, given2));
        }
    }
}
