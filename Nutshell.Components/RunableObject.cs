// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-10-16
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-10-17
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Aspects.Methods.Contracts;
using Nutshell.Components.Models;
using Nutshell.Data;

namespace Nutshell.Components
{
        /// <summary>
        ///         运行环境
        /// </summary>
        public abstract class RunableObject:StorableObject,IRunableObject
        {
                protected RunableObject(
                        string id=null)
                        : base( id)
                {
                        IsEnable = true;
                        RunMode = RunMode.Release;
                }

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


		#endregion

		#region 方法

		public void Load([MustNotEqualNull]IRunableObjectModel model)
		{
			base.Load(model);

			IsEnable = model.IsEnable;
			RunMode = model.RunMode;
		}

		/// <summary>
		///         保存数据到数据模型
		/// </summary>
		/// <param name="model">写入数据的目的数据模型，该数据模型不能为null</param>
		public void Save([MustNotEqualNull]IRunableObjectModel model)
		{
			base.Save(model);

			model.IsEnable = IsEnable;
			model.RunMode = RunMode;
		}

		#endregion


	}
}