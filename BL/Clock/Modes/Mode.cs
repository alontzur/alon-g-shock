using ConsoleApp1.UI;

namespace ConsoleApp1.BL.Clock.Modes
{
    public abstract class Mode
    {
        protected IOutput _outputer;
        protected Mode(IOutput output)
        {
            _outputer = output;
        }
        public abstract void OnStart();
        public abstract void OnClose();
        public abstract void ButtonA();
        public abstract void ButtonB();
        public virtual void ButtonC()
        {
            _outputer.ChangeColor();
        }
    }
}
