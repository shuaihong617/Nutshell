namespace Nutshell.YiDingRobot.Commanding
{
	public class ConnectResponseCommand : ResponseCommand
	{
		public byte ProtocolVersion { get; set; }
		public byte[] Model { get; set; } = new byte[12];
		public ushort FirmwareVersion { get; set; }
		public ushort HardwareVersion { get; set; }
		public uint[] SerialNumber { get; set; } = new uint[3];
	}
} 

