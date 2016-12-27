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
using System.Diagnostics;
using Nutshell.Data;
using Nutshell.Log;

namespace Nutshell.Automation.OPC
{
        /// <summary>
        ///         跟踪值更新前后变化的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class OPCObject<T> : ObservableNullableObject<T> where T : struct
        {
                /// <summary>
                /// 初始化<see cref="OPCObject{T}" />的新实例.
                /// </summary>
                /// <param name="parent">The parent.</param>
                /// <param name="id">The item.</param>
                public OPCObject(IdentityObject parent, string id, OpcItem<T> opcItem)
                        :base(parent, id)
                {
                        Debug.Assert(opcItem != null);
                        _opcItem = opcItem;

                        _opcItem.Data.ValueChanged += (o, e) => NullableValue = e.Data;
                }

                private readonly OpcItem<T> _opcItem;

                public void RemoteWrite(T t)
                {
                        _opcItem.RemoteWrite(t);
                }

                public void RemoteRead()
                {
                        _opcItem.RemoteRead();
                        NullableValue = _opcItem.Data.NullableValue;
                }
        }

}