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

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Components.Models;
using Nutshell.Data;

namespace Nutshell.Components
{
        /// <summary>
        ///         组件
        /// </summary>
        public abstract class Component : StorableObject, IRunable, IStorable<IComponentModel>
        {
                #region 构造函数

                protected Component(string id = "")
                        : base(id)
                {
                        IsEnable = true;
                        RunMode = RunMode.Release;
                }

                #endregion 构造函数

                #region 属性

                /// <summary>
                ///         获取是否启用
                /// </summary>
                /// <value>是否启用</value>
                [NotifyPropertyValueChanged]
                public bool IsEnable { get; private set; }

                /// <summary>
                ///         获取运行模式
                /// </summary>
                /// <value>运行模式</value>
                [NotifyPropertyValueChanged]
                public RunMode RunMode { get; private set; }

                #endregion 属性

                #region 方法

                /// <summary>
                ///         从数据模型加载数据
                /// </summary>
                /// <param name="model">读取数据的源数据模型，该数据模型不能为空引用</param>
                public void Load([MustNotEqualNull] IComponentModel model)
                {
                        base.Load(model);

                        IsEnable = model.IsEnable;
                        RunMode = model.RunMode;
                }

                /// <summary>
                ///         保存数据到数据模型
                /// </summary>
                /// <param name="model">写入数据的目的数据模型，该数据模型不能为null</param>
                public void Save([MustNotEqualNull] IComponentModel model)
                {
                        base.Save(model);
                }

                #endregion 方法
        }
}