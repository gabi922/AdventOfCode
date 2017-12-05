using System;

namespace AdventOfCode2017.Day3
{
    public class RingState
    {
        private int ring = 0;
        private int unvisitedElements = 0;
        private RingAction nextAction = RingAction.IncreaseX;

        public int X { get; private set; }
        public int Y { get; private set; }
        public Action OnRingChange { get; set; }

        public void NavigateRing()
        {
            if (unvisitedElements == 0)
            {
                setNextRingState();
                OnRingChange?.Invoke();
            }

            switch (nextAction)
            {
                case RingAction.IncreaseX:
                    X++;
                    if (X == ring)
                    {
                        nextAction = RingAction.IncreaseY;
                    }
                    break;
                case RingAction.IncreaseY:
                    Y++;
                    if (Y == ring)
                    {
                        nextAction = RingAction.DecreaseX;
                    }
                    break;
                case RingAction.DecreaseX:
                    X--;
                    if (X == -ring)
                    {
                        nextAction = RingAction.DecreaseY;
                    }
                    break;
                case RingAction.DecreaseY:
                    Y--;
                    if (Y == -ring)
                    {
                        nextAction = RingAction.IncreaseX;
                    }
                    break;
            }

            unvisitedElements--;
        }

        private void setNextRingState()
        {
            ring++;
            unvisitedElements = 8 * ring;
            nextAction = RingAction.IncreaseX;
        }
    }
}
