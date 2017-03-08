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

namespace Nutshell.Messaging.Xml
{
        /// <summary>
        ///         BOOL值类型消息
        /// </summary>
        [XmlType]
        public class XmlBoolMessage : XmlValueMessage<bool>
        {
                public XmlBoolMessage(string id, string categroy, bool t) 
                        : base(id, categroy, t)
                {
                }
        }
}