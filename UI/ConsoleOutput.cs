namespace ConsoleApp1.UI
{
    internal class ConsoleOutput: IOutput
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }
        public string Input()
        {
            return Console.ReadLine();
        }
        public void Clear()
        {
            Console.Clear();
        }

        public void ChangeColor()
        {
            Array colors = Enum.GetValues(typeof(ConsoleColor));
            Random random = new Random();
            ConsoleColor randomColor = (ConsoleColor)colors.GetValue(random.Next(colors.Length));
            Console.ForegroundColor = randomColor;
        }
    }
}
