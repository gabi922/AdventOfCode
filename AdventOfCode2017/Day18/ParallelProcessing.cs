using AdventOfCode2017.Day18.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Day18
{
    public class ParallelProcessing
    {
        public long Process(string[] lines)
        {
            var context = new ProcessingContext();
            var instructions = getInstructions(lines);

            while (!context.Stopped)
            {
                var instruction = instructions[context.PC];
                instruction.Execute(context);
            }

            return context.Sound;
        }

        public int Process2(string[] lines)
        {
            var q1 = new Queue<long>();
            var q2 = new Queue<long>();

            var context1 = new ProcessingContext() { SendBuffer = q1, RecvBuffer = q2 };
            var context2 = new ProcessingContext() { SendBuffer = q2, RecvBuffer = q1 };

            context1.Registers["p"] = 0;
            context2.Registers["p"] = 1;

            var instructions = getInstructions(lines, true);

            while (context1.Running || context2.Running)
            {
                if (context1.PC < instructions.Count)
                {
                    var i1 = instructions[context1.PC];
                    i1.Execute(context1);
                }
                else
                {
                    context1.Stopped = true;
                }

                if (context2.PC < instructions.Count)
                {
                    var i2 = instructions[context2.PC];
                    i2.Execute(context2);
                }
                else
                {
                    context2.Stopped = true;
                }
            }

            return context2.SentValues;
        }

        private List<IInstruction> getInstructions(string[] lines, bool parallelProcessing = false)
        {
            return lines.Select<string, IInstruction>(line => {
                var parts = line.Split(' ');

                switch (parts[0])
                {
                    case "snd":
                        if (parallelProcessing)
                        {
                            return new Snd2Instruction() { X = parts[1] };
                        }
                        return new SndInstruction() { X = parts[1] };
                    case "rcv":
                        if (parallelProcessing)
                        {
                            return new Rcv2Instruction() { X = parts[1] };
                        }
                        return new RcvInstruction() { X = parts[1] };
                    case "set":
                        return new SetInstruction() { X = parts[1], Y = parts[2] };
                    case "add":
                        return new AddInstruction() { X = parts[1], Y = parts[2] };
                    case "mul":
                        return new MulInstruction() { X = parts[1], Y = parts[2] };
                    case "jgz":
                        return new JgzInstruction() { X = parts[1], Y = parts[2] };
                    case "mod":
                        return new ModInstruction() { X = parts[1], Y = parts[2] };
                    default:
                        throw new ArgumentException($"Unknown instruction name: {parts[0]}");
                }
            }).ToList();
        }
    }
}
