using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class BinaryGapService : IBaseService
    {
        public void ConsoleRun()
        {
            var line = string.Empty;
            while (line.ToLower() != "exit")
            {
                Console.WriteLine("Enter a number: ");
                line = Console.ReadLine();
                if (line == "exit")
                    break;
                else
                {
                    Console.WriteLine($"Binary Number: {Convert.ToString(Convert.ToInt32(line), 2)}");
                    Console.WriteLine($"Binary Gap: {GetBinaryGap(Convert.ToInt32(line))}");
                }
            }
        }

        public int GetBinaryGap(int number)
        {        
            //Convert to binary
            var binary = Convert.ToString(number, 2);
            var blah = Convert.ToInt32("1000000000000000000000000000001", 2);
            Console.WriteLine($"Blah: {blah}");


            if (binary.Length < 3)
                return 0;

            var gap = 0;
            var testGap = 0;

            //Iterate through string to find largest gap
            for (int i = 1; i < binary.Length; i++)
            {
                if (binary[i] == '1')
                {
                    if (testGap > gap)
                    {
                        gap = testGap;
                    }
                    testGap = 0;
                }
                if (binary[i] == '0' && i < binary.Length)
                {
                    testGap++;
                }
            }

            //Return gap
            return gap;
        }

    }
}
