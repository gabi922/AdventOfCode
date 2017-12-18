namespace AdventOfCode2017.Day18.Instructions
{
    public class JgzInstruction : IInstruction
    {
        public string X { get; set; }

        public string Y { get; set; }

        public void Execute(ProcessingContext context)
        {
            if (context.GetValue(X) > 0)
            {
                context.PC += (int)context.GetValue(Y);
            }
            else
            {
                context.PC++;
            }
        }
    }
}
