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
namespace Nutshell.Hardware.Vision.Hikvision.MachineVision.SDK
{
        /// <summary>
        /// 访问模式枚举
        /// </summary>
        public enum AccessMode
        {
                /// <summary>
                /// 独占权限
                /// </summary>
                独占权限 = 1,
                
                /// <summary>
                /// 以转换形式获取的独占权限
                /// </summary>
                以转换形式获取的独占权限 = 2,
                
                /// <summary>
                /// 控制权限
                /// </summary>
                控制权限 = 3,
                
                /// <summary>
                /// 以转换形式获取的控制权限
                /// </summary>
                以转换形式获取的控制权限 = 4,
                
                /// <summary>
                /// 支持转换的控制权限
                /// </summary>
                支持转换的控制权限 = 5,
                
                /// <summary>
                /// 以转换形式获取的支持转换的控制权限
                /// </summary>
                以转换形式获取的支持转换的控制权限 = 6,
                
                /// <summary>
                /// 只读权限
                /// </summary>
                只读权限 = 7
        }
}
