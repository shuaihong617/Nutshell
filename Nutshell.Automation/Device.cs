// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-05-11
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-05-14
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Models;
using Nutshell.Data;

namespace Nutshell.Automation
{
        /// <summary>
        ///         设备
        /// </summary>
        public abstract class Device : StorableObject, IDevice, IStorable<IDeviceModel>
        {
                #region 构造函数

                protected Device(IdentityObject parent, string id = "设备",
                        ManufacturingInformation manufacturingInformation = null)
                        : base(parent, id)
                {
                        if (manufacturingInformation != null)
                        {
                                ManufacturingInformation = manufacturingInformation;
                        }
                }

                #endregion

                #region 属性

                /// <summary>
                ///         制造信息
                /// </summary>
                [MustNotEqualNull]
                public IManufacturingInformation ManufacturingInformation { get; set; }

                #endregion

                #region 方法

                public void Load(IDeviceModel model)
                {
                        base.Load(model);
                }

                /// <summary>
                ///         保存数据到数据模型
                /// </summary>
                /// <param name="model">写入数据的目的数据模型，该数据模型不能为null</param>
                public void Save(IDeviceModel model)
                {
                        throw new NotImplementedException();
                }

                #endregion
        }
}