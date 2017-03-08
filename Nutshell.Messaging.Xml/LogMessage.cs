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


using System.Xml.Serialization;
using Nutshell.Logging;

namespace Nutshell.Messaging.Xml
{
        /// <summary>
        ///         自动装包开始消息数据模型
        /// </summary>
        [XmlType]
        public class LogMessage : XmlMessage
        {
                public LogMessage()
                {
                        Level = LogLevel.信息;
                }

                public LogMessage(string content, LogLevel level = LogLevel.信息)
                {
                        Content = content;

                        Level = level;
                }

                [XmlAttribute]
                public LogLevel Level { get; set; }

                [XmlAttribute]
                public string Content { get; set; }

                public override string ToString()
                {
                        return $"{CreateTimeStamp.ToChineseLongMillisecondString()}  {Level}  {Content}";
                }
        }
}