using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017.Day8
{
    public static class ExtenstionMethods
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue value;
            return dictionary.TryGetValue(key, out value) ? value : default(TValue);
        }
    }

    public class Registers
    {
        public int GetMaximumRegisterValue(string[] instructions, out int allTimeMax)
        {
            var registers = new Dictionary<string, int>();
            var regex = new Regex(@"(?<reg1>.+) (?<op>inc|dec) (?<val1>.+) if (?<reg2>.+) (?<cond>.+) (?<val2>.+)");

            allTimeMax = int.MinValue;

            foreach (var instruction in instructions)
            {
                var match = regex.Match(instruction);
                if (!match.Success)
                {
                    throw new Exception($"Invalid instruction: {instruction}");
                }

                var reg1 = match.Groups["reg1"].Value;
                var reg2 = match.Groups["reg2"].Value;
                var val1 = int.Parse(match.Groups["val1"].Value);
                var val2 = int.Parse(match.Groups["val2"].Value);

                var condition = getCondition(match.Groups["cond"].Value);
                if (!condition(registers.GetValueOrDefault(reg2), val2))
                {
                    continue;
                }

                Func<int, int, int> op = (a, b) => match.Groups["op"].Value == "inc" ? a + b : a - b;
                registers[reg1] = op(registers.GetValueOrDefault(reg1), val1);
                if (registers[reg1] > allTimeMax)
                {
                    allTimeMax = registers[reg1];
                }
            }

            return registers.Values.Max();
        }

        private Func<int, int, bool> getCondition(string cond)
        {
            switch (cond)
            {
                case ">":
                    return (regValue, value) => regValue > value;
                case "<":
                    return (regValue, value) => regValue < value;
                case ">=":
                    return (regValue, value) => regValue >= value;
                case "<=":
                    return (regValue, value) => regValue <= value;
                case "==":
                    return (regValue, value) => regValue == value;
                case "!=":
                    return (regValue, value) => regValue != value;
                default:
                    throw new Exception("Unknown condition");
            }
        }
    }
}
