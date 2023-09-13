namespace ConsoleApp1.UI
{
    public interface IOutput
    {
        public void Print(string text);
        public string Input();
        public void Clear();
        public void ChangeColor();
    }
}
