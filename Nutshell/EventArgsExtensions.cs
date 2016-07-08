// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-01-18
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-12-12
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************


using System;
using System.Threading;

namespace Nutshell
{
        /// <summary>
        ///         EventArgs Extensions
        /// </summary>
        public static class EventArgsExtensions
        {
                /// <summary>
                ///         Raises the specified decimal.
                /// </summary>
                /// <typeparam name="TEventArgs">The type of the event arguments.</typeparam>
                /// <param name="e">The decimal.</param>
                /// <param name="sender">The sender.</param>
                /// <param name="eventDelegate">The event delegate.</param>
                public static void Raise<TEventArgs>(this TEventArgs e, Object sender,
                        ref EventHandler<TEventArgs> eventDelegate)
                        where TEventArgs : EventArgs
                {
                        EventHandler<TEventArgs> handler = Interlocked.CompareExchange(ref eventDelegate, null, null);
                        if (handler != null)
                        {
                                handler(sender, e);
                        }
                }
        }
}