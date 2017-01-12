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

using System;
using Nutshell.Automation.Models;

namespace Nutshell.Automation
{
        /// <summary>
        ///         可升级制造信息接口
        /// </summary>
        public class UpgradeableManufacturingInformation:ManufacturingInformation,IUpgradeableManufacturingInformation
        {
                /// <summary>
                ///         设备版本
                /// </summary>
                public Version DeviceVersion { get; private set; }

                /// <summary>
                ///         固件版本
                /// </summary>
                public Version FirewareVersion { get; private set; }

                public void Load(IUpgradeableManufacturingInformationModel model)
                {
                        throw new NotImplementedException();
                }

                public void Save(IUpgradeableManufacturingInformationModel model)
                {
                        throw new NotImplementedException();
                }
        }
}
