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
using Nutshell.Components;
using Nutshell.Data;
using Nutshell.Data.Models;

namespace Nutshell.Automation
{
        /// <summary>
        /// 可控设备
        /// </summary>
        public abstract class ControllableDevice : Device,IControlableDevice,IConnectableDevice
        {
                /// <summary>
                /// 初始化<see cref="ControllableDevice" />的新实例.
                /// </summary>
                /// <param name="parent">The parent.</param>
                /// <param name="id">The identifier.</param>
                protected ControllableDevice(IdentityObject parent, string id = "可控设备")
                        : base(parent, id)
                {
                        DebugMode = DebugMode.Release;
                }

                #region 属性

                /// <summary>
                /// 控制模式
                /// </summary>
                public DebugMode DebugMode { get; private set; }

                #endregion

                /// <summary>
                /// Loads the specified model.
                /// </summary>
                /// <param name="model">The model.</param>
                public void Load([MustNotEqualNull]IConnectableDeviceModel model)
                {
                        base.Load(model);

                        DebugMode = model.DebugMode;
                }

	        /// <summary>
	        ///         保存数据到数据模型
	        /// </summary>
	        /// <param name="model">写入数据的目的数据模型，该数据模型不能为null</param>
	        public void Save([MustNotEqualNull]IConnectableDeviceModel model)
	        {
		        throw new System.NotImplementedException();
	        }
        }
}
