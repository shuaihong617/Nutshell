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
using System.ComponentModel;

namespace Nutshell.Drawing.Imaging
{
        /// <summary>
        ///         像素格式扩展方法
        /// </summary>
        public static class PixelFormatExtensions
        {
                /// <summary>
                ///         获取像素格式的位宽
                /// </summary>
                /// <param name="format">像素格式</param>
                /// <returns>位宽</returns>
                /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">不支持的像素格式</exception>
                public static int GetBits(this NSPixelFormat format)
                {
                        switch (format)
                        {
                                case NSPixelFormat.Mono8:
                                        return 8;

                                case NSPixelFormat.Yuv422:
                                        return 16;

                                case NSPixelFormat.Rgb24:
                                        return 24;

                                case NSPixelFormat.Bgr24:
                                        return 24;

                                case NSPixelFormat.Rgba32:
                                        return 32;

                                case NSPixelFormat.Bgra32:
                                        return 32;

                                default:
                                        throw new InvalidEnumArgumentException("不支持的像素格式");
                        }
                }

                /// <summary>
                ///         获取像素格式的位宽
                /// </summary>
                /// <param name="format">像素格式</param>
                /// <returns>位宽</returns>
                /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">不支持的像素格式</exception>
                public static int GetBytes(this NSPixelFormat format)
                {
                        return GetBits(format)/8;
                }

                /// <summary>
                ///         限定当前格式必须与指定格式相等, 否则引发异常
                /// </summary>
                /// <param name="value">当前格式</param>
                /// <param name="compare">要比较的格式</param>
                /// <returns>当前格式</returns>
                /// <exception cref="System.ArgumentException"></exception>
                public static void MustEqual(this NSPixelFormat value, NSPixelFormat compare)
                {
                        if (value != compare)
                        {
                                throw new ArgumentException("像素格式必须为" + compare);
                        }
                }
        }
}