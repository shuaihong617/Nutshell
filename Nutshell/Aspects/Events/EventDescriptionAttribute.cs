// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-05-17
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-05-17
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.ComponentModel;

namespace Nutshell.Aspects.Events
{
        [AttributeUsage(AttributeTargets.Event, Inherited = true, AllowMultiple = false)]
        public class EventDescriptionAttribute : DescriptionAttribute
        {
                public EventDescriptionAttribute(string description)
                        : base(description + "事件")
                {
                }
        }
}