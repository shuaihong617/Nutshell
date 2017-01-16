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
        public abstract class Component : StorableObject, IComponent
        {
                #region 构造函数

                protected Component([MustNotEqualNull]IIdentityObject parent,
			string id = null)
                        : base(parent, id)
                {
                }

		#endregion

		#region 属性

		/// <summary>
		///         获取是否启用
		/// </summary>
		/// <value>如果启用则返回True，否则返回False</value>
		[WillNotifyPropertyChanged]
		public bool IsEnable { get;private set; }

		/// <summary>
		///         获取调试模式
		/// </summary>
		/// <value>调试模式</value>
		[WillNotifyPropertyChanged]
		public RunMode RunMode { get; private set; }

		/// <summary>
		///         制造信息
		/// </summary>
		[MustNotEqualNull]
                public IManufacturingInformation ManufacturingInformation { get; set; }

                #endregion

                #region 方法

                public void Load([MustNotEqualNull]IComponentModel model)
                {
                        base.Load(model);

			IsEnable = model.IsEnable;
	                RunMode = model.RunMode;
                }

                /// <summary>
                ///         保存数据到数据模型
                /// </summary>
                /// <param name="model">写入数据的目的数据模型，该数据模型不能为null</param>
                public void Save([MustNotEqualNull]IComponentModel model)
                {
                        base.Save(model);

                        model.IsEnable = IsEnable;
                        model.RunMode = RunMode;
                }

                #endregion
        }
}