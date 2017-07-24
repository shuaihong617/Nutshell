// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-06-28
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-07-09
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.Diagnostics;
using System.Net;
using Nutshell.Automation.Vision.Models;
using Nutshell.Data.Models;
using Nutshell.Drawing.Imaging;

namespace Nutshell.Automation.Vision
{
        /// <summary>
        ///         网络媒体采集设备
        /// </summary>
        public abstract class NetworkMediaCaptureDevice : MediaCaptureDevice
        {
                /// <summary>
                ///         初始化<see cref="NetworkMediaCaptureDevice" />的新实例.
                /// </summary>
                /// <param name="id">标识</param>
                /// <param name="width">宽度</param>
                /// <param name="height">高度</param>
                /// <param name="pixelFormat">图像格式</param>
                /// <param name="ipAddress">IP地址</param>
                protected NetworkMediaCaptureDevice(string id, int width, int height, PixelFormat pixelFormat,
                        string ipAddress)
                        : base(id, width, height, pixelFormat)
                {
                        IPAddress = IPAddress.Parse(ipAddress);
                }

                /// <summary>
                ///         IP地址
                /// </summary>
                public IPAddress IPAddress { get; private set; }

                #region 方法

                #region 存储

                /// <summary>
                ///         从数据模型加载数据
                /// </summary>
                /// <param name="model">读取数据的源数据模型，该数据模型不能为空引用.</param>
                public override void Load(IIdentityModel model)
                {
                        base.Load(model);

                        var subModel = model as NetworkMediaCaptureDeviceModel;
                        Trace.Assert(subModel != null);


                        IPAddress = IPAddress.Parse(subModel.IPAddress);

                        Trace.Assert(!Equals(IPAddress, IPAddress.Any));
                        Trace.Assert(!Equals(IPAddress, IPAddress.None));
                        Trace.Assert(!Equals(IPAddress, IPAddress.Loopback));
                }

                #endregion 存储

                #endregion 方法
        }
}