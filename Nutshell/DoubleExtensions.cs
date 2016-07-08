// ***********************************************************************
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

namespace Nutshell
{
        /// <summary>
        ///         DateTime struce extensions
        /// </summary>
        public static class DoubleExtensions
        {
                /// <summary>
                ///         Musts the specified value.
                /// </summary>
                /// <param name="value">if set to <c>true</c> [value].</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
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