// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-11-22
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-11-23
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.Runtime.InteropServices;

namespace Nutshell.Hikvision.SmartVision.Sdk
{
        /// <summary>
        ///         条码识别结果结构体
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct CodeRecognitionResult
        {
                /// <summary>
                ///         条码Id
                /// </summary>
                public uint Id;

                /// <summary>
                ///         条码字符
                /// </summary>
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)] public string Code;

                /// <summary>
                ///         条码字符长度
                /// </summary>
                public uint CodeLength;

                /// <summary>
                ///         条码类型
                /// </summary>
                public uint CodeType;

                /// <summary>
                ///         条码位置
                /// </summary>
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public Point2I[] Points;

                /// <summary>
                ///         条码角度
                /// </summary>
                /// <remarks>
                ///         取值范围0~1800 （为啥变大了10倍？）
                /// </remarks>
                public int Angle;

                /// <summary>
                ///         主包ID
                /// </summary>
                public uint MainPackageId;

                /// <summary>
                ///         次包ID
                /// </summary>
                public uint SubPackageId;

                /// <summary>
                ///         保留
                /// </summary>
                [MarshalAs(UnmanagedType.U4, SizeConst = 2)] public uint[] Reserved;
        }
}