using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MergeSort
{
    public class NumberOfDiscIntersectionsService
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
            //        var outputArray = GetNumberOfIntersections(arr, Convert.ToInt32(line2));
            //        string output = outputArray[0].ToString();
            //        for (int i = 1; i < arr.Length; i++)
            //        {
            //            output = output + ", " + outputArray[i].ToString();
            //        }
            //        Console.WriteLine($"Output: {output}");
            //    }
            //}
        }

        public int GetNumberOfIntersectionsSlow(int[] arr)
        {
            var count = 0;
            //Loop through arr
            for (long i = 0; i < arr.Length - 1; i++)
            {
                //set left edge value
                //set right edge value
                long leftSide = i - arr[i];
                long rightSide = i + arr[i];

                for (long j = i + 1; j < arr.Length; j++)
                {
                    long testLeftSide = j - arr[j];
                    long testRightSide = j + arr[j];
                    //is test disc left edge >= left edge && <= right edge
                    //OR
                    //is test disc right edge >= left edge && <= right edge
                    if ((testLeftSide >= leftSide && testLeftSide <= rightSide)
                        || (testRightSide >= leftSide && testRightSide <= rightSide)
                        || (leftSide >= testLeftSide && leftSide <= testRightSide)
                        || (rightSide >= testLeftSide && rightSide <= testRightSide))
                        count++;
                    if (count > 10000000)
                        return -1;
                }
            }

            return count;
        }

        public class Disc
        {
            public long ArrayIndex { get; set; }
            public long LeftEdge { get; set; }
            public long RightEdge { get; set; }
        }

        public class DiscEvent
        {
            public long Point { get; set; }
            public bool IsStart { get; set; }
        }

        public int GetNumberOfIntersectionsSlow2(int[] arr)
        {
            var count = 0;
            var hash = new HashSet<Disc>();
            //Loop through arr
            for (long i = 0; i < arr.Length; i++)
            {
                var disc = new Disc();
                disc.ArrayIndex = i;
                disc.LeftEdge = i - arr[i];
                disc.RightEdge = i + arr[i];

                if (hash.Count > 0)
                {
                    count += hash.Count(x => (x.LeftEdge >= disc.LeftEdge && x.LeftEdge <= disc.RightEdge)
                        || (x.RightEdge >= disc.LeftEdge && x.RightEdge <= disc.RightEdge)
                        || (disc.LeftEdge >= x.LeftEdge && disc.LeftEdge <= x.RightEdge)
                        || (disc.RightEdge >= x.LeftEdge && disc.RightEdge <= x.RightEdge));
                }

                if (count > 10000000)
                    return -1;

                hash.Add(disc);
            }

            return count;
        }

        public int GetNumberOfIntersections(int[] arr)
        {
            var hash = new HashSet<DiscEvent>();
            for (long i = 0; i < arr.Length; i++)
            {
                var startEvent = new DiscEvent();
                startEvent.Point = i - arr[i];
                startEvent.IsStart = true;
                var endEvent = new DiscEvent();
                endEvent.Point = i + arr[i];
                endEvent.IsStart = false;
                hash.Add(startEvent);
                hash.Add(endEvent);
            }

            hash = new HashSet<DiscEvent>(hash.OrderBy(x => x.Point).ThenByDescending(x => x.IsStart));

            var activeDiscs = 0;
            var intersections = 0;
            
            foreach (var discEvent in hash)
            {
                if (discEvent.IsStart)
                {
                    activeDiscs++;
                    intersections += (activeDiscs - 1);
                } 
                else
                {
                    activeDiscs--;
                }

                if (intersections > 10000000)
                    return -1;
            }

            return intersections;
        }
    }

    [TestFixture]
    public class NumberOfDiscIntersectionsServiceTests
    {
        public NumberOfDiscIntersectionsService service = new NumberOfDiscIntersectionsService();

        [Test]
        public void NumberOfDiscIntersectionsServiceTest1()
        {
            var given = new int[] { 1, 5, 2, 1, 4, 0 };
            var expected = 11;
            Assert.AreEqual(expected, service.GetNumberOfIntersections(given));
        }

        [Test]
        public void NumberOfDiscIntersectionsServiceTest2()
        {
            var given = new int[] { 1, 5, 2, 1, 4, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1};
            var expected = 19;

            Assert.AreEqual(expected, service.GetNumberOfIntersections(given));
        }

        [Test]
        public void NumberOfDiscIntersectionsServiceTest3()
        {
            var given = new int[] { 1, 2147483647, 0 };
            var expected = 2;

            Assert.AreEqual(expected, service.GetNumberOfIntersections(given));
        }
    }
}
