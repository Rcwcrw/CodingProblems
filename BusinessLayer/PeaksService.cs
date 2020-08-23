using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class PeaksService : IBaseService
    {
        public void ConsoleRun()
        {
           
        }

        public int MyMethod(int[] arr)
        {
            //Define method to test if peak

            //reverse a string and write to console


                //sum of digits function


            return 1;
        }

        public bool IsPeak(int[] arr, int index)
        {
            if (index < 1 || index == arr.Length)
                return false;
            else
                return (arr[index] > arr[index - 1] && arr[index] < arr[index + 1]);
        }
    }

    [TestFixture]
    public class PeaksServiceTests
    {
        public PeaksService service = new PeaksService();

        [Test]
        public void PeaksServiceTest1()
        {
            var given = new int[] { 1 };
            var expected = 1;
            Assert.AreEqual(expected, service.MyMethod(given));
        }

        [Test]
        public void PeaksServiceTest2()
        {
            var given = new int[] { 1, 2, 3, 4, 3, 4, 1, 2, 3, 4, 6, 2 };
            var expected = 3;

            Assert.AreEqual(expected, service.MyMethod(given));
        }
    }
}
