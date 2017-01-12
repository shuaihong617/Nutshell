﻿// ***********************************************************************
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
using Nutshell.Data;

namespace Nutshell.Automation
{
        /// <summary>
        /// 制造信息
        /// </summary>
        public class ManufacturingInformation:StorableObject, IManufacturingInformation
        {
                /// <summary>
                /// 制造商
                /// </summary>
                public string Manufacturer { get; private set; }

                /// <summary>
                /// 型号
                /// </summary>
                public string Model { get; private set; }

                public void Load(IManufacturingInformationModel model)
                {
                        Manufacturer = model.Manufacturer;
                        Model = model.Model;
                }

                public void Save(IManufacturingInformationModel model)
                {
                        throw new NotImplementedException();
                }
        }
}