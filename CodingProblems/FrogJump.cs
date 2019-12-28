using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class FrogJumpService
    {
        public void ConsoleRun()
        {
            //Int
            var line = string.Empty;
            while (line.ToLower() != "exit")
            {
                Console.WriteLine("Enter start destination and jump distance: ");
                line = Console.ReadLine();
                if (line == "exit")
                    break;
                else
                {
                    var start = Convert.ToInt32(line.Split(" ")[0]);
                    var destination = Convert.ToInt32(line.Split(" ")[1]);
                    var jumpDistance =Convert.ToInt32(line.Split(" ")[2]);
                    Console.WriteLine($"Answer: {GetNumberOfJumps(start, destination, jumpDistance)}");
                }
            }
        }

        public int GetNumberOfJumps(int start, int destination, int jumpDistance)
        {
            //Subtract start from destination for required distance
            //Divide required distance by jump distance
            //Return ceiling
            return (int)Math.Ceiling((destination - start) / (decimal) jumpDistance );
        }            
    }

    [TestFixture]
    public class FrogJumpServiceTests
    {
        public FrogJumpService service = new FrogJumpService();

        [Test]
        public void Test1()
        {
            var x = 10;
            var y = 85;
            var d = 30;
            var expected = 3;
            Assert.AreEqual(expected, service.GetNumberOfJumps(x, y, d));
        }

        [Test]
        public void Test2()
        {
            var x = 101;
            var y = 100000085;
            var d = 39;
            var expected = 2564103;

            Assert.AreEqual(expected, service.GetNumberOfJumps(x, y, d));
        }
    }
}
