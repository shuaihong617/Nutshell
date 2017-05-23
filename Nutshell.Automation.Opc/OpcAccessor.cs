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
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Data;

namespace Nutshell.Automation.Opc
{
        /// <summary>
        ///         跟踪值更新前后变化的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class OpcAccessor<T> : ObservableValue<T> where T : struct
        {
                [MustNotEqualNull] private OpcItem _source;

                public OpcAccessor<T> SetSource([MustNotEqualNull] OpcItem source)
                {
                        _source = source;
                        _source.DataChanged += (obj, args) => { SetValue(ConvertFrom(args.Value, _source.TypeCode)); };
                        return this;
                }

                public void RemoteWrite(T t)
                {
                        _source.RemoteWrite(t);
                }

                public void RemoteRead()
                {
                        var result = _source.RemoteRead();
                        SetValue(ConvertFrom(result, _source.TypeCode));
                }

                private T ConvertFrom([MustNotEqualNull] object value, TypeCode typeCode)
                {
                        throw new NotImplementedException();
                        //return null;
                }
        }
}