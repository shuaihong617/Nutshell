using System;
using System.ComponentModel;
using Nutshell.Extensions;

namespace Nutshell.Automation
{
        public class LampDevice : ElectronicDevice
        {

                public LampDevice(string id = "")
                        : base(id)
                {
                }

                public bool IsBlink { get; set; } = false;

                public ElectronicState BlinkCompleteState { get; set; }

                

                
        }
}
