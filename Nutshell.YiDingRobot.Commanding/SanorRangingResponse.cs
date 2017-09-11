namespace Nutshell.YiDingRobot.Commanding
{
	public class SanorRangingResponseCommand:ResponseCommand
	{
		public ushort Distance1 { get; set; }
		public ushort Distance2 { get; set; }
		public ushort Distance3 { get; set; }
		public ushort Distance4 { get; set; }
	}
}