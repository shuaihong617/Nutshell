using System;
using PostSharp.Aspects;
using PostSharp.Reflection;

namespace Nutshell.Aspects.Locations.Propertys
{
        public class EuqalSetDirectReturnAttribute : LocationInterceptionAspect
        {
                public EuqalSetDirectReturnAttribute()
                {
                }

                public override void OnSetValue(LocationInterceptionArgs args)
                {
                        if (args.Value.Equals(args.GetCurrentValue()))
                        {
                                return;
                        }

                        base.OnSetValue(args);
                }
        }
}
