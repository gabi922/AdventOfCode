namespace AdventOfCode2017.Day3
{
    public class RingElement
    {
        public int Value { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public RingElement(int value, int x, int y)
        {
            Value = value;
            X = x;
            Y = y;
        }
    }
}
