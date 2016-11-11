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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using Nutshell.Components;
using Nutshell.Hardware.Vision.Hikvision.MachineVision.SDK;
using Nutshell.Log;

namespace Nutshell.Hardware.Vision.Hikvision.MachineVision
{
        /// <summary>
        ///         海康威视机器视觉摄像机运行环境
        /// </summary>
        public class MachineVisionRuntime:Worker
        {
                protected MachineVisionRuntime()
                        :base(null,"海康威视机器视觉摄像机运行环境")
                {
                        
                }

                #region 单例

                /// <summary>
                ///         单例
                /// </summary>
                public static readonly MachineVisionRuntime Itance = new MachineVisionRuntime();

                #endregion

                public ReadOnlyCollection<MVDeviceInformation> DeviceInfos { get; private set; } 

                #region 方法

                protected override bool StartCore()
                {
                        if (DeviceInfos != null)
                        {
                                return true;
                        }

                        var deviceInfoList = new MVDeviceInformationList();
                        var errorCode = MVOfficialAPI.EnumDevices(MVDeviceType.GigeDevice, ref deviceInfoList);

                        if (errorCode != MVErrorCode.MV_OK)
                        {
                                this.WarnFail("摄像机枚举", errorCode);
                                return false;
                        }

                        var deviceInfos = new List<MVDeviceInformation>();

                        var deviceInfoType = typeof(MVDeviceInformation);
                        foreach (var deviceInfoPtr in deviceInfoList.DeviceInfoPtrs)
                        {
                                if (deviceInfoPtr != IntPtr.Zero)
                                {
                                        var di = (MVDeviceInformation)Marshal.PtrToStructure(deviceInfoPtr, deviceInfoType);
                                        deviceInfos.Add(di);

                                        this.Info("检测到摄像机：IP" + di.GigeDeviceInfo.GetCurrentIpAddress());
                                }
                        }

                        DeviceInfos = new ReadOnlyCollection<MVDeviceInformation>(deviceInfos);
                        
                        return true;
                }

                protected override bool StopCore()
                {
                        DeviceInfos = null;

                        return true;
                }
                
                #endregion

                
        }
}