using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Linq;

namespace MergeSort
{
    public class StringShuffleService
    {
        public void ConsoleRun()
        {
            /*************************************************
             * Problem
                - Write a function that takes a string, shuffles the string, and returns it.

            ***************************************************/

            var line = string.Empty;
            while (line.ToLower() != "exit")
            {
                Console.WriteLine("Enter a word or sentence: ");
                line = Console.ReadLine();
                if (line == "exit")
                    break;
                else
                {
                    Console.WriteLine($"Answer: {ShuffleString(line)}");
                }
            }
        }

        public string ShuffleString(string str)
        {
            //create blank array of string.Length
            var arr = new string[str.Length];
            //loop through string
            var random = new Random();
            var randomIndex = random.Next(0, str.Length - 1);
            var goUp = true;
            foreach (var letter in str)
            {
                //add to random index in array if index is empty
                if (arr[randomIndex] == null)
                    arr[randomIndex] = letter.ToString();
                //else while index is not empty
                else
                {
                    if (goUp)
                    {
                        while (arr[randomIndex] != null)
                            randomIndex = randomIndex == str.Length - 1 ? 0 : randomIndex + 1;
                    } 
                    else
                    {
                        while (arr[randomIndex] != null)
                            randomIndex = randomIndex == 0 ? str.Length - 1 : randomIndex - 1;
                    }
                    
                    arr[randomIndex] = letter.ToString();
                    goUp = !goUp;
                }
            }

            return string.Join(string.Empty, arr);
        }
    }

    [TestFixture]
    public class StringShuffleServiceTests
    {
        public StringShuffleService service = new StringShuffleService();

        [Test]
        public void StringShuffleServiceTest1()
        {
            var given = "Test string";
            var result = service.ShuffleString(given);
            foreach (var letter in given)
            {
                Assert.Contains(letter, result.ToCharArray());
            }
        }

        [Test]
        public void StringShuffleServiceTest2()
        {
            var result = "abcdefghijklmnopqrstuvwxyz";
            var thresholdMax = 462; //10000 * (1/26) * 1.2
            var thresholdMin = 307; //10000 * (1/26) * .8
            var count = 0;

            for (int i = 0; i < 10000; i++)
            {
                result = service.ShuffleString(result);
                if (result[0] == 'a')
                    count++;
            }
            Console.WriteLine(count.ToString());

            Assert.Greater(count, thresholdMin);
            Assert.Less(count, thresholdMax);
        }

        [Test]
        public void StringShuffleServiceTest3()
        {
            var result = "abcdefghijklmnopqrstuvwxyz";
            var thresholdMax = 462; //10000 * (1/26) * 1.2
            var thresholdMin = 307; //10000 * (1/26) * .8
            var count = 0;

            for (int i = 0; i < 10000; i++)
            {
                result = service.ShuffleString(result);
                if (result[12] == 'm')
                    count++;
            }
            Console.WriteLine(count.ToString());

            Assert.Greater(count, thresholdMin);
            Assert.Less(count, thresholdMax);
        }

        [Test]
        public void StringShuffleServiceTest4()
        {
            var result = "abcdefghijklmnopqrstuvwxyz";
            var thresholdMax = 462; //10000 * (1/26) * 1.2
            var thresholdMin = 307; //10000 * (1/26) * .8
            var count = 0;

            for (int i = 0; i < 10000; i++)
            {
                result = service.ShuffleString(result);
                if (result[25] == 'z')
                    count++;
            }
            Console.WriteLine(count.ToString());

            Assert.Greater(count, thresholdMin);
            Assert.Less(count, thresholdMax);
        }

        public class Counter
        {
            public string Letter { get; set; }
            public int Index { get; set; }
            public int CountAtIndex { get; set; }
        }

        [Test]
        public void StringShuffleServiceTest5()
        {
            //class counter
            //letter
            //position
            //count
        
                
            var result = "abcdefghijklmnopqrstuvwxyz";
            var thresholdMax = 462; //10000 * (1/26) * 1.2
            var thresholdMin = 307; //10000 * (1/26) * .8
            var count = new List<Counter>();            

            for (int i = 0; i < 10000; i++)
            {
                result = service.ShuffleString(result);
                for (int j = 0; j < result.Length; j++)
                {
                    var counter = count.Where(x => x.Letter == result[j].ToString() && x.Index == j).FirstOrDefault();
                    if (counter == null)
                        count.Add(new Counter() { Letter = result[j].ToString(), Index = j, CountAtIndex = 1 });
                    else
                        counter.CountAtIndex++;
                }
            }

            var json = JsonSerializer.Serialize(count);

            Console.WriteLine(json);

            foreach (var counter in count)
            {
                Assert.Greater(counter.CountAtIndex, thresholdMin);
                Assert.Less(counter.CountAtIndex, thresholdMax);
            }
        }
    }
}
