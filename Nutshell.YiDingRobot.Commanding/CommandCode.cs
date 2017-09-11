namespace Nutshell.YiDingRobot.Commanding
{
	public enum CommandCode
	{
		Connect = YiDingCommandKeywords.Operations << 8 + YiDingCommandKeywords.Connect,

		Forward = YiDingCommandKeywords.Operations << 8 + YiDingCommandKeywords.Forward,
		Backward = YiDingCommandKeywords.Operations << 8 + YiDingCommandKeywords.Backward,
		Leftward = YiDingCommandKeywords.Operations << 8 + YiDingCommandKeywords.Leftward,
		Rightward = YiDingCommandKeywords.Operations << 8 + YiDingCommandKeywords.Rightward,
		Round = YiDingCommandKeywords.Operations << 8 + YiDingCommandKeywords.Round,
		Brake = YiDingCommandKeywords.Operations << 8 + YiDingCommandKeywords.Brake,

		AutomaticCharging = YiDingCommandKeywords.Operations << 8 + YiDingCommandKeywords.AutomaticCharging,
		TimeUnlock = YiDingCommandKeywords.Operations << 8 + YiDingCommandKeywords.TimeUnlock,
		TimeLock = YiDingCommandKeywords.Operations << 8 + YiDingCommandKeywords.TimeLock,
		TimeSynchronization = YiDingCommandKeywords.Operations << 8 + YiDingCommandKeywords.TimeSynchronization,

		Led =  YiDingCommandKeywords.Operations << 8 + YiDingCommandKeywords.Led,
		Battery = YiDingCommandKeywords.Operations << 8 + YiDingCommandKeywords.Battery,
		ChargingPile = YiDingCommandKeywords.Operations << 8 + YiDingCommandKeywords.ChargingPile,
		Motor = YiDingCommandKeywords.Operations << 8 + YiDingCommandKeywords.Motor,
		Sanor = YiDingCommandKeywords.Operations << 8 + YiDingCommandKeywords.Sanor,
	}
}