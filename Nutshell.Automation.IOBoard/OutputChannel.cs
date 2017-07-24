namespace Nutshell.Automation.IOBoard
{
        public abstract class OutputChannel : Channel
        {
                protected OutputChannel(int index)
                        : base(index)
                {
                }

                public abstract void Write(int data);
        }
}
