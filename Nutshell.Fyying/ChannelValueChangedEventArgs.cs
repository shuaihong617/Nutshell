using System;

namespace Nutshell.Fyying
{
        public class ChannelValueChangedEventArgs : EventArgs
        {
	        public ChannelValueChangedEventArgs(int channel, bool value)
	        {
		        Channel = channel;
		        Value = value;
	        }

                public int Channel { get; set; }

                public bool Value { get; set; }

                public override string ToString()
                {
                        return $"{Channel}通道：{Value}";
                }
        }
}
