using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Test
{
    public class Utils
    {
        public static List<List<int>> ReadMatrix(string fileName)
        {
            return File.ReadAllLines(fileName)
                .Select(line => line.Split(' ', '\t')
                              .Select(element => int.Parse(element))
                              .ToList())
                .ToList();
        }

        public static List<string> ReadLines(string fileName)
        {
            return File.ReadAllLines(fileName).ToList();
        }

        public static List<int> ReadArray(string fileName)
        {
            return ReadMatrix(fileName).SelectMany(l => l).ToList();
        }
    }
}
