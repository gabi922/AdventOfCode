using System.Collections.Generic;

namespace AdventOfCode2017.Day5
{
    public class Trampoline
    {
        public int PerformJumps(List<int> sequence)
        {
            var position = 0;
            var steps = 0;

            while (position >= 0 && position < sequence.Count)
            {
                position += sequence[position]++;
                steps ++;
            }

            return steps;
        }

        public int PerformJumps2(List<int> sequence)
        {
            var position = 0;
            var steps = 0;

            while (position >= 0 && position < sequence.Count)
            {
                var previousPosition = position;
                position += sequence[position];
                sequence[previousPosition] += (sequence[previousPosition] >= 3 ? -1 : +1);
                steps++;
            }

            return steps;
        }
    }
}
