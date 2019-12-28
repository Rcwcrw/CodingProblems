using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class AdjacencyMatrixService
    {
        public void ConsoleRun()
        {
            var matrix = InitializeMatrix();

            matrix = FillMatrix(matrix, blankSpaces);

            //matrix = SovlePuzzle(matrix, words);

            PrintMatrix(matrix);
        }

        public readonly string[] blankSpaces = { "---------", "-------", "-------", "----", "------", "---------" };

        public readonly string[] words = { "CHEMISTRY", "PHYSICS", "HISTORY", "MATH", "CIVICS", "GEOGRAPHY" };

        public string[][] InitializeMatrix()
        {
            var matrix = new string[10][];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new string[10];
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = "+";
                }
            }

            return matrix;
        }


        public int[,] AddToGraph(int[,] graph, int from, int to)
        {
            graph[from, to] = 1;

            return graph;
        }

        public string[][] PlaceWordHorizontal(string[][] graph, int startRow, int startColumn, string word)
        {
            var letterIndex = 0;
            for (int i = startColumn; i < word.Length + startColumn; i++)
            {
                graph[startRow][i] = word[letterIndex].ToString();
                letterIndex++;
            }

            return graph;
        }

        public string[][] PlaceWordVertical(string[][] graph, int startRow, int startColumn, string word)
        {
            var letterIndex = 0;
            for (int i = startRow; i < word.Length + startRow; i++)
            {
                graph[i][startColumn] = word[letterIndex].ToString();
                letterIndex++;
            }

            return graph;
        }

        public string[][] FillMatrix(string[][] matrix, string[] words)
        {
            matrix = PlaceWordVertical(matrix, 0, 9, words[0]);
            matrix = PlaceWordVertical(matrix, 1, 0, words[1]);
            matrix = PlaceWordHorizontal(matrix, 2, 0, words[2]);
            matrix = PlaceWordHorizontal(matrix, 5, 5, words[3]);
            matrix = PlaceWordHorizontal(matrix, 6, 0, words[4]);
            matrix = PlaceWordHorizontal(matrix, 8, 1, words[5]);

            return matrix;
        }

        public void PrintMatrix(string[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                var row = "";
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    row += matrix[i][j];
                }
                Console.WriteLine(row);
            }
        }
    }

    [TestFixture]
    public class AdjacencyMatrixServiceTests
    {
        public AdjacencyMatrixService service = new AdjacencyMatrixService();

        [Test]
        public void AdjacencyMatrixServiceTest1()
        {
            var given = new int[6,6];
            var expected = new int[6,6];
            expected[5,5] = 1;
            Assert.AreEqual(expected, service.AddToGraph(given, 5, 5));
        }
    }
}
