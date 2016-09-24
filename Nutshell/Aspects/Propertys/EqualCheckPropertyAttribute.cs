using System;
using Nutshell.Data;
using PostSharp.Aspects;

namespace Nutshell.Aspects.Propertys
{
        [Serializable]
        public class EqualCheckPropertyAttribute : LocationInterceptionAspect
        {
                public override void OnSetValue(LocationInterceptionArgs args)
                {
                        if (Equals(args.Value,args.GetCurrentValue()))
                        {
                             return;   
                        }

                        base.OnSetValue(args);
                }
        }
}
