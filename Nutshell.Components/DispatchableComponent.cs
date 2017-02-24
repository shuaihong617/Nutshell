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
using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Components.Models;

namespace Nutshell.Components
{
        /// <summary>
        ///         可调度组件
        /// </summary>
        public abstract class DispatchableComponent : ConnectableComponent, IDispatchableComponent
        {
	        private IDispatchWorker _dispatchWorker;

	        /// <summary>
                ///         初始化<see cref="DispatchableComponent" />的新实例.
                /// </summary>
                /// <param name="id">The identifier.</param>
                protected DispatchableComponent(string id=null)
                        : base(id)
                {
                }

                #region 属性

	        [MustNotEqualNull]
	        [NotifyPropertyValueChanged]
	        public IDispatchWorker DispatchWorker
	        {
		        get { return _dispatchWorker; }
		        set
		        {
				Trace.Assert(_dispatchWorker == null);

			        _dispatchWorker = value;
			        _dispatchWorker.Parent = this;
		        }
	        }

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
                        base.Save(model);
                }


		/// <summary>
		/// 开始调度
		/// </summary>
		/// <returns>操作结果</returns>
		public IResult StartDispath()
                {
                        return DispatchWorker.Start(this);
                }

		/// <summary>
		/// 停止调度
		/// </summary>
		/// <returns>操作结果</returns>
		public IResult StopDispatch()
                {
                       return DispatchWorker.Stop(this);
                }
        }
}
