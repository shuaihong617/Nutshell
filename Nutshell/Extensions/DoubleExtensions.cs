﻿// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-12-15
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-12-12
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;

namespace Nutshell.Extensions
{
        /// <summary>
        ///         双精度浮点数扩展方法
        /// </summary>
        public static class DoubleExtensions
        {
                /// <summary>
                ///         返回当前双精度浮点数的字节形式
                /// </summary>
                /// <param name="value">转换前数值</param>
                /// <returns>转换后数值</returns>
                public static Byte ToByte(this double value)
                {
                        if (value > 255)
                        {
                                return 255;
                        }

                        if (value < 0)
                        {
                                return 0;
                        }

                        return Convert.ToByte(value);
                }
        }
}