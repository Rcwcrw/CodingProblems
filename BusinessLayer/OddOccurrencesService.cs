using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;

namespace MergeSort
{
    public class OddOccurrencesService : IBaseService
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
                else
                {
                    int[] arr = Array.ConvertAll(line.Split(" "), int.Parse);
                    Console.WriteLine($"Answer: {GetOddOccurrences(arr)}");
                    Console.WriteLine();
                }
            }
        }

        public int GetOddOccurrences(int[] array)
        {
            var foundCount = new Dictionary<int, int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (!foundCount.ContainsKey(array[i]))
                    foundCount.Add(array[i], 1);
                else
                    foundCount[array[i]]++;
            }
            return foundCount.FirstOrDefault(x => x.Value % 2 != 0).Key;
        }

        public int GetOddOccurrencesXor(int[] array)
        {
            var oddManOut = 0;
            for (int i = 0; i < array.Length; i++)
            {
                oddManOut ^= array[i];
            }
            return oddManOut;
        }
    }

    [TestFixture]
    public class OddOccurrencesServiceTests
    {
        public OddOccurrencesService service = new OddOccurrencesService();

        [Test]
        public void OddOccurrencesServiceTest1()
        {
            Assert.AreEqual(7, service.GetOddOccurrencesXor(new int[] { 9, 3, 9, 3, 9, 7, 9 }));
        }

        [Test]
        public void OddOccurrencesServiceTest2()
        {
            Assert.AreEqual(20, service.GetOddOccurrencesXor(new int[] { 9, 3, 9, 3, 9, 7, 9, 1, 10, 19, 20, 10, 29, 19, 1, 29, 20,
                13, 16, 18, 16, 18, 20, 13, 201, 102, 201, 102, 101, 99, 101, 7, 99 }));
        }

        [Test]
        public void OddOccurrencesServiceTest3()
        {
            int removedValue = 0;
            var random = new Random();
            var array = new int[10000003];
            var endIndex = 10000002;
            for (int i = 0; i < 5000002; i++)
            {                
                var randomNumber = random.Next(1, 1000000000);
                array[i] = randomNumber;
                if (i != 40000)
                {
                    array[endIndex] = randomNumber;
                    endIndex--;
                } else
                {
                    removedValue = randomNumber;
                }
            }
            
            Assert.AreEqual(removedValue, service.GetOddOccurrencesXor(array));
        }
    }
}
    
