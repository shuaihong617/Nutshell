// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-05-19
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-05-20
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;

namespace Nutshell.Data
{
        /// <summary>
        ///         跟踪值更新前后变化的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class ObservableNullableObject<T> : IdentityObject where T : struct
        {
                /// <summary>
                /// 初始化<see cref="ObservableNullableObject{T}" />的新实例.
                /// </summary>
                /// <param name="parent">上级对象</param>
                /// <param name="id">The item.</param>
                public ObservableNullableObject(IdentityObject parent, string id)
                        :base(parent, id)
                {
                        NullableValue = new T();
                }

                #region 字段

                /// <summary>
                ///         The _data
                /// </summary>
                private T? _nullableValue;

                #endregion

                /// <summary>
                ///         Gets or sets the data.
                /// </summary>
                /// <value>The data.</value>
                public T? NullableValue 
                { 
                        get { return _nullableValue; }
                        set
                        {
                                _nullableValue = value;
                                OnPropertyChanged();

                                OnValueChanged(new ValueEventArgs<T?>(value));
                        }
                }

                public override string ToString()
                {
                        return GlobalId + " : " + NullableValue;
                }

                #region 事件

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                public event EventHandler<ValueEventArgs<T?>> ValueChanged;

                /// <summary>
                ///         引发 <see cref="E:Opened" /> 事件.
                /// </summary>
                /// <param name="e">The <see cref="ValueChangedEventArgs{T}" /> Itance containing the event data.</param>
                protected virtual void OnValueChanged(ValueEventArgs<T?> e)
                {
                        //this.InfoEvent("数据更新", e.Data);
                        e.Raise(this, ref ValueChanged);
                }

                #endregion
        }

}