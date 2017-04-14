// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-04-14
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-04-14
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Storaging.Models;

namespace Nutshell.Components.Models
{
        /// <summary>
        ///         组件数据模型接口
        /// </summary>
        public interface IComponentModel : IDataModel
        {
                /// <summary>
                /// 获取或设置是否启用
                /// </summary>
                /// <value>是否启用</value>
                bool IsEnable { get; set; }

                ///<summary>
                /// 获取或设置运行模式
                /// </summary>
                /// <value>运行模式</value>
                RunMode RunMode { get; set; }
        }
}