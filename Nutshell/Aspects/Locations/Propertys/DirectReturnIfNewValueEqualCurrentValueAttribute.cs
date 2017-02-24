using System;
using System.Diagnostics;
using PostSharp.Aspects;
using PostSharp.Reflection;

namespace Nutshell.Aspects.Locations.Propertys
{
	[Serializable]
	[AttributeUsage(AttributeTargets.Property)]
	public class DirectReturnIfNewValueEqualCurrentValueAttribute : LocationInterceptionAspect
        {
		protected bool IsSetSuccessed { get; set; }

                public override void OnSetValue(LocationInterceptionArgs args)
                {

	                IsSetSuccessed = !Equals(args.Value, args.GetCurrentValue());

	                if (IsSetSuccessed)
	                {
		                base.OnSetValue(args);
	                }
                }
        }
}
