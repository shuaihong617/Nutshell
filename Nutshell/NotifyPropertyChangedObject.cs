// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-09-04
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-09-04
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Nutshell
{
        /// <summary>
        ///         实现属性更改通知接口
        /// </summary>
        public abstract class NotifyPropertyChangedObject : INotifyPropertyChanged
        {                
                #region 事件

                /// <summary>
                ///         在更改属性值时发生.
                /// </summary>
                public event PropertyChangedEventHandler PropertyChanged;

                #endregion

                #region 方法

                /// <summary>
                ///         通知属性值已更改
                /// </summary>
                /// <param name="propertyName">属性名称, 由编译器自动生成</param>
                public void OnPropertyChanged([CallerMemberName] string propertyName = null)
                {
                        PropertyChangedEventHandler handler = PropertyChanged;
                        if (handler != null)
                        {
                                handler.Invoke(this,new PropertyChangedEventArgs(propertyName));
                        }
                }

                /// <summary>
                ///         Sets the property.
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <param name="storage">The storage.</param>
                /// <param name="value">The value.</param>
                /// <param name="propertyName">Name of the property.</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
                {
                        if (Equals(storage, value))
                        {
                                return false;
                        }

                        storage = value;
                        OnPropertyChanged();

                        return true;
                }

                #endregion
        }
}