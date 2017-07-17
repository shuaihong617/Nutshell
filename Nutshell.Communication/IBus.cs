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
using System.ComponentModel;
using Nutshell.Aspects.Events;
using Nutshell.Messaging;
using Nutshell.Messaging.Models;
using Nutshell.Serializing;

namespace Nutshell.Communication
{
        /// <summary>
        ///         总线接口
        /// </summary>
        public interface IBus
        {

                #region 事件

                ///// <summary>
                /////         当消息发送成功时发生。
                ///// </summary>
                //[Description("消息发送成功事件")]
                //event EventHandler<ValueEventArgs<Message>> SendSuccessed;

                ///// <summary>
                /////         当消息发送失败时发生。
                ///// </summary>
                //[Description("消息发送失败事件")]
                //event EventHandler<ValueEventArgs<Message>> SendFailed;

                ///// <summary>
                /////         当消息接收成功时发生。
                ///// </summary>
                //[Description("消息接收成功事件")]
                //event EventHandler<ValueEventArgs<Message>> ReceiveSuccessed;

                ///// <summary>
                /////         当消息接收失败时发生。
                ///// </summary>
                //[Description("消息接收失败事件")]
                //event EventHandler<ValueEventArgs<Message>> ReceiveFailed;

                #endregion
        }
}
