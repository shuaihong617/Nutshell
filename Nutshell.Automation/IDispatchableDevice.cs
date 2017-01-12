// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-12-27
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-12-29
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************


using Nutshell.Automation.Models;
using Nutshell.Components;
using Nutshell.Components.Models;
using Nutshell.Data;

namespace Nutshell.Automation
{
        /// <summary>
        /// 可控设备接口
        /// </summary>
        public interface IDispatchableDevice : IConnectableDevice, IStorable<IDispatchableDeviceModel>
        {
                /// <summary>
                /// 获取控制工作者，控制工作者负责设备的开始\停止工作
                /// </summary>
                /// <value>控制工作者</value>
                IWorker DispatchWorker { get; }

                void Establish();

                void Terminate();
        }
}
