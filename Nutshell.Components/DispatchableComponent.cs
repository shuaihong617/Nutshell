// ***********************************************************************
// 作者           : shuaihong617@qq.com
// 创建           : 2016-10-30
//
// 编辑           : shuaihong617@qq.com
// 日期           : 2016-11-11
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Components.Models;

namespace Nutshell.Components
{
        /// <summary>
        ///         可调度组件
        /// </summary>
        public abstract class DispatchableComponent : ConnectableComponent, IDispatchableComponent
        {
                /// <summary>
                ///         初始化<see cref="DispatchableComponent" />的新实例.
                /// </summary>
                /// <param name="parent">The parent.</param>
                /// <param name="id">The identifier.</param>
                protected DispatchableComponent([MustNotEqualNull] IIdentityObject parent,string id)
                        : base(parent, id)
                {
                }

                #region 属性

                [MustNotEqualNull]
                public IWorker DispatchWorker { get; protected set; }

                #endregion

                /// <summary>
                ///         Loads the specified model.
                /// </summary>
                /// <param name="model">The model.</param>
                public void Load([MustNotEqualNull] IDispatchableComponentModel model)
                {
                        base.Load(model);
                }

                /// <summary>
                ///         保存数据到数据模型
                /// </summary>
                /// <param name="model">写入数据的目的数据模型，该数据模型不能为null</param>
                public void Save([MustNotEqualNull] IDispatchableComponentModel model)
                {
                        throw new NotImplementedException();
                }


                public void Establish()
                {
                        DispatchWorker.Start(this);
                }

                public void Terminate()
                {
                        DispatchWorker.Stop(this);
                }
        }
}
