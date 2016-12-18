using System;
using PostSharp.Aspects;

namespace Nutshell.Aspects.Locations.Propertys
{
        [AttributeUsage(AttributeTargets.Property)]
        public class NotifyPropertyChangedAttribute : LocationInterceptionAspect
        {
                public override void OnSetValue(LocationInterceptionArgs args)
                {
                        if (args.Value.Equals(args.GetCurrentValue()))
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
