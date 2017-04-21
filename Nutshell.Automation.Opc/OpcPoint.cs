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

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Data;
using System;

namespace Nutshell.Automation.Opc
{
        /// <summary>
        ///         跟踪值更新前后变化的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class OpcPoint<T> : ObservableNullable<T> where T : struct
        {
		/// <summary>
		///         初始化<see cref="OpcPoint{T}" />的新实例.
		/// </summary>
		/// <param name="id">The item.</param>
		/// <param name="opcItem">The opc item.</param>
		public OpcPoint([MustNotEqualNull] string id,
                        [MustNotEqualNull] OpcItem opcItem)
                        : base()
                {
                        _opcItem = opcItem;

                        _opcItem.ReadSuccessed += (obj, args) => { SetData(ConvertFrom(args.Value, _opcItem.TypeCode)); };
                        _opcItem.ReadFailed += (obj, args) => { SetData(null); };
                }

                private readonly OpcItem _opcItem;

                public void RemoteWrite(T t)
                {
                        _opcItem.RemoteWrite(t);
                }

                public void RemoteRead()
                {
                        var result = _opcItem.RemoteRead();
                        SetData(ConvertFrom(result, _opcItem.TypeCode));
                }

                private T? ConvertFrom(object value, TypeCode typeCode)
                {
                        throw new NotImplementedException();
                        //return null;
                }
        }
}