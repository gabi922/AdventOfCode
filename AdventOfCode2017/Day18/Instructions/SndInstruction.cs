namespace AdventOfCode2017.Day18.Instructions
{
    public class SndInstruction : IInstruction
    {
        public string X { get; set; }

        public void Execute(ProcessingContext context)
        {
            context.Sound = context.GetValue(X);
            context.PC++;
        }
    }
}
