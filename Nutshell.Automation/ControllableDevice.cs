// ***********************************************************************
// 作者           : shuaihong617@qq.com
// 创建           : 2016-10-30
//
// 编辑           : shuaihong617@qq.com
// 日期           : 2016-11-11
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Models;
using Nutshell.Data.Models;

namespace Nutshell.Automation
{
        /// <summary>
        /// 可控设备
        /// </summary>
        public abstract class ControllableDevice : Device
        {
                /// <summary>
                /// 初始化<see cref="ControllableDevice" />的新实例.
                /// </summary>
                /// <param name="parent">The parent.</param>
                /// <param name="id">The identifier.</param>
                protected ControllableDevice(IdentityObject parent, string id = "可控设备")
                        : base(parent, id)
                {
                        ControlMode = ControlMode.普通;
                }

                #region 属性

                /// <summary>
                /// 控制模式
                /// </summary>
                public ControlMode ControlMode { get; private set; }

                #endregion

                /// <summary>
                /// Loads the specified model.
                /// </summary>
                /// <param name="model">The model.</param>
                public override void Load([MustAssignableFrom(typeof(IDeviceModel))] IDataModel model)
                {
                        base.Load(model);

                        var deviceModel = model as IControllableDeviceModel;
                        ControlMode = deviceModel.ControlMode;
                }
        }
}
