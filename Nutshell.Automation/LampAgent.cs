namespace Nutshell.Automation.Agents
{
        public class LampAgent : ElectronicAgent
        {

                public LampAgent(string id = "")
                        : base(id)
                {
                }

                public bool IsBlink { get; set; } = false;

                public ElectronicState BlinkCompleteState { get; set; }

                

                
        }
}
