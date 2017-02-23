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
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Automation.Models;
using Nutshell.Components;
using Nutshell.Data;

namespace Nutshell.Automation
{
        /// <summary>
        ///         设备
        /// </summary>
        public abstract class IndependentDevice : Component, IIndependentDevice
        {
                #region 构造函数

                protected IndependentDevice(
			string id = null)
                        : base( id)
                {
                }

                #endregion

                #region 属性

                

                #endregion

                #region 方法

                public void Load([MustNotEqualNull]IIndependentDeviceObjectModel objectModel)
                {
                        
                }

                /// <summary>
                ///         保存数据到数据模型
                /// </summary>
                /// <param name="objectModel">写入数据的目的数据模型，该数据模型不能为null</param>
                public void Save([MustNotEqualNull]IIndependentDeviceObjectModel objectModel)
                {
                        base.Save(objectModel);

                        
                }

                #endregion
        }
}