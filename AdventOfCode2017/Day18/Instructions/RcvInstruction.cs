namespace AdventOfCode2017.Day18.Instructions
{
    public class RcvInstruction : IInstruction
    {
        public string X { get; set; }

        public void Execute(ProcessingContext context)
        {
            if (context.GetValue(X) != 0)
            {
                context.Stopped = true;
            }
            context.PC++;
        }
    }
}
