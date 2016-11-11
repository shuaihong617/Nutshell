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

using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Data.Aspects.Locations.Contracts;
using Nutshell.Data.Models;

namespace Nutshell.Data
{
        /// <summary>
        ///         主键对象
        /// </summary>
        public class StorableObject : IdentityObject
        {
                /// <summary>
                ///         初始化<see cref="StorableObject" />的新实例.
                /// </summary>
                /// <param name="parent">上级对象</param>
                /// <param name="id">标识</param>
                public StorableObject(IdentityObject parent = null, string id = "")
                        : base(parent, id)
                {
                }

                #region 方法

                /// <summary>
                ///         从数据模型加载数据
                /// </summary>
                /// <param name="model">数据模型</param>
                public virtual void Load([NSModelIdNotEqualNullOrEmpty] IDataModel model)
                {
                        Id = model.Id;
                }


                /// <summary>
                ///         保存数据到数据模型
                /// </summary>
                /// <param name="model">数据模型</param>
                /// <returns>成功返回True, 否则返回False</returns>
                public virtual void Save([NSNotEqualNull] IDataModel model)
                {
                        model.Id = Id;

                        Trace.Assert(!string.IsNullOrEmpty(model.Id));
                }

                #endregion
        }
}