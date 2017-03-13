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

using Nutshell.Data;
using Nutshell.Data.Models;

namespace Nutshell.Storaging.Xml
{
        /// <summary>
        ///         主键对象
        /// </summary>
        public class XmlStorableObject : StorableObject
        {
                /// <summary>
                /// 初始化<see cref="XmlStorableObject" />的新实例.
                /// </summary>
                /// <param name="parent">上级对象</param>
                /// <param name="id">标识</param>
                public XmlStorableObject(IdentityObject parent = null, string id = null)
                        : base(id)
                {
                }

                #region 方法

                /// <summary>
                /// 从文件反序列化数据模型并加载数据
                /// </summary>
                /// <typeparam name="T">数据模型的数据类型</typeparam>
                /// <param name="filePath">文件类型</param>
                //public void Load<T>(string filePath) where T : class, IDataModel
                //{
                //        var model = XmlStorager.Load<T>(filePath);
                //        Load(model);
                //}

                public void Save<T>(string filePath) where T : class, IDataModel, new()
                {
                        var t = new T();
                        Save(t);

                        //XmlStorager.Save<T>(t,filePath);
                }

                #endregion 方法
        }
}