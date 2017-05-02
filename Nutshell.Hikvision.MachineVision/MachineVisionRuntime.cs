// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-10-16
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-10-17
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Components;
using Nutshell.Extensions;
using Nutshell.Hikvision.MachineVision.SDK;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace Nutshell.Hikvision.MachineVision
{
        /// <summary>
        ///         海康威视机器视觉摄像机运行环境
        /// </summary>
        public class MachineVisionRuntime : Runtime
        {
                protected MachineVisionRuntime()
                        : base("海康威视机器视觉摄像机运行环境")
                {
                }

                #region 单例

                /// <summary>
                ///         单例
                /// </summary>
                public static readonly MachineVisionRuntime Instance = new MachineVisionRuntime();

                #endregion 单例

                [NotifyPropertyValueChanged]
                public ReadOnlyCollection<InstalledMachineVisionCamera> InstalledMachineVisionCameras { get; private set; }

                #region 方法

                /// <summary>
                ///         执行启动过程的具体步骤.
                /// </summary>
                /// <returns>成功返回True, 否则返回False.</returns>
                /// <remarks>
                ///         若启动过程有多个步骤, 遇到返回错误的步骤立即停止向下执行.
                /// </remarks>
                protected override bool StartCore()
                {
                        if (!base.StartCore())
                        {
                                return false;
                        }

                        var deviceInfoList = new DeviceInformationCollection();
                        var errorCode = EnumDevices(ref deviceInfoList);

                        if (errorCode != ErrorCode.MV_OK)
                        {
                                return false;
                        }

                        var cameras = new List<InstalledMachineVisionCamera>();

                        var deviceInfoType = typeof(DeviceInformation);
                        foreach (var deviceInfoPtr in deviceInfoList.DeviceInfoPtrs)
                        {
                                if (deviceInfoPtr != IntPtr.Zero)
                                {
                                        var di = (DeviceInformation)Marshal.PtrToStructure(deviceInfoPtr, deviceInfoType);
                                        cameras.Add(new InstalledMachineVisionCamera(di));

                                        this.Info("检测到摄像机" + di.GigeDeviceInformation.GetCurrentIpAddress());
                                }
                        }

                        InstalledMachineVisionCameras = cameras.ToReadOnlyCollection();

                        return true;
                }

                #endregion 方法

                #region 扩展API

                private ErrorCode EnumDevices(ref DeviceInformationCollection deviceInfoCollection)
                {
                        var errorCode = OfficialApi.EnumDevices(DeviceType.GigeDevice, ref deviceInfoCollection);
                        if (errorCode != ErrorCode.MV_OK)
                        {
                                this.ErrorFailWithReason(errorCode);
                        }
                        else
                        {
                                this.InfoSuccess();
                        }
                        return errorCode;
                }

                #endregion 扩展API
        }
}