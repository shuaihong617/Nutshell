namespace Nutshell.YiDingRobot.Commanding
{
	public class MotorsResponseCommand : YiDingCommand
	{
		public ushort LeftStandardSpeed { get; set; }
		public ushort LeftPracticeSpeed { get; set; }
		public ushort RightStandardSpeed { get; set; }
		public ushort RightPracticeSpeed { get; set; }
	}
}