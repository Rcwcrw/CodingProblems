using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSort
{
    public class TitleService : IBaseService
    {
        public void ConsoleRun()
        {
            //TitleCase
            var line = string.Empty;
            while (line.ToLower() != "exit")
            {
                Console.WriteLine("Enter a title: ");
                line = Console.ReadLine();
                if (line == "exit")
                    break;
                else
                    Console.WriteLine(ToTitleCase(line));
            }
        }

        private static readonly HashSet<string> _lowercaseWords = new HashSet<string>() { "a", "the", "to", "at", "in", "with", "and", "but", "or" };

        public virtual string ToTitleCase(string title)
        {
            if (title == null)
                throw new ArgumentNullException("Title cannot be null");

            if (title == string.Empty)
                return title;

            title = title.ToLower();
            var titleArray = title.Split(" ");

            for (int i = 0; i < titleArray.Length; i++)
            {
                if (i == 0 || i == titleArray.Length - 1 || !_lowercaseWords.Contains(titleArray[i]))
                    titleArray[i] = titleArray[i].First().ToString().ToUpper() + titleArray[i].Substring(1);
            }

            return string.Join(" ", titleArray);
        }
    }


    #region Tests
    [TestFixture]
    public class ToTitleCaseTests
    {
        //Test case 1:  "i love solving problems and it is fun"
        //              "I Love Solving Problems and It Is Fun"
        [Test]
        public void ToTitleCase_LowercaseInput_ReturnTitleCase()
        {
            TitleService titleService = new TitleService();
            Assert.AreEqual("I Love Solving Problems and It Is Fun", titleService.ToTitleCase("i love solving problems and it is fun"));
        }

        //Test case 2:  "wHy DoeS A biRd Fly?"
        //              "Why Does a Bird Fly?"
        [Test]
        public void ToTitleCase_RandomLettersCapitalized_ReturnTitleCase()
        {
            TitleService titleService = new TitleService();
            Assert.AreEqual("Why Does a Bird Fly?", titleService.ToTitleCase("wHy DoeS A biRd Fly?"));
        }

        //Test case 3:  null
        //              Argument Exeception
        [Test]
        public void ToTitleCase_Null_ArgumentNullException()
        {
            TitleService titleService = new TitleService();
            Assert.Throws<ArgumentNullException>(() => titleService.ToTitleCase(null));

        }

        //Test case 4:  ""
        //              ""
        [Test]
        public void ToTitleCase_EmptyString_ReturnEmptyString()
        {
            TitleService titleService = new TitleService();
            Assert.AreEqual(string.Empty, titleService.ToTitleCase(string.Empty));
        }
    }
    #endregion
}
