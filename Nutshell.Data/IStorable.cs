// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-01-18
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-01-18
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Data.Models;

namespace Nutshell.Data
{
        /// <summary>
        ///         主键对象
        /// </summary>
        public interface IStorable : IIdentityObject
        {
                #region 方法

                /// <summary>
                ///         从数据模型加载数据
                /// </summary>
                /// <param name="model">数据模型</param>
                void Load([MustNotEqualNull] IDataModel model);


                /// <summary>
                ///         保存数据到数据模型
                /// </summary>
                /// <param name="model">数据模型</param>
                /// <returns>成功返回True, 否则返回False</returns>
                void Save([MustNotEqualNull] IDataModel model);

                #endregion
        }
}