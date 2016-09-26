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
using Nutshell.Log;

namespace Nutshell.Hardware
{
        /// <summary>
        ///         海康威视机器视觉摄像机运行环境
        /// </summary>
        public abstract class NSDeviceRuntime:Worker
        {
                protected NSDeviceRuntime()
                        :base(null,"设备运行环境")
                {

                }

                #region 属性

                public NSManufacturingInformation ManufacturingInformation { get; private set; }

                #endregion

                #region 方法


                #endregion


        }
}