// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-01-05
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-01-05
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Aspects.Locations.Contracts;

namespace Nutshell.Data.Models
{
        /// <summary>
        ///         应用程序数据模型接口
        /// </summary>
        public interface IApplicationModel : IDataModel
        {
                /// <summary>
                /// 获取或设置应用程序名称
                /// </summary>
                /// <value>应用程序名称</value>
                [MustNotEqualNullOrEmpty]
                string Name { get; set; }

                /// <summary>
                /// 获取或设置版本
                /// </summary>
                /// <value>版本</value>
                [MustNotEqualNullOrEmpty]
                string Version { get; set; }

                /// <summary>
                /// 获取或设置应用程序标题
                /// </summary>
                /// <value>应用程序标题</value>
                [MustNotEqualNullOrEmpty]
                string Title { get; set; }

                /// <summary>
                /// 获取或设置公司
                /// </summary>
                /// <value>公司</value>
                [MustNotEqualNullOrEmpty]
                string Company { get; set; }

                /// <summary>
                /// 获取或设置版权信息
                /// </summary>
                /// <value>版权信息</value>
                [MustNotEqualNullOrEmpty]
                string CopyRight { get; set; }
        }
}