using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Day21
{
    public class FractalArt
    {
        public int Generate(string[] lines)
        {
            var pattern = new int[,] { { '.', '#', '.' }, { '.', '.', '#' }, { '#', '#', '#' } };
            var rules = GetRules(lines);









            return 0;
        }

        public int[,] Rotate90(int [,] input)
        {
            var length = input.GetLength(0);
            var result = new int[length, length];

            int x = 0;
            for (var i = 0; i < length; i++)
            {
                for (var j = length - 1; j >= 0; j--)
                {
                    result[i, x++] = input[j, i];
                }
                x = 0;
            }

            return result;
        }

        public int[,] FlipHorizontally(int[,] input)
        {
            var length = input.GetLength(0);
            var result = (int[,])input.Clone();

            for (var i = 0; i < length; i++)
            {
                for (var j = 0; j < length / 2; j++)
                {
                    result[i, j] = input[i, length - j - 1];
                    result[i, length - j - 1] = input[i, j];
                }
            }

            return result;
        }

        public int[,] FlipVertically(int[,] input)
        {
            var length = input.GetLength(0);
            var result = (int[,])input.Clone();

            for (var i = 0; i < length / 2; i++)
            {
                for (var j = 0; j < length; j++)
                {
                    result[i, j] = input[length - i - 1, j];
                    result[length - i - 1, j] = input[i, j];
                }
            }

            return result;
        }

        public bool AreEqual(int [,] matrix1, int [,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0))
            {
                return false;
            }

            for (var i = 0; i < matrix1.GetLength(0); i++)
            {
                for (var j = 0; j < matrix1.GetLength(0); j++)
                {
                    if (matrix1[i, j] != matrix2[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public int[,] ApplyMatchingRule(int[,] input, List<Tuple<int[,], int[,]>> rules)
        {
            foreach (var rule in rules)
            {
                if (AreEqual(input, rule.Item1) || AreEqual(FlipHorizontally(input), rule.Item1) ||
                    AreEqual(FlipVertically(input), rule.Item1) || AreEqual(Rotate90(input), rule.Item1))
                {
                    return rule.Item2;
                }
            }

            throw new Exception("No matching rule found");
        }

        public List<Tuple<int[,], int[,]>> GetRules(string[] lines)
        {
            var rules = new List<Tuple<int[,], int[,]>>();

            foreach(var line in lines)
            {
                var parts = line.Split(" => ");
                var inputMatrix = jaggedArrayToMatrix(parts[0].Split('/').Select(l => l.ToCharArray()).ToArray());
                var outputMatrix = jaggedArrayToMatrix(parts[1].Split('/').Select(l => l.ToCharArray()).ToArray());
                rules.Add(new Tuple<int[,], int[,]>(inputMatrix, outputMatrix));
            }

            return rules;
        }

        private int[,] jaggedArrayToMatrix(char[][] input)
        {
            var result = new int[input.Length, input.Length];

            for (var i = 0; i < input.Length; i++)
            {
                for (var j = 0; j < input.Length; j++)
                {
                    result[i, j] = input[i][j];
                }
            }

            return result;
        } 
    }
}
