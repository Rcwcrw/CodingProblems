using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class WordScoreService : IBaseService
    {
        public void ConsoleRun()
        {
            var line = string.Empty;
            while (line.ToLower() != "exit")
            {
                Console.WriteLine("Enter a word: ");
                line = Console.ReadLine();
                if (line == "exit")
                    break;
                else
                    Console.WriteLine($"Score: {GetWordScore(line)}");
            }
        }


        public static int GetWordScore(string word)
        {
            if (string.IsNullOrEmpty(word))
                return 0;
            
            //Variable for score
            var score = 0;

            word = word?.ToLower();

            //Iterate through the letters in word
            foreach (char letter in word)
            {
                //Add to score based on given values
                switch (letter)
                {
                    case ('x'):
                        score += 12;
                        break;
                    case ('j'):
                        score += 6;
                        break;
                    case ('t'):
                        score += 5;
                        break;
                    case ('f'):
                        score += 3;
                        break;
                    case ('a'):
                    case ('e'):
                    case ('i'):
                        score += 2;
                        break;
                    default:
                        break;
                }
            }

            //return score
            return score;
        }

        //Test case 1: "XRay Machine" >> Score: 20
        [TestFixture]
        public class WordScoreServiceTests
        {
            [Test]
            public void GetWordScore_NormalWord_Return20()
            {
                Assert.AreEqual(20, GetWordScore("XRay Machine"));
            }

            [Test]
            public void GetWordScore_NormalWord_Return13()
            {
                Assert.AreEqual(13, GetWordScore("Jabbt"));
            }

            [Test]
            public void GetWordScore_EmptyString_Return0()
            {
                Assert.AreEqual(0, GetWordScore(string.Empty));
            }

            [Test]
            public void GetWordScore_MaxScore_Return600()
            {
                Assert.AreEqual(600, GetWordScore("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"));
            }

            [Test]
            public void GetWordScore_Null_Return0()
            {
                Assert.AreEqual(0, GetWordScore(null));
            }
        }
    }
}
