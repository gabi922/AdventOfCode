namespace AdventOfCode2017.Day18.Instructions
{
    public class Snd2Instruction : IInstruction
    {
        public string X { get; set; }

        public void Execute(ProcessingContext context)
        {
            context.SendBuffer.Enqueue(context.GetValue(X));
            context.SentValues++;
            context.PC++;
        }
    }
}
