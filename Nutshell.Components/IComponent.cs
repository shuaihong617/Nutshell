// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-07-22
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-07-22
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Components.Models;
using Nutshell.Data;

namespace Nutshell.Components
{
        /// <summary>
        ///         组件接口
        /// </summary>
        public interface IComponent : IRunableObject,IStorable<IComponentObjectModel>
        {
                #region 属性

                /// <summary>
                /// 获取组件信息
                /// </summary>
                /// <value>组件信息</value>
                [MustNotEqualNull]
                IManufacturingInformation ManufacturingInformation { get; set; }

                #endregion
	}
}