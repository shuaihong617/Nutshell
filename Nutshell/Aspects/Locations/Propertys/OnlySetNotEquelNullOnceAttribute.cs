using System;
using PostSharp.Aspects;

namespace Nutshell.Aspects.Locations.Propertys
{
	[Serializable]
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class OnlySetNotEquelNullOnceAttribute : LocationInterceptionAspect
	{
		public override void OnSetValue(LocationInterceptionArgs args)
		{
			var current = args.GetCurrentValue();
			if (current != null)
			{
				throw new ArgumentException("属性" + args.LocationName + "的值不为空，不能重复设置。");
			}
			
			base.OnSetValue(args);
		}
	}
}
