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

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Models;
using Nutshell.Data;
using System;
using Nutshell.Automation.Models.Xml;
using Nutshell.Storaging;

namespace Nutshell.Automation
{
        /// <summary>
        /// 制造信息
        /// </summary>
        public class ManufacturingInformation : StorableObject, IStorable<ManufacturingInformationModel>
        {
                /// <summary>
                /// 制造商
                /// </summary>
                public string Manufacturer { get; private set; }

                /// <summary>
                /// 型号
                /// </summary>
                public string Model { get; private set; }

                public void Load([MustNotEqualNull]ManufacturingInformationModel model)
                {
			base.Load(model);

                        Manufacturer = model.Manufacturer;
                        Model = model.Model;
                }

                public void Save([MustNotEqualNull]ManufacturingInformationModel model)
                {
                        throw new NotImplementedException();
                }
        }
}