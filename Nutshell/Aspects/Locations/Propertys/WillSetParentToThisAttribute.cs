using System;
using PostSharp.Aspects;

namespace Nutshell.Aspects.Locations.Propertys
{
	[Serializable]
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class WillSetParentToThisAttribute : LocationInterceptionAspect
	{
		public override void OnSetValue(LocationInterceptionArgs args)
		{
			var master = args.Instance as IIdentityObject;
			if (master == null)
			{
				throw new ArgumentException("设置属性" + args.LocationName + "的对象" + args.Instance + "必须为IIdentityObject接口的派生类");
			}

			var slave = args.Value as IIdentityObject;
			if (slave == null)
			{
				throw new ArgumentException("对象"+master + "设置的属性"+ args.LocationName +"必须为IIdentityObject接口的派生类");
			}

			base.OnSetValue(args);
			slave.Parent = master;
		}
	}
}
