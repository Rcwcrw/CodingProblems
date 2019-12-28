using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class DistinctService
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
            //        var outputArray = GetNumberOfDisctinctValues(arr, Convert.ToInt32(line2));
            //        string output = outputArray[0].ToString();
            //        for (int i = 1; i < arr.Length; i++)
            //        {
            //            output = output + ", " + outputArray[i].ToString();
            //        }
            //        Console.WriteLine($"Output: {output}");
            //    }
            //}
        }

        public int GetNumberOfDisctinctValues(int[] arr)
        {
            var hash = new HashSet<int>(arr);
            return hash.Count;
        }
    }

    [TestFixture]
    public class DistinctServiceTests
    {
        public DistinctService service = new DistinctService();

        [Test]
        public void DistinctServiceTest1()
        {
            var given = new int[] { 2, 1, 1, 2, 3, 1 };
            var expected = 3;
            Assert.AreEqual(expected, service.GetNumberOfDisctinctValues(given));
        }
    }
}
