using System;

namespace AdventOfCode2017.Day3
{
    public enum Action
    {
        IncreaseX, DecreaseX, IncreaseY, DecreaseY
    }

    public class SpiralMemory
    {
        public int GetDistance(int number)
        {
            int x = 0;
            int y = 0;
            int ring = 0;
            int ringRemainingElements = 0;
            int currentElement = 1;
            var nextAction = Action.IncreaseX;

            while (currentElement != number)
            {
                if (ringRemainingElements == 0)
                {
                    ring++;
                    ringRemainingElements = 8 * ring;
                    nextAction = Action.IncreaseX;
                }

                switch (nextAction)
                {
                    case Action.IncreaseX:
                        x++;
                        if (x == ring)
                        {
                            nextAction = Action.IncreaseY;
                        }
                        break;
                    case Action.IncreaseY:
                        y++;
                        if (y == ring)
                        {
                            nextAction = Action.DecreaseX;
                        }
                        break;
                    case Action.DecreaseX:
                        x--;
                        if (x == -ring)
                        {
                            nextAction = Action.DecreaseY;
                        }
                        break;
                    case Action.DecreaseY:
                        y--;
                        if (y == -ring)
                        {
                            nextAction = Action.IncreaseX;
                        }
                        break;
                }

                currentElement++;
                ringRemainingElements--;
            }

            return Math.Abs(x) + Math.Abs(y);
        }
    }
}
