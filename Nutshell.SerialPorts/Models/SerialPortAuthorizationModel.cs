// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-01-05
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-01-05
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.IO.Ports;
using System.Xml.Serialization;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Storaging.Models;

namespace Nutshell.SerialPorts.Models
{
        /// <summary>
        ///         SerialPort授权数据模型
        /// </summary>
        public class SerialPortAuthorizationModel : DataModel
        {
                /// <summary>
                ///         获取或设置端口名称
                /// </summary>
                /// <value>端口名称</value>
                [MustNotEqualNullOrEmpty]
                [XmlAttribute]
                public string PortName { get; set; }

                /// <summary>
                ///         获取或设置波特率
                /// </summary>
                /// <value>波特率</value>
                [XmlAttribute]
                public BaudRate BaudRate { get; set; }

                /// <summary>
                ///         获取或设置校验模式
                /// </summary>
                /// <value>校验模式</value>
                [MustNotEqualNullOrEmpty]
                [XmlAttribute]
                public Parity Parity { get; set; }

                /// <summary>
                ///         获取或设置数据位
                /// </summary>
                /// <value>数据位</value>
                [MustNotEqualNullOrEmpty]
                [XmlAttribute]
                public int DataBits { get; set; }

                /// <summary>
                ///         获取或设置停止位
                /// </summary>
                /// <value>停止位</value>
                [XmlAttribute]
                public StopBits StopBits { get; set; }

                /// <summary>
                ///         获取或设置握手协议
                /// </summary>
                /// <value>握手协议</value>
                [XmlAttribute]
                public Handshake Handshake { get; set; }
        }
}