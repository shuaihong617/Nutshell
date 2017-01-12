// ***********************************************************************
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
using Nutshell.Aspects.Locations.Contracts;

namespace Nutshell
{
        /// <summary>
        ///         表示操作的结果
        /// </summary>
        public class Result:IResult
        {
                public Result(bool isSuccess, Exception exception = null)
                {
                        IsSuccess = isSuccess;

                        if (!IsSuccess && exception == null)
                        {
                                throw new ArgumentException();
                        }
                        Exception = exception;
                }

                public Result([MustNotEqualNull]Exception exception)
                        : this(false, exception)
                {
                }

                public static readonly Result Successed = new Result(true);

                public bool IsSuccess { get; }

                public Exception Exception { get; }
        }
}