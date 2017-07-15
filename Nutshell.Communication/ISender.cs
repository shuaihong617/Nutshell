// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-12-17
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
using Nutshell.Messaging.Models;

namespace Nutshell.Communication
{
        /// <summary>
        ///         发送器接口
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <seealso cref="Nutshell.Communication.IActor{T}" />
        public interface ISender<T> : IActor<T> where T : Message
        {
                /// <summary>
                ///         发送字节数组数据
                /// </summary>
                /// <param name="message">待发送消息数据</param>
                void Send(T message);

                event EventHandler<ValueEventArgs<T>> SendSuccessed;
        }
}
