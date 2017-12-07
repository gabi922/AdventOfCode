using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Day7
{
    public class RecursiveCircus
    {
        public Node BuildTree(string[] lines)
        {
            var nodes = new List<Node>();

            foreach (var line in lines)
            {
                var parts = line.Split("->");
                var nameWeight = parts[0].Trim().Split(" ");

                var name = nameWeight[0];
                var weight = int.Parse(nameWeight[1].Trim('(', ')'));
                var childrenNames = parts.Length > 1 ? parts[1].Trim().Split(", ") : new string[0];

                var node = nodes.FirstOrDefault(n => n.Name == name);
                if (node == null)
                {
                    node = new Node() { Name = name };
                    nodes.Add(node);
                }

                node.Weight = weight;

                foreach (var childName in childrenNames)
                {
                    var child = nodes.FirstOrDefault(n => n.Name == childName);
                    if (child == null)
                    {
                        child = new Node() { Name = childName };
                        nodes.Add(child);
                    }

                    node.Children.Add(child);
                }
            }

            return nodes.Single(n1 => !nodes.Any(n2 => n2.Children.Any(c => c.Name == n1.Name)));
        }

        public int GetUnbalancedNodeNewWeight(Node tree)
        {
            var extendedTree = calculateTotalWeights(tree);
            var parent = findUnbalancedNodeParent(extendedTree);
            if (parent == null)
            {
                throw new Exception("Tree is already balanced");
            }

            var targetChild = parent.Children
                .GroupBy(c => c.TotalWeight, (key, g) => new { TotalWeight = key, Elements = g.ToList() })
                .Single(c => c.Elements.Count == 1).Elements.Single();

            var childrenWeight = targetChild.Children.Sum(c => c.TotalWeight);
            var sibling = parent.Children.FirstOrDefault(c => c != targetChild);
            if (sibling == null)
            {
                throw new Exception("The node is already balanced");
            }

            return sibling.TotalWeight - childrenWeight;
        }

        private Node calculateTotalWeights(Node node)
        {
            if (node.Children.Count == 0)
            {
                return node.SetTotalWeight(node.Weight);
            }

            return node.SetTotalWeight(node.Children.Sum(c => calculateTotalWeights(c).TotalWeight) + node.Weight);
        }

        private Node findUnbalancedNodeParent(Node node)
        {
            if (node.Children.Count == 0 || node.Children.All(c => c.TotalWeight == node.Children.First().TotalWeight))
            {
                return null;
            }

            var childrenResults = node.Children.Select(c => findUnbalancedNodeParent(c));
            return childrenResults.FirstOrDefault(r => r != null) ?? node;
        }
    }
}
