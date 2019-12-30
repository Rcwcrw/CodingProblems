using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class StoneWallService
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
            //        Console.WriteLine($"Answer: {GetNumberOfStones(Convert.ToInt32(line))}");
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
            //        var outputArray = GetNumberOfStones(arr, Convert.ToInt32(line2));
            //        string output = outputArray[0].ToString();
            //        for (int i = 1; i < arr.Length; i++)
            //        {
            //            output = output + ", " + outputArray[i].ToString();
            //        }
            //        Console.WriteLine($"Output: {output}");
            //    }
            //}
        }

        public int GetNumberOfStones(int[] arr)
        {
            var count = 0;
            var stack = new Stack<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                while (stack.Count > 0 && stack.Peek() > arr[i])
                    stack.Pop();
                if (stack.Count > 0 && stack.Peek() == arr[i])
                {
                    //nothing
                }                    
                else
                {
                    count++;
                    stack.Push(arr[i]);
                }
            }

            return count;
        }
    }

    [TestFixture]
    public class StoneWallServiceTests
    {
        public StoneWallService service = new StoneWallService();

        [Test]
        public void StoneWallServiceTest1()
        {
            var given = new int[] { 8, 8, 5, 7, 9, 8, 7, 4, 8 };
            var expected = 7;
            Assert.AreEqual(expected, service.GetNumberOfStones(given));
        }

        [Test]
        public void StoneWallServiceTest2()
        {
            var given = new int[] { 8, 8, 5, 7, 9, 8, 7, 4, 8 };
            var expected = 7;
            Assert.AreEqual(expected, service.GetNumberOfStones(given));
        }

        [Test]
        public void StoneWallServiceTest3()
        {
            var given = new int[] { 8, 8, 5, 7, 9, 8, 7, 4, 8 };
            var expected = 7;
            Assert.AreEqual(expected, service.GetNumberOfStones(given));
        }
    }
}
