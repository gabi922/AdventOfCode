﻿using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Test
{
    public class Utils
    {
        public static List<List<int>> ReadRows(string fileName)
        {
            return File.ReadAllLines(fileName)
                .Select(line => line.Split(' ', '\t')
                              .Select(element => int.Parse(element))
                              .ToList())
                .ToList();
        }
    }
}