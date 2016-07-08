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

using System;
using System.Diagnostics;
using Nutshell.Data.Models;
using Nutshell.Data.Storaging;

namespace Nutshell.Data
{
        /// <summary>
        ///         主键对象
        /// </summary>
        public class StorableObject : IdentityObject
        {
                /// <summary>
                /// 初始化<see cref="IdentityObject" />的新实例.
                /// </summary>
                /// <param name="parent">The parent.</param>
                /// <param name="id">主键</param>
                public StorableObject(IdentityObject parent = null, string id = "")
                        :base(parent, id)
                {
                }
               
                #region 方法

                /// <summary>
                ///         从数据模型加载数据
                /// </summary>
                /// <param name="model">数据模型</param>
                public virtual void Load(IStorableModel model)
                {
                        model.MustNotNull();
                        model.Id.MustNotNullOrEmpty();

                        Id = model.Id;
                }

                public void Load<T>(string filePath) where T : class, IStorableModel
                {
                        var model = XmlStorage.Load<T>(filePath);
                        Load(model);
                }

                /// <summary>
                ///         保存数据到数据模型
                /// </summary>
                /// <param name="model">数据模型</param>
                /// <returns>成功返回True, 否则返回False</returns>
                public virtual void Save(IStorableModel model)
                {
                        model.MustNotNull();

                        model.Id = Id;

                        Trace.Assert(!string.IsNullOrEmpty(model.Id));
                }

                public void Save<T>(string filePath) where T : class, IStorableModel,new()
                {
                        var t = new T();
                        Save(t);

                        XmlStorage.Save<T>(t,filePath);
                }

                #endregion

               
        }
}