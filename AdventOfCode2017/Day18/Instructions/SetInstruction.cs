namespace AdventOfCode2017.Day18.Instructions
{
    public class SetInstruction : IInstruction
    {
        public string X { get; set; }

        public string Y { get; set; }

        public void Execute(ProcessingContext context)
        {
            context.Registers[X] = context.GetValue(Y);
            context.PC++;
        }
    }
}
