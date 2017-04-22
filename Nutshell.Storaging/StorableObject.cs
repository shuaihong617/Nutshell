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
using Nutshell.Storaging.Models;

namespace Nutshell.Storaging
{
        /// <summary>
        ///         可存储对象
        /// </summary>
        public class StorableObject : IdentityObject, IStorable<DataModel>
        {
                /// <summary>
                ///         初始化<see cref="StorableObject" />的新实例.
                /// </summary>
                /// <param name="id">标识</param>
                public StorableObject(string id = "")
                        : base(id)
                {
                }

                #region 方法

                /// <summary>
                ///         从数据模型加载数据
                /// </summary>
                /// <param name="model">读取数据的源数据模型，该数据模型不能为空引用</param>
                public virtual void Load([MustNotEqualNull]DataModel model)
                {
                        Id = model.Id;
                }

                /// <summary>
		///         保存数据到数据模型
		/// </summary>
		/// <param name="model">写入数据的目的数据模型，该数据模型不能为空引用</param>
                public virtual void Save([MustNotEqualNull]DataModel model)
                {
                        model.Id = Id;
                }

                #endregion 方法
        }
}