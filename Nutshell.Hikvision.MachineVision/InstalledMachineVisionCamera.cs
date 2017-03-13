// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-02-11
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-02-11
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Hikvision.MachineVision.SDK;
using Nutshell.Net;
using System.Net;

namespace Nutshell.Hikvision.MachineVision
{
        /// <summary>
        /// 系统已安装OpcServer
        /// </summary>
        public class InstalledMachineVisionCamera : IdentityObject
        {
                /// <summary>
                /// 初始化<see cref="InstalledMachineVisionCamera" />的新实例.
                /// </summary>
                /// <param name="deviceInformation">The device information.</param>
                public InstalledMachineVisionCamera([MustNotEqualNull]DeviceInformation deviceInformation)
                        : base(deviceInformation.GetMacAddress().ToString())
                {
                        DeviceInformation = deviceInformation;

                        MacAddress = DeviceInformation.GetMacAddress();
                        IPAddress = DeviceInformation.GigeDeviceInformation.GetCurrentIpAddress();
                        UserDefineName = DeviceInformation.GigeDeviceInformation.UserDefinedName;
                }

                #region 属性

                public DeviceInformation DeviceInformation { get; }

                /// <summary>
                /// 获取OpcServer地址.
                /// </summary>
                /// <value>OpcServer地址.</value>
                [MustNotEqualNull]
                [NotifyPropertyValueChanged]
                public MacAddress MacAddress { get; private set; }

                /// <summary>
                /// 获取OpcServer地址.
                /// </summary>
                /// <value>OpcServer地址.</value>
                [MustNotEqualNull]
                [NotifyPropertyValueChanged]
                public IPAddress IPAddress { get; private set; }

                /// <summary>
                /// 获取OpcServer地址.
                /// </summary>
                /// <value>OpcServer地址.</value>
                [MustNotEqualNull]
                [NotifyPropertyValueChanged]
                public string UserDefineName { get; private set; }

                #endregion 属性
        }
}