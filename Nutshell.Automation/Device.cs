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

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Models;
using Nutshell.Components;
using Nutshell.Data.Models;
using Nutshell.Hardware;

namespace Nutshell.Automation
{
        /// <summary>
        ///         设备
        /// </summary>
        public abstract class Device : Worker, IDevice
        {
                #region 构造函数

                protected Device(IdentityObject parent, string id = "设备", ManufacturingInformation manufacturingInformation = null)
                        : base(parent, id)
                {
                        ManufacturingInformation = manufacturingInformation;
                }

                #endregion

                #region 属性

                public ManufacturingInformation ManufacturingInformation { get; private set; }

                #endregion

                #region 方法

                public override void Load([AssignableFrom(typeof (IDeviceModel))] IDataModel model)
                {
                        base.Load(model);

                        var deviceModel = model as IDeviceModel;
                }

                #endregion
        }
}