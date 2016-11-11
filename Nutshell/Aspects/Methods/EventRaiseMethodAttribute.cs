using System;
using System.Reflection;
using Nutshell.Aspects.Events;
using Nutshell.Data;
using Nutshell.Log;
using PostSharp.Aspects;

namespace Nutshell.Aspects.Methods
{
        [Serializable]
        [AttributeUsage(AttributeTargets.Method)]
        public sealed class EventRaiseMethodAttribute : OnMethodBoundaryAspect
        {
                public EventRaiseMethodAttribute(string evnetName)
                {
                        EventName = evnetName;
                }

                public string EventName { get; private set; }

                public override void OnEntry(MethodExecutionArgs args)
                {
                        var i = args.Instance as IdentityObject;
                        if (i == null)
                        {
                                throw new ArgumentException("必须为IdentityObject或其子类");
                        }

                        var t = i.GetType();

                        var e = t.GetEvent(EventName);
                        if (e == null)
                        {
                                throw new ArgumentException("必须定义EventName事件");
                        }

                        
                }
        }
}
