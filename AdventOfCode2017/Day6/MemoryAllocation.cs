using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Day6
{
    public class MemoryAllocation
    {
        public int Reallocate(List<int> input)
        {
            int steps = 0;
            var previousConfigurations = new List<List<int>>();

            while (!previousConfigurations.Any(l => l.SequenceEqual(input)))
            {
                previousConfigurations.Add(new List<int>(input));
                doReallocationStep(input);
                steps++;
            }

            return steps;
        }

        public int Reallocate2(List<int> input)
        {
            Reallocate(input);

            var target = new List<int>(input);
            var steps = 0;

            do
            {
                doReallocationStep(input);
                steps++;
            } while (!target.SequenceEqual(input));

            return steps;
        }

        private void doReallocationStep(List<int> input)
        {
            int maxValue = input.Max();
            int maxIndex = input.IndexOf(maxValue);

            input[maxIndex] = 0;
            var index = (maxIndex + 1) % input.Count;

            while (maxValue > 0)
            {
                input[index]++;
                index = (index + 1) % input.Count;
                maxValue--;
            }
        }
    }
}
