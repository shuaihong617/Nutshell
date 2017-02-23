﻿// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-09-05
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-09-05
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Nutshell.Aspects.Locations.Contracts;

namespace Nutshell
{
        /// <summary>
        ///         表示操作的结果
        /// </summary>
        public class ExceptionResult:Result
        {
                public ExceptionResult(bool isSuccessed, IList<Exception> exceptions = null)
			:base(isSuccessed)
                {

                        if (isSuccessed)
                        {
                                if (exceptions != null)
                                {
                                        throw new ArgumentException();
                                }
                        }
                        else
                        {
                                if (exceptions == null)
                                {
                                        throw new ArgumentException();
                                }
                                Exceptions = new ReadOnlyCollection<Exception>(exceptions);
                        }
                }

                public ExceptionResult([MustNotEqualNull]Exception exception)
                        : this(false, new List<Exception>
                        {
                                exception
                        })
                {
                }

                public ExceptionResult([MustNotEqualNull]IList<Exception> exceptions)
                        : this(false, exceptions)
                {
                }



                public ReadOnlyCollection<Exception> Exceptions { get; }

                public static Result operator +(ExceptionResult r1, ExceptionResult r2)
                {
                        var isSuccessed = r1.IsSuccessed & r2.IsSuccessed;
                        if (isSuccessed)
                        {
                                return new Result(true);
                        }

                        var exceptions = new List<Exception>(r1.Exceptions.Count + r2.Exceptions.Count);
                        exceptions.AddRange(r1.Exceptions);
                        exceptions.AddRange(r2.Exceptions);

                        return new ExceptionResult(false, exceptions);
                }


        }
}