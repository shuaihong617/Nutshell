using System;
using System.Diagnostics;
using PostSharp.Aspects;

namespace Nutshell.Aspects.Locations.Propertys
{
	[Serializable]
	[AttributeUsage(AttributeTargets.Property)]
	public class NotifyPropertyValueChangedAttribute : DirectReturnIfNewValueEqualCurrentValueAttribute
	{
		public sealed override void OnSetValue(LocationInterceptionArgs args)
		{
			base.OnSetValue(args);

			if (!IsSetSuccessed)
			{
				return;
			}

			var i = args.Instance as NotifyPropertyChangedObject;
			if (i == null)
			{
				throw new ArgumentException("必须为IdentityObject或其子类");
			}

			i.OnPropertyChanged(args.LocationName);
		}
	}
}
