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
        /// 条码识别结果结构体
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct BarcodeRecognitionResult
        {
                /// <summary>
                /// 条码数量
                /// </summary>
                public uint CodesCount;                           // 条码数量

                /// <summary>
                /// Gets or sets the <see cref="MV_SC_BCR_INFO"/> with the specified [ERROR: invalid expression Parameters.First.Name.Words.All].
                /// </summary>
                /// <returns>MV_SC_BCR_INFO.</returns>
                BarcodeRecognitionInformation[] stBcrInfo[MAX_SC_BCR_COUNT];        // 条码信息结构体
                uint nReserved[4];                       // 保留
        }
}