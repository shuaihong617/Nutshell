using System;
using System.ComponentModel;
using System.Reflection;
using Nutshell.Log;
using PostSharp.Aspects;

namespace Nutshell.Aspects.Events
{
        public sealed class LogEventInvokeAttribute : EventInterceptionAspect
        {
                public override void OnInvokeHandler(EventInterceptionArgs args)
                {
                        base.OnInvokeHandler(args);

                        var i = args.Instance as IdentityObject;
                        if (i == null)
                        {
                                throw new ArgumentException("必须为IdentityObject或其子类");
                        }

                        var d = args.Event.GetCustomAttribute(typeof(DescriptionAttribute), true) as DescriptionAttribute;
                        if (d == null)
                        {
                                throw new ArgumentException("EventName事件上找不到EventDescriptionAttribute");
                        }

                        i.Info("引发" + d.Description + "事件。");
                }
        }
}
