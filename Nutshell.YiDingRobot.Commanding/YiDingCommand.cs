using Nutshell.Commanding;

namespace Nutshell.YiDingRobot.Commanding
{
	public class YiDingCommand : Command
	{
		public const ushort Head = 0x55AA;

		public CommandCode CommandCode { get; set; }

		public byte[] Payload { get; set; }

		public byte SumCheck { get;private set; }

		public bool IsCheckPassed { get; private set; }

		public void Check()
		{
			
		}
	}
}
