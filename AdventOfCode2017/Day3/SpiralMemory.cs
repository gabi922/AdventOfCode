using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Day3
{
    public class SpiralMemory
    {
        public int GetDistance(int inputElement)
        {
            var currentElement = 1;
            var ringState = new RingState();

            while (currentElement != inputElement)
            {
                ringState.NavigateRing();
                currentElement++;
            }

            return Math.Abs(ringState.X) + Math.Abs(ringState.Y);
        }

        public int GetDistance2(int input)
        {
            var currentElementValue = 1;
            var ringState = new RingState();

            var previousRingElements = new List<RingElement>();
            var currentRingElements = new List<RingElement>()
            {
                new RingElement(currentElementValue, 0, 0)
            };

            ringState.OnRingChange = () =>
            {
                previousRingElements = currentRingElements;
                currentRingElements = new List<RingElement>();
            };

            while (currentElementValue <= input)
            {
                ringState.NavigateRing();

                currentElementValue = previousRingElements.Concat(currentRingElements)
                    .Where(e => Math.Abs(ringState.X - e.X) <= 1 && Math.Abs(ringState.Y - e.Y) <= 1)
                    .Sum(e => e.Value);

                currentRingElements.Add(new RingElement(currentElementValue, ringState.X, ringState.Y));
            }

            return currentElementValue;
        }
    }
}
