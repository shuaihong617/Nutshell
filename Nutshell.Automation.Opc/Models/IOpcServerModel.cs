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

using Nutshell.Automation.Models;

namespace Nutshell.Automation.Opc.Models
{
        /// <summary>
        ///         已定义主键的xmlOpc服务器数据模型
        /// </summary>
        public interface IOpcServerModel : IDispatchableDeviceModel
        {
                /// <summary>
                ///         地址
                /// </summary>
                string Address { get; set; }
        }
}