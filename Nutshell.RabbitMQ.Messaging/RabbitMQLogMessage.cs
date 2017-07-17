// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-11-08
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-11-08
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Logging;
using Nutshell.Messaging.Models;
using Nutshell.RabbitMQ.Messaging.Models;

namespace Nutshell.RabbitMQ.Messaging
{
        /// <summary>
        ///         自动装包开始消息数据模型
        /// </summary>
        
        public class RabbitMQLogMessage : RabbitMQMessage
        {
                public RabbitMQLogMessage()
                {
                        LogLevel = LogLevel.信息;
                }

                public RabbitMQLogMessage(string content, LogLevel logLevel = LogLevel.信息)
                {
                        Content = content;

                        LogLevel = logLevel;
                }

                
                public LogLevel LogLevel { get; set; }

                
                public string Content { get; set; }

                //public override string ToString()
                //{
                //        return $"{CreateTimeStamp.ToChineseLongMillisecondString()}  {Level}  {Content}";
                //}
        }
}