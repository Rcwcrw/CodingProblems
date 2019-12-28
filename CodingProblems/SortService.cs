using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class SortService : IBaseService
    {
        public void ConsoleRun()
        {
            //MergeSort
            Console.WriteLine("Enter an array: ");
            string line = Console.ReadLine();
            int[] arr = Array.ConvertAll(line.Split(" "), int.Parse);
            Console.WriteLine(">");
            MergeSort(arr, 0, arr.Length - 1);

            string output = arr[0].ToString();

            for (int i = 1; i < arr.Length; i++)
            {
                output = output + ", " + arr[i].ToString();
            }

            Console.WriteLine("Sorted array: ");
            Console.WriteLine(output);

            //QuickSort
            //var line = string.Empty;
            //while (line.ToLower() != "exit")
            //{
            //    Console.WriteLine("Enter an array: ");
            //    line = Console.ReadLine();
            //    if (line == "exit")
            //        continue;
            //    int[] arr = Array.ConvertAll(line.Split(" "), int.Parse);
            //    Console.WriteLine(">");
            //    QuickSort(arr, 0, arr.Length - 1);

            //    string output = arr[0].ToString();

            //    for (int i = 1; i < arr.Length; i++)
            //    {
            //        output = output + ", " + arr[i].ToString();
            //    }

            //    Console.WriteLine("Sorted array: ");
            //    Console.WriteLine(output);
            //}
        }

        public static void QuickSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                var pivotIndex = Partition(arr, start, end);
                QuickSort(arr, start, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, end);
            }
        }

        public static int Partition(int[] arr, int start, int end)
        {
            var pivot = arr[end];
            var positionIndex = start;

            for (int i = start; i < end; i++)
            {
                if (arr[i].CompareTo(pivot) <= 0)
                {
                    Swap(arr, i, positionIndex);
                    positionIndex++;
                }
            }
            Swap(arr, positionIndex, end);
            return positionIndex;
        }

        // [4 8 1 9 *3* 7 5 2]
        //  0 1 2 3  4  5 6 7 

        // [1 8 4 9 *3* 7 5 2]
        //  0 1 2 3  4  5 6 7 

        // [1 2 4 9 *3* 7 5 8]
        //  0 1 2 3  4  5 6 7 

        // [1 2 *3* 9 4 7 5 8]
        //  0 1  2  3 4 5 6 7 

        //choose pivot *middle index
        //traverse array 
        //if less than pivot, swap to next slot on left.
        //iterate left slot index.
        //if greater than equal to pivot, swap to next slot on right.
        //iterate right slot index.
        //Call Quicksort on sub array


        public static void Swap(int[] arr, int index1, int index2)
        {
            var placeholder = arr[index2];
            arr[index2] = arr[index1];
            arr[index1] = placeholder;
        }
        public static void Merge(int[] arr, int start, int end)
        {
            int mid = (start + end) / 2;

            int i = start;
            int j = mid + 1;
            int k = start;

            int[] temp = new int[100];

            while (i <= mid && j <= end)
            {
                if (arr[i] < arr[j])
                {
                    temp[k++] = arr[i++];
                }
                else
                {
                    temp[k++] = arr[j++];
                }
            }
            while (i <= mid)
            {
                temp[k++] = arr[i++];
            }
            while (j <= end)
            {
                temp[k++] = arr[j++];
            }

            for (int l = start; l <= end; l++)
            {
                arr[l] = temp[l];
            }
        }

        public static void MergeSort(int[] arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int mid = (start + end) / 2;

            MergeSort(arr, start, mid);
            MergeSort(arr, mid + 1, end);

            Merge(arr, start, end);
        }

    }
}
