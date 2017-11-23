// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-11-22
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-11-22
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************
namespace Nutshell.Hikvision.SmartVision.Sdk
{
        /// <summary>
        /// 触发源枚举
        /// </summary>
        public enum TriggerSource
        {
                /// <summary>
                /// Line0硬件触发
                /// </summary>
                Line0 = 0,

                /// <summary>
                /// Line1硬件触发
                /// </summary>
                Line1 = 2,

                /// <summary>
                /// Line2硬件触发
                /// </summary>
                Line2 = 3,

                /// <summary>
                /// Counter0硬件触发
                /// </summary>
                Counter0 = 5,        

                /// <summary>
                /// 软触发
                /// </summary>
                Software = 1,       

        }
}