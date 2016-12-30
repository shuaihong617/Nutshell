// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-07-17
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-07-31
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

namespace Nutshell.Automation
{
        /// <summary>
        ///         制造信息接口
        /// </summary>
        public interface IManufacturingInformation
        {
                /// <summary>
                ///         制造商
                /// </summary>
                string Manufacturer { get; }

                /// <summary>
                ///         型号
                /// </summary>
                string Model { get; }

                /// <summary>
                ///         序列号
                /// </summary>
                string SerialNumber { get; }
        }
}
