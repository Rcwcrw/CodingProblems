using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class BracketsService
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
            //        Console.WriteLine($"Answer: {IsNested(Convert.ToInt32(line))}");
            //    }
            //}
        }

        public int IsNested(string str)
        {
            if (str == string.Empty)
            {
                return 1;
            }

            var openHash = new HashSet<char>() { '{', '[', '(' };
            var closeHash = new HashSet<char>() { ')', ']', '}' };
            var stack = new Stack<char>();

            foreach (var chr in str)
            {
                if (openHash.Contains(chr))
                {
                    stack.Push(GetClosing(chr));
                } 
                else if (closeHash.Contains(chr))
                {                    
                    if (stack.Count == 0 || chr != stack.Pop())
                        return 0;
                }
            }

            if (stack.Count > 0)
                return 0;
            else
                return 1;
        }

        public char GetClosing(char chr)
        {
            switch (chr)
            {
                case ('{'):
                    return '}';
                case ('['):
                    return ']';
                case ('('):
                    return ')';
                default:
                    throw new Exception();
            }
        }
    }

    [TestFixture]
    public class BracketsServiceTests
    {
        public BracketsService service = new BracketsService();

        [Test]
        public void BracketsServiceTest1()
        {
            var given = "{[()()]}";
            var expected = 1;
            Assert.AreEqual(expected, service.IsNested(given));
        }

        [Test]
        public void BracketsServiceTest2()
        {
            var given = "([)()]";
            var expected = 0;

            Assert.AreEqual(expected, service.IsNested(given));
        }

        [Test]
        public void BracketsServiceTest3()
        {
            var given = ")(";
            var expected = 0;

            Assert.AreEqual(expected, service.IsNested(given));
        }

        [Test]
        public void BracketsServiceTest4()
        {
            var given = "{{{{{";
            var expected = 0;

            Assert.AreEqual(expected, service.IsNested(given));
        }
    }
}
