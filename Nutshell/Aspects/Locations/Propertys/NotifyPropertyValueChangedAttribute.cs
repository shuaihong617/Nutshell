using PostSharp.Aspects;
using System;

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

                        var i = args.Instance as NotifyPropertyValueChangedObject;
                        if (i == null)
                        {
                                throw new ArgumentException("必须为NotifyPropertyValueChangedObject或其子类");
                        }

                        i.OnPropertyValueChanged(args.LocationName);
                }
        }
}