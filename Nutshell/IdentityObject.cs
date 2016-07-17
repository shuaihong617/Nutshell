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
using Nutshell.Data;

namespace Nutshell
{
        /// <summary>
        /// 带有标识的对象
        /// </summary>
        public class IdentityObject : DisposableObject, IIdentityObject
        {
                /// <summary>
                /// 初始化<see cref="IdentityObject" />的新实例.
                /// </summary>
                /// <param name="parent">上级对象</param>
                /// <param name="id">标识</param>
                public IdentityObject(IdentityObject parent= null, string id = "")
                {
                        id.MustNotNull();
                        Id = id;

                        Parent = parent;
                }

                #region 字段

                /// <summary>
                /// The _id
                /// </summary>
                private string _id;
                /// <summary>
                /// The _global identifier
                /// </summary>
                private string _globalId;
                /// <summary>
                /// The _parent
                /// </summary>
                private IdentityObject _parent;

                #endregion

                /// <summary>
                /// 标识
                /// </summary>
                public string Id
                {
                        get { return _id; }
                        protected set
                        {
                                if (value == _id)
                                {
                                        return;
                                }
                                _id = value;
                                RaisePropertyChanged();

                                UpdateGlobalId();
                        }
                }

                /// <summary>
                /// 全局标识
                /// </summary>
                public string GlobalId
                {
                        get { return _globalId; }
                        private set
                        {
                                if (value == _globalId)
                                {
                                        return;
                                }
                                _globalId = value;
                                RaisePropertyChanged();

                                OnGlobalIdChanged(null);
                        }
                }

                /// <summary>
                /// 上级对象
                /// </summary>
                public IdentityObject Parent
                {
                        get { return _parent; }
                        private set
                        {
                                _parent = value;

                                if (Parent != null)
                                {
                                        Parent.GlobalIdChanged += (o, a) => UpdateGlobalId();
                                }

                                UpdateGlobalId();                                       
                        }
                }

                #region 方法

                /// <summary>
                /// 更新全局标识
                /// </summary>
                private void UpdateGlobalId()
                {
                        GlobalId = Parent == null ? Id : Parent.GlobalId + "." + Id;
                }

                /// <summary>
                /// 以字符串形式输出带有标识的对象
                /// </summary>
                /// <returns>全局标识</returns>
                public override string ToString()
                {
                        return GlobalId;
                }

                #endregion

                #region 事件

                /// <summary>
                /// 当全局标识改变时发生
                /// </summary>
                public event EventHandler<EventArgs> GlobalIdChanged;


                /// <summary>
                /// 引发<see cref="E:GlobalIdChanged" />事件
                /// </summary>
                /// <param name="e">包含事件数据的<see cref="EventArgs"/>实例</param>
                private void OnGlobalIdChanged(EventArgs e)
                {
                        e.Raise(this, ref GlobalIdChanged);
                }

                #endregion
        }
}