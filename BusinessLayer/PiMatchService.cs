using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class PiMatchService : IBaseService
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
                    Console.WriteLine($"Score {GetPiMatchScore(line)}");
            }
        }

        public static decimal GetPiMatchScore(string input)
        {
            //Remove decimal point in string input 
            input = input.Replace(".", "");

            var score = CalculateScore(input);

            //Return score
            return score;
        }

        private static decimal CalculateScore(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Length < 3)
                return 0;
            var score = 0m;
            var count = 0;
            //Iterate through input until 3 chars from the end
            for (int i = 0; i < input.Length - 2; i++)
            {
                //subtract 314 from substring, add to score
                score += (Convert.ToInt32(input.Substring(i, 3)) - 314);
                //Iterate a count
                count++;
            }
            //Divide by count
            score /= count;
            //Return score 
            return score;
        }

        [TestFixture]
        public class PiMatchServiceTests
        {
            //Case 1: 3149 >> -82.5
            [Test]
            public void GetPiMatch_NormalSimpleInput_ReturnsScore()
            {
                Assert.AreEqual(-82.5m, GetPiMatchScore("3149"));

            }

            //Case 2: 357878 >> 336
            [Test]
            public void GetPiMatch_NormalLargeInput_ReturnsScore()
            {
                Assert.AreEqual(336m, GetPiMatchScore("357878"));

            }

            //Case 3: string.Empty >> 0
            [Test]
            public void GetPiMatch_EmptyString_ReturnsScoreOfZero()
            {
                Assert.AreEqual(0, GetPiMatchScore(string.Empty));

            }
        }
    }
}
