// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-05-23
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-05-23
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************
using Nutshell.Aspects.Locations.Contracts;

namespace Nutshell.Automation.Opc.Controls
{
        /// <summary>
        /// 通过接近开关判断当前状态的气缸
        /// </summary>
        public class ProximitySwitchCylinder : Cylinder
        {
                /// <summary>
                /// 初始化<see cref="ProximitySwitchCylinder"/>的新实例.
                /// </summary>
                /// <param name="id">The identifier.</param>
                public ProximitySwitchCylinder(string id="")
                        : base(id)
                {
                        
                }

                /// <summary>
                /// 获取开启完成接近开关
                /// </summary>
                /// <value>开启完成接近开关</value>
                public Sensor<bool> OpenCompleteSwitch { get; private set; } = new Sensor<bool>("开启完成接近开关");

                /// <summary>
                /// 获取关闭完成接近开关
                /// </summary>
                /// <value>关闭完成接近开关</value>
                public Sensor<bool> CloseCompleteSwitch { get; private set; } = new Sensor<bool>("关闭完成接近开关");
        }
}