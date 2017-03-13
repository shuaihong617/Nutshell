// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-04-14
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-04-14
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Data.Models;
using System;

namespace Nutshell.Automation.Opc.Models
{
        /// <summary>
        ///         已定义主键的对象数据模型
        /// </summary>
        public interface IOpcItemModel : IDataModel
        {
                /// <summary>
                ///         地址
                /// </summary>
                string Address { get; set; }

                /// <summary>
                ///         数据类型
                /// </summary>
                TypeCode TypeCode { get; set; }

                /// <summary>
                ///         读写模式
                /// </summary>
                ReadWriteMode ReadWriteMode { get; set; }
        }
}