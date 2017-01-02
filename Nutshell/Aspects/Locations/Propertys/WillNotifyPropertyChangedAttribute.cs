using System;
using PostSharp.Aspects;

namespace Nutshell.Aspects.Locations.Propertys
{
	[Serializable]
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class WillNotifyPropertyChangedAttribute : LocationInterceptionAspect
	{
		public override void OnSetValue(LocationInterceptionArgs args)
		{
			//Trace.WriteLine("args.Value : "  + args.Value);
			//Trace.WriteLine("args.GetCurrentValue : " +  args.GetCurrentValue());
			if (Equals(args.Value, args.GetCurrentValue()))
			{
				return;
			}

			base.OnSetValue(args);

			var i = args.Instance as NotifyPropertyChangedObject;
			if (i == null)
			{
				throw new ArgumentException("必须为IdentityObject或其子类");
			}

			i.OnPropertyChanged();
		}
	}
}
