using System;

namespace Nutshell.Automation.IOBoard
{
        public class ChannelValueEventArgs : EventArgs
        {
	        public ChannelValueEventArgs(int channelIndex, int value)
	        {
		        ChannelIndex = channelIndex;
		        Value = value;
	        }

                public int ChannelIndex { get; set; }

                public int Value { get; set; }

                public override string ToString()
                {
                        return $"通道:{ChannelIndex},值:{Value}";
                }
        }
}
