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
        /// 条码输出通讯模式枚举
        /// </summary>
        public enum BarcodeOutputCommunicationMode
        {
                /// <summary>
                /// 官方SmartSDK开发包调用模式
                /// </summary>
                SmartSdk = 1,
                
                /// <summary>
                /// Tcp指定端口发送模式
                /// </summary>
                TcpIp = 2,

                /// <summary>
                /// 串口输出模式
                /// </summary>
                SerialPort = 3
        }
}