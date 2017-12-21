using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Day21
{
    public class FractalArt
    {
        public int Generate(string[] lines)
        {
            var image = new int[,] { { '.', '#', '.' }, { '.', '.', '#' }, { '#', '#', '#' } };
            var rules = GetRules(lines);

            for (var idx = 0; idx < 2; idx++)
            {
                var length = image.GetLength(0);
                var patternSize = length % 2 == 0 ? 2 : 3;
                var patternsPerLine = length / patternSize;

                // split matrix into patterns of size 2x2 or 3x3
                var patterns = new List<int[,]>();

                for (var i = 0; i < length; i += patternSize)
                {
                    for (var j = 0; j < length; j += patternSize)
                    {
                        var pattern = new int[patternSize, patternSize];

                        for (var k = 0; k < patternSize; k++)
                        {
                            for (var l = 0; l < patternSize; l++)
                            {
                                pattern[k, l] = image[i + k, j + l];
                            }
                        }

                        patterns.Add(pattern);
                    }
                }

                // apply rules
                var resultingPatterns = patterns.Select(p => ApplyMatchingRule(p, rules)).ToList();

                // combine patterns into new matrix
                var newPatternSize = patternSize + 1;
                var currentPattern = 0;
                image = new int[patternsPerLine * newPatternSize, patternsPerLine * newPatternSize];
                
                for (var i = 0; i < patternsPerLine; i += newPatternSize)
                {
                    for (var j = 0; j < patternsPerLine; j += newPatternSize, currentPattern++)
                    {
                        var pattern = resultingPatterns[currentPattern];

                        for (var k = 0; k < newPatternSize; k++)
                        {
                            for (var l = 0; l < newPatternSize; l++)
                            {
                                image[i + k, j + l] = pattern[k, l];
                            }
                        }
                    }
                }
            }

            var count = 0;
            for (var i = 0; i < image.GetLength(0); i++)
            {
                for (var j = 0; j < image.GetLength(0); j++)
                {
                    if (image[i, j] == '#')
                    {
                        count++;
                    }
                }
            }


            return count;
        }

        public int[,] Rotate90(int[,] input)
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

        public int[,] Rotate180(int[,] input)
        {
            return Rotate90(Rotate90(input));
        }

        public int[,] Rotate270(int[,] input)
        {
            return Rotate90(Rotate90(Rotate90(input)));
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
                    AreEqual(FlipVertically(input), rule.Item1) || AreEqual(Rotate90(input), rule.Item1)
                    || AreEqual(Rotate180(input), rule.Item1) || AreEqual(Rotate270(input), rule.Item1))
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
