using Nutshell.Commanding;

namespace Nutshell.YiDingRobot.Commanding
{
	public class YiDingCommandKeywords
	{
		#region 常量

		public const byte Operations = (0xF0);
		public const byte Parameters = (0xF1);

		public const byte Connect = (0xFF);

		public const byte Forward = (0x01);
		public const byte Backward = (0x02);
		public const byte Leftward = (0x03);
		public const byte Rightward = (0x04);
		public const byte Round = (0x05);
		public const byte Brake = (0x06);

		public const byte AutomaticCharging = (0x07);
		public const byte TimeUnlock = (0x08);
		public const byte TimeLock = (0x09);
		public const byte TimeSynchronization = (0x0A);

		public const byte Led = (0x01);
		public const byte Battery = (0x02);
		public const byte ChargingPile = (0x03);
		public const byte Motor = (0x04);
		public const byte Sanor = (0x05);

		public const byte Successed = (0x01);
		public const byte Failed = (0x00);

		#endregion
	}
}
