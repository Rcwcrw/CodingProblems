using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MergeSort
{
    public class DominatorService
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
            //        Console.WriteLine($"Answer: {GetDominator(Convert.ToInt32(line))}");
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
            //        var outputArray = GetDominator(arr, Convert.ToInt32(line2));
            //        string output = outputArray[0].ToString();
            //        for (int i = 1; i < arr.Length; i++)
            //        {
            //            output = output + ", " + outputArray[i].ToString();
            //        }
            //        Console.WriteLine($"Output: {output}");
            //    }
            //}
        }

        public int GetDominator(int[] arr)
        {
            if (arr.Length == 1)
                return 0;

            var dic = new Dictionary<int, int>();
            var threshold = arr.Length / 2;

            for (int i = 0; i < arr.Length; i++)
            {
                if (!dic.ContainsKey(arr[i]))
                    dic.Add(arr[i], 1);
                else if (dic[arr[i]] >= threshold)
                    return i;
                else 
                    dic[arr[i]]++;
            }

            return -1;
        }

        public int GetDominatorSlow2(int[] arr)
        {
            if (arr.Length == 1)
                return 0;

            var hash = new HashSet<Canidate>();
            var threshold = arr.Length / 2;

            for (int i = 0; i < arr.Length; i++)
            {
                if (!hash.Any(x => x.Value == arr[i]))
                    hash.Add(new Canidate() { Value = arr[i], Count = 1, FirstIndex = i });
                else
                {
                    var domCan = hash.First(x => x.Value == arr[i]);
                    if (domCan.Count >= threshold)
                        return domCan.FirstIndex;
                    else
                        domCan.Count++;
                }
            }

            return -1;
        }

        public class Canidate
        {
            public int Value { get; set; }
            public int Count { get; set; }
            public int FirstIndex { get; set; }

        }

        public int GetDominatorSlow(int[] arr)
        {
            var dic = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {        
                if (!dic.ContainsKey(arr[i]))
                    dic.Add(arr[i], 1);
                else
                    dic[arr[i]]++;
            }

            var dominatorPair = dic.Where(x => x.Value > arr.Length / 2);

            if (dominatorPair.Count() == 0)
                return -1;

            var firstIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (dominatorPair.First().Key == arr[i])
                {
                    firstIndex = i;
                    break;
                }
            }

            return firstIndex;
        }
    }

    [TestFixture]
    public class DominatorServiceTests
    {
        public DominatorService service = new DominatorService();

        [Test]
        public void DominatorServiceTest1()
        {
            var given = new int[] { 3, 4, 3, 2, 3, -1, 3, 3 };
            var expected = 7;
            Assert.AreEqual(expected, service.GetDominator(given));
        }

        [Test]
        public void DominatorServiceTest2()
        {
            var given = new int[] { 3, 4, 3, 2, 3, -1, 7, 8 };
            var expected = -1;
            Assert.AreEqual(expected, service.GetDominator(given));
        }

        [Test]
        public void DominatorServiceTest3()
        {
            var given = new int[] { 3, 4, 3, 2, 3, -1, 7, 8 };
            var expected = -1;
            Assert.AreEqual(expected, service.GetDominator(given));
        }
    }
}
