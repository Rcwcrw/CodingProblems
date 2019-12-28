using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class MiscService : IBaseService
    {
        public void ConsoleRun()
        {
            //To Binary Converter
            var input = string.Empty;
            while (input.ToLower() != "exit")
            {
                Console.WriteLine("Enter a number: ");
                input = Console.ReadLine();
                if (input.ToLower() == "exit")
                    break;
                Console.WriteLine(ToBinary(input));
                Console.WriteLine("");
            }


            //Coin Problem
            //int[] availableCoins = { 10, 5, 2, 1 };
            //var desiredValue = 20;
            //var minCoins = new LinkedList<int>();
            //GetCoinCombination(availableCoins, desiredValue, minCoins);

            //Console.WriteLine($"Min coin count: {minCoins.Count}");
            //Console.WriteLine($"Min coins: ");
            //foreach(var coin in minCoins)
            //{
            //    Console.WriteLine(coin);
            //}

            //Console.ReadLine();
        }

        public class Coin
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }

        public static void GetCoinCombination(int[] coins, int desiredValue, LinkedList<int> minCoins)
        {
            GetCoinCombination(coins, desiredValue, minCoins, 0, 0);
        }


        public static void GetCoinCombination(int[] coins, int desiredValue, LinkedList<int> minCoins, int tally, int index)
        {
            if (tally == desiredValue)
            {
                return;
            }

            if (tally + coins[index] > desiredValue)
            {
                index++;
                GetCoinCombination(coins, desiredValue, minCoins, tally, index);
            }
            else
            {
                minCoins.AddLast(coins[index]);
                tally += coins[index];
                GetCoinCombination(coins, desiredValue, minCoins, tally, index);
            }
        }

        public static string ToBinary(string input)
        {
            var value = Convert.ToInt32(input);

            var result = string.Empty;
            if (value == 0)
                return "0";
            else if (value == 1)
                return "1";
            //else if (value == 2)
            //    return "10";

            //Find the highest power of two less than n
            var powersOfTwo = 2;
            while (value >= powersOfTwo)
            {
                powersOfTwo *= 2;
            }
            powersOfTwo /= 2;

            while (powersOfTwo > 2)
            {
                while (value < powersOfTwo)
                {
                    result += "0";
                    powersOfTwo /= 2;
                }

                result += "1";

                value -= powersOfTwo;
                powersOfTwo /= 2;
            }

            return result;
        }
    }
}
