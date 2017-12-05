using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Day2
{
    public class ChecksumCalculator
    {
        public int GetChecksum(List<List<int>> rows)
        {
            return rows.Select(r => r.Max() - r.Min()).Sum();
        }

        public int GetChecksum2(List<List<int>> rows)
        {
            return rows.Select(row =>
            {
                for (int i = 0; i < row.Count; i++)
                {
                    for (int j = 0; j < row.Count; j++)
                    {
                        if (i != j && row[i] % row[j] == 0)
                        {
                            return row[i] / row[j];
                        }
                    }
                }

                return 0;
            }).Sum();
        }
    }
}
