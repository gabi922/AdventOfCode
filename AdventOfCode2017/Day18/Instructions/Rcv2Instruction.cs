namespace AdventOfCode2017.Day18.Instructions
{
    public class Rcv2Instruction : IInstruction
    {
        public string X { get; set; }

        public void Execute(ProcessingContext context)
        {
            if (context.RecvBuffer.Count > 0)
            {
                context.Registers[X] = context.RecvBuffer.Dequeue();
                context.PC++;
                context.Waiting = false;
            }
            else
            {
                context.Waiting = true;
            }
        }
    }
}
