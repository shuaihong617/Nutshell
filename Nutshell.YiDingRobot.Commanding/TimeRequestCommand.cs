namespace Nutshell.YiDingRobot.Commanding
{
        public class TimeRequestCommand:YiDingCommand
        {
		public byte Year{get;set;}
		public byte Month{get;set;}
		public byte Day{get;set;}
		public byte Hour{get;set;}
		public byte Minute{get;set;}
		public byte Second{get;set;}
	}
}