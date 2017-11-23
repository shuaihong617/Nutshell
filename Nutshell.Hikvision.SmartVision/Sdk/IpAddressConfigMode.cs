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
        /// IP地址配置模式
        /// </summary>
        public enum IpAddressConfigMode
        {
                /// <summary>
                /// 静态地址
                /// </summary>
                Static = 0x05000000,
                /// <summary>
                /// 动态分配
                /// </summary>
                Dhcp = 0x06000000,
                /// <summary>
                /// 链路本地地址
                /// </summary>
                Lla = 0x04000000
        }
}