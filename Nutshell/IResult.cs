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
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Nutshell
{
        /// <summary>
        ///         结果接口
        /// </summary>
        public interface IResult
        {
                bool IsSuccessed { get; }

                ReadOnlyCollection<Exception> Exceptions { get; }
        }
}