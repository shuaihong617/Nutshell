namespace Nutshell.YiDingRobot.Commanding
{
        public class TimeUnlockRequestCommand:YiDingCommand
        {
                 public byte[] SerialNumber { get; set; } = new byte[24];
	}
}