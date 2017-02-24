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
using Nutshell.Automation;
using Nutshell.Components;
using Nutshell.Extensions;
using Nutshell.Hardware.Vision.Hikvision.MachineVision.SDK;
using Nutshell.Logging.KernelLogging;

namespace Nutshell.Hardware.Vision.Hikvision.MachineVision
{
        /// <summary>
        ///         海康威视机器视觉摄像机运行环境
        /// </summary>
        public class MachineVisionRuntime:Runtime
        {
                protected MachineVisionRuntime()
                        :base("海康威视机器视觉摄像机运行环境")
                {
                        
                }

                #region 单例

                /// <summary>
                ///         单例
                /// </summary>
                public static readonly MachineVisionRuntime Instance = new MachineVisionRuntime();

                #endregion

                public ReadOnlyCollection<MVDeviceInformation> DeviceInfos { get; private set; } 

                #region 方法

                

                protected override bool Stop()
                {
                        DeviceInfos = null;

                        return true;
                }
                
                #endregion

                
        }
}