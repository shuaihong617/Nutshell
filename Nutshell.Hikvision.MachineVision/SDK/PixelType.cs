// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-07-17
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-07-31
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

namespace Nutshell.Hikvision.MachineVision.SDK
{
        /// <summary>
        ///         像素类型
        /// </summary>
        public enum PixelType
        {
                // Undefined pixel type
                Undefined = -1,
                Mono8 = 0x01080001,
                Mono10 = 0x01100003,
                Mono10Packed = 0x010C0004,
                Mono12 = 0x01100005,
                Mono12Packed = 0x010C0006,
                Mono16 = 0x01100007,
                RGB8Packed = 0x02180014,
                YUV422_8 = 0x02100032,
                YUV422_8_UYVY = 0x0210001F,
                YUV8_UYV = 0x02180020,
                YUV411_8_UYYVYY = 0x020C001E,
                BayerGR8 = 0x01080008,
                BayerRG8 = 0x01080009,
                BayerGB8 = 0x0108000A,
                BayerBG8 = 0x0108000B,
                BayerGR10 = 0x0110000c,
                BayerRG10 = 0x0110000d,
                BayerGB10 = 0x0110000e,
                BayerBG10 = 0x0110000f,
                BayerBG10Packed = 0x010C0029,
                BayerGR10Packed = 0x010C0026,
                BayerRG10Packed = 0x010C0027,
                BayerGB10Packed = 0x010C0028,
                BayerGR12 = 0x01100010,
                BayerRG12 = 0x01100011,
                BayerGB12 = 0x01100012,
                BayerBG12 = 0x01100013,
                BayerBG12Packed = 0x010C002D,
                BayerGR12Packed = 0x010C002A,
                BayerRG12Packed = 0x010C002B,
                BayerGB12Packed = 0x010C002C,
                BayerGR16 = 0x0110002E,
                BayerRG16 = 0x0110002F,
                BayerGB16 = 0x01100030,
                BayerBG16 = 0x01100031
        }
}
