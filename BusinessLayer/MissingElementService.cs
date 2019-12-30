using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;

namespace MergeSort
{
    public class MissingElementService : IBaseService
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
                    Console.WriteLine($"Answer: {GetMissingElement(arr)}");
                    Console.WriteLine();
                }
            }
        }

        public int GetMissingElement(int[] array)
        {
            var valuesHash = new HashSet<int>(array);
            for (int i = 1; i <= array.Length + 1; i++)
            {
                if (!valuesHash.Contains(i))
                    return i;
            }
            return 0;
        }
    }

    [TestFixture]
    public class MissingElementServiceTests
    {
        public MissingElementService service = new MissingElementService();

        [Test]
        public void MissingElementServiceTest1()
        {
            Assert.AreEqual(5, service.GetMissingElement(new int[] { 2, 3, 1, 4 }));
        }

        [Test]
        public void MissingElementServiceTest2()
        {
            var array = new int[1900003];
            var number = 1;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = number;
                number++;
                if (number == 1800000)
                    number++;
            }
            Assert.AreEqual(1800000, service.GetMissingElement(array));
        }

        [Test]
        public void MissingElementServiceTest3()
        {
            var array = new int[10000003];
            var number = 1;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = number;
                number++;
            }
            Assert.AreEqual(10000004, service.GetMissingElement(array));
        }

        [Test]
        public void MissingElementServiceTest4()
        {
            Assert.AreEqual(1, service.GetMissingElement(new int[] { 2 }));
        }
    }
}
    
