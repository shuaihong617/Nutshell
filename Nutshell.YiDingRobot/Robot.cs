namespace Nutshell.YiDingRobot
{
	public class Robot:IdentityObject
	{
		public Authorization Authorization { get; private set; } = new Authorization();

		public Underpan Underpan { get; private set; } = new Underpan();
	}
}