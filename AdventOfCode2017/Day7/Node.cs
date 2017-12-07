using System.Collections.Generic;

namespace AdventOfCode2017.Day7
{
    public class Node
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public List<Node> Children { get; set; } = new List<Node>();
        public int TotalWeight { get; private set; }

        public Node SetTotalWeight(int totalWeight)
        {
            TotalWeight = totalWeight;
            return this;
        }
    }
}
