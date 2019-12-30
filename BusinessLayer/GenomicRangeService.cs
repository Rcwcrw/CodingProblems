﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
//using System.Linq;

namespace MergeSort
{
    public class GenomicRangeService
    {
        public void ConsoleRun()
        {
            //Array
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
            //        var outputArray = MyMethod(arr, Convert.ToInt32(line2));
            //        string output = outputArray[0].ToString();
            //        for (int i = 1; i < arr.Length; i++)
            //        {
            //            output = output + ", " + outputArray[i].ToString();
            //        }
            //        Console.WriteLine($"Output: {output}");
            //    }
            //}
        }

        public int[] GetMinimalImpacts(string dnaSequence, int[] startingPoints, int[] endingPoints)
        {
            int[] returnArray = new int[startingPoints.Length];

            for (int i = 0; i < startingPoints.Length; i++)
            {                
                returnArray[i] = GetMinLetterValue(dnaSequence.Substring(startingPoints[i], (endingPoints[i] + 1) - startingPoints[i]));
            }

            return returnArray;
        }

        public int GetMinLetterValue(string subString)
        {
            if (subString.Contains('A'))            
                return 1;
            if (subString.Contains('C'))
                return 2;
            if (subString.Contains('G'))
                return 3;
            if (subString.Contains('T'))
                return 4;
            else
                return 5;
        }

        public int[] GetMinimalImpactsSlow(string dnaSequence, int[] startingPoints, int[] endingPoints)
        {
            int[] returnArray = new int[startingPoints.Length];

            for (int i = 0; i < startingPoints.Length; i++)
            {
                var minValue = 5;
                for (int j = startingPoints[i]; j <= endingPoints[i]; j++)
                {
                    if (dnaSequence[i] == 'A')
                    {
                        minValue = 1;
                        break;
                    }

                    var letterValue = GetLetterValue(dnaSequence[j]);
                    minValue = Math.Min(letterValue, minValue);
                }
                returnArray[i] = minValue;
            }

            return returnArray;
        }

        public int GetLetterValue(char letter)
        {
            switch (letter)
            {
                case ('A'):
                    return 1;
                case ('C'):
                    return 2;
                case ('G'):
                    return 3;
                case ('T'):
                    return 4;
                default:
                    return 5;
            }
        }
    }

    [TestFixture]
    public class GenomicRangeServiceTests
    {
        public GenomicRangeService service = new GenomicRangeService();

        [Test]
        public void GetMinimalImpactsTest1()
        {
            var dnaSequence = "CAGCCTA";
            var startingPoints = new int[] { 2, 5, 0 };
            var endingPoints = new int[] { 4, 5, 6 };
            var expectedArray = new int[] { 2, 4, 1 };

            Assert.AreEqual(expectedArray, service.GetMinimalImpacts(dnaSequence, startingPoints, endingPoints));
        }

        [Test]
        public void GetMinimalImpactsTest2()
        {
            var startingPoints = new int[] { 20, 55, 0, 20, 55, 0, 20, 55, 0, 20, 55, 0, 20, 55, 0, 20, 55, 0, 20, 55, 0, 20, 55, 0, 20, 55, 0, 20, 55, 0, 20, 55, 0, 20, 55, 0, 20, 55, 0, 20, 55, 0, 20, 55, 0, 20, 55, 0, 20, 55, 0, 20, 55, 0, 20, 55, 0, 20, 55, 0, 20, 55, 0 };
            var endingPoints = new int[] { 1500, 3800, 1202700, 1500, 3800, 1202700, 1500, 3800, 1202700, 1500, 3800, 1202700, 1500, 3800, 1202700, 1500, 3800, 1202700, 1500, 3800, 1202700, 1500, 3800, 1202700, 1500, 3800, 1202700, 1500, 3800, 1202700, 1500, 3800, 1202700, 1500, 3800, 1202700, 1500, 3800, 1202700, 1500, 3800, 1202700, 1500, 3800, 1202700, 1500, 3800, 1202700, 1500, 3800, 1202700, 1500, 3800, 1202700, 1500, 3800, 1202700, 1500, 3800, 1202700, 1500, 3800, 1202700 };
            var expectedArray = new int[] { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 };

            Assert.AreEqual(expectedArray, service.GetMinimalImpacts(dnaSequence, startingPoints, endingPoints));
        }
    }
}