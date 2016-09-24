using System;
using Nutshell.Data;
using PostSharp.Aspects;

namespace Nutshell.Aspects.Propertys
{
        [Serializable]
        public class NotifyChangedPropertyAttribute : EqualCheckPropertyAttribute
        {
                public override void OnSetValue(LocationInterceptionArgs args)
                {
                        // args.Instance contains the object whose property or field is loaded (null if the location is static).
                        // args.Value contains the new value that needs to be assigned to the underlying field or property.
                        // args.GetCurrentValue to get the current value of the field of property.

                        // Before calling base.OnSetValue, you can change args.Value to another value as long as it is compatible with the type of 
                        // the underlying field or property.

                        base.OnSetValue(args); // This is equivalent to doing args.ProceedSetValue

                        var n = args.Instance as NotifyPropertyChangedObject;
                        if (n == null)
                        {
                                throw new ArgumentException("必须为NotifyPropertyChangedObject或其子类");
                        }
                        n.RaisePropertyChanged(args.LocationName);
                }
        }
}
