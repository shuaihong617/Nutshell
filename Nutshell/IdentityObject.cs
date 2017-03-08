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
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Aspects.Methods.Contracts;

namespace Nutshell
{
        /// <summary>
        ///         带有标识的对象
        /// </summary>
        public abstract class IdentityObject : DisposableObject, IIdentifiable
        {
                /// <summary>
                ///         初始化<see cref="IdentityObject" />的新实例.
                /// </summary>
                /// <param name="id">标识</param>
                protected IdentityObject([MustNotEqualNull]string id = "")
                {
	                Id = string.IsNullOrEmpty(id) ? GetType().Name : id;

			TimeStamps = new Dictionary<string, DateTime>(5);
			TimeStamps["CreateTime"] = DateTime.Now;
		}

	        #region 字段

                /// <summary>
                ///         标识
                /// </summary>
                private string _id;

	        /// <summary>
                ///         上级对象
                /// </summary>
                private IIdentifiable _parent;

		#endregion

		/// <summary>
		///         标识
		/// </summary>
		[MustNotEqualNullOrEmpty]
		[NotifyPropertyValueChanged]
                public string Id
                {
                        get { return _id; }
                        protected set
                        {
                                _id = value;
                                UpdateGlobalId();
                        }
                }

                /// <summary>
                ///         全局标识
                /// </summary>
                [NotifyPropertyValueChanged]
                [MustNotEqualNullOrEmpty]
                public string GlobalId { get; private set; }

	        /// <summary>
                ///         上级对象
                /// </summary>
                [MustNotEqualNull]
                public IIdentifiable Parent
                {
                        get { return _parent; }
                        set
                        {
				Trace.Assert(value != null);
				Trace.Assert(_parent == null);

                                _parent = value;
				_parent.GlobalIdChanged += (o, a) => UpdateGlobalId();

                                UpdateGlobalId();
                        }
                }

		public Dictionary<string, DateTime> TimeStamps { get; private set; }

                #region 方法

                /// <summary>
                ///         更新全局标识。
                /// </summary>
                private void UpdateGlobalId()
                {
	                GlobalId = Parent == null ? Id : Parent.GlobalId + "." + Id;
			OnGlobalIdChanged(EventArgs.Empty);
                }

	        /// <summary>
                ///         返回表示当前对象的字符串。
                /// </summary>
                /// <returns>全局标识</returns>
                [MustReturnNotEqualNullOrEmpty]
                public override string ToString()
                {
                        return GlobalId;
                }

                #endregion

                #region 事件

                /// <summary>
                ///         当全局标识改变时发生
                /// </summary>
                [Description("全局标识改变事件")]
                public event EventHandler<EventArgs> GlobalIdChanged;


                /// <summary>
                ///         引发全局标识改变事件
                /// </summary>
                /// <param name="e">包含事件数据的<see cref="EventArgs" />实例</param>
                private void OnGlobalIdChanged(EventArgs e)
                {
                        e.Raise(this, ref GlobalIdChanged);
                }

                #endregion
        }
}