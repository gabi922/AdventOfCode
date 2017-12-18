using System.Collections.Generic;

namespace AdventOfCode2017.Day18
{
    public class ProcessingContext
    {
        public int PC { get; set; }

        public long Sound { get; set; }

        public bool Stopped { get; set; }

        public bool Waiting { get; set; }

        public bool Running => !Stopped && !Waiting;

        public Queue<long> SendBuffer { get; set; }

        public Queue<long> RecvBuffer { get; set; }

        public int SentValues { get; set; }

        public Dictionary<string, long> Registers { get; set; } = new Dictionary<string, long>();

        public long GetValue(string nameOrValue)
        {
            if (long.TryParse(nameOrValue, out long result))
            {
                return result;
            }

            return Registers.GetValueOrDefault(nameOrValue);
        }
    }
}
