using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class NestedService
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

            var stack = new Stack<char>();

            foreach (var chr in str)
            {
                if (chr ==  '(')
                {
                    stack.Push(')');
                } 
                else if (chr == ')')
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
    }

    [TestFixture]
    public class NestedServiceTests
    {
        public NestedService service = new NestedService();

        [Test]
        public void NestedServiceTest1()
        {
            var given = "(()(())())";
            var expected = 1;
            Assert.AreEqual(expected, service.IsNested(given));
        }

        [Test]
        public void NestedServiceTest2()
        {
            var given = "(()()";
            var expected = 0;

            Assert.AreEqual(expected, service.IsNested(given));
        }

        [Test]
        public void NestedServiceTest3()
        {
            var given = ")(";
            var expected = 0;

            Assert.AreEqual(expected, service.IsNested(given));
        }

        [Test]
        public void NestedServiceTest4()
        {
            var given = "((((";
            var expected = 0;

            Assert.AreEqual(expected, service.IsNested(given));
        }
        [Test]
        public void NestedServiceTest5()
        {
            var given = "())";
            var expected = 0;

            Assert.AreEqual(expected, service.IsNested(given));
        }

        [Test]
        public void NestedServiceTest6()
        {
            var given = "()()";
            var expected = 1;

            Assert.AreEqual(expected, service.IsNested(given));
        }

    }
}
