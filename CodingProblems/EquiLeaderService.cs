using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MergeSort
{
    public class EquiLeaderService
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
            //        Console.WriteLine($"Answer: {GetNumberOfEquiLeaders(Convert.ToInt32(line))}");
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
            //        var outputArray = GetNumberOfEquiLeaders(arr, Convert.ToInt32(line2));
            //        string output = outputArray[0].ToString();
            //        for (int i = 1; i < arr.Length; i++)
            //        {
            //            output = output + ", " + outputArray[i].ToString();
            //        }
            //        Console.WriteLine($"Output: {output}");
            //    }
            //}
        }

        public int GetNumberOfEquiLeadersSlow(int[] arr)
        {
            var count = 0;
            //for loop through arr
            for (int i = 1; i < arr.Length + 1; i++)
            {
                //var seg1 = GetLeaderValue(arr.Take(i));
                //var seg2 = GetLeaderValue(arr.Skip(i).Take(arr.Length - i));
                //if (seg1 == seg2 && seg1 != -1)
                //    count++;
            }
            
            return count;
        }

        public int GetNumberOfEquiLeaders(int[] arr)
        {
            var count = 0;
            int numberOfOccurences;
            var leaderValue = GetLeaderValue(arr, out numberOfOccurences);
            var countToLeft = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == leaderValue)
                    countToLeft++;
                var subArray2Threshold = (arr.Length - (i + 1)) / 2;

                if (countToLeft > ((i + 1) / 2) && numberOfOccurences - countToLeft > subArray2Threshold)
                    count++;
            }

            return count;
        }

        public int GetLeaderValue(IEnumerable<int> collection, out int numberOfOccurrences)
        {            
            if (collection.Count() == 1)
            {
                numberOfOccurrences = 1;
                return collection.First();
            }

            var dic = new Dictionary<int, int>();
            var threshold = collection.Count() / 2;

            foreach (var item in collection)
            {
                if (!dic.ContainsKey(item))
                    dic.Add(item, 1);
                else if (dic[item] >= threshold)
                {
                    numberOfOccurrences = collection.Count(x => x == item);
                    return item;
                }
                else
                    dic[item]++;
            }
            numberOfOccurrences = -1;
            return -1;
        }
    }

    [TestFixture]
    public class EquiLeaderServiceTests
    {
        public EquiLeaderService service = new EquiLeaderService();

        [Test]
        public void EquiLeaderServiceTest1()
        {
            var given = new int[] { 4, 3, 4, 4, 4, 2 };
            var expected = 2;
            Assert.AreEqual(expected, service.GetNumberOfEquiLeaders(given));
        }

        [Test]
        public void EquiLeaderServiceTest2()
        {
            var given = new int[] { 4, 3, 4, 4, 4, 2 };
            var expected = 2;
            Assert.AreEqual(expected, service.GetNumberOfEquiLeaders(given));
        }

        [Test]
        public void EquiLeaderServiceTest3()
        {
            var given = new int[] { 4, 3, 4, 4, 4, 2 };
            var expected = 2;
            Assert.AreEqual(expected, service.GetNumberOfEquiLeaders(given));
        }
    }
}
