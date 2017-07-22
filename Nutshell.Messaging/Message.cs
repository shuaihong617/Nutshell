// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-10-16
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-10-17
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using Nutshell.Data.Models;
using Nutshell.Extensions;

namespace Nutshell.Messaging
{
        /// <summary>
        ///         消息
        /// </summary>
        
        public class Message : IdentityModel
        {
                public Message()
                {
                        Id = Guid.NewGuid().ToString();
                        Type = GetType().Name;
                        CreateTime = DateTime.MinValue;
                }

                public Message(string id, string type, DateTime time)
                {
                        Id = id;
                        Type = type;
                        CreateTime = time;
                }

                public string Type { get; set; }

                public DateTime CreateTime { get; set; }

                public override string ToString()
                {
                        return $"{Id}  {Type}  {CreateTime.ToChineseLongMillisecondString()}";
                }
        }
}