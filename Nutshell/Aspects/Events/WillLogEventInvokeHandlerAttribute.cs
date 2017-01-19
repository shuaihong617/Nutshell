// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-10-28
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-12-17
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Reflection;
using Nutshell.Extensions;
using PostSharp.Aspects;

namespace Nutshell.Aspects.Events
{
        /// <summary>
        /// 记录事件调用的特性类，该类不能被继承。
        /// </summary>
        [Serializable]
        public sealed class WillLogEventInvokeHandlerAttribute : EventInterceptionAspect
        {
                /// <summary>
                /// Method invoked when the event to which the current aspect is applied is fired, <i>for each</i> delegate
                /// of this event, and <i>instead of</i> invoking this delegate.
                /// </summary>
                /// <param name="args">Handler arguments.</param>
                /// <exception cref="System.ArgumentException">
                /// 必须为IdentityObject或其子类
                /// or
                /// EventName事件上找不到EventDescriptionAttribute
                /// </exception>
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

                        i.Info("引发" + d.Description);
                }
        }
}
