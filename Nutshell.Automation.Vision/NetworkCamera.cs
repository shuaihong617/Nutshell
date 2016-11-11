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
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Data.Models;
using Nutshell.Drawing.Imaging;
using Nutshell.Hardware.Vision.Models;

namespace Nutshell.Hardware.Vision
{
        /// <summary>
        /// 网络摄像机
        /// </summary>
        public abstract class NetworkCamera : Camera
        {
                /// <summary>
                /// 初始化<see cref="NetworkCamera"/>的新实例.
                /// </summary>
                /// <param name="parent">上级对象</param>
                /// <param name="id">标识</param>
                /// <param name="width">宽度</param>
                /// <param name="height">高度</param>
                /// <param name="pixelFormat">图像格式</param>
                /// <param name="ipAddress">IP地址</param>
                protected NetworkCamera(IdentityObject parent, string id, int width, int height, NSPixelFormat pixelFormat,
                        string ipAddress)
                        : base(parent, id, width, height, pixelFormat)
                {
                        IPAddress = IPAddress.Parse(ipAddress);
                }

                /// <summary>
                /// IP地址
                /// </summary>
                public IPAddress IPAddress { get; private set; }

                /// <summary>
                /// 从数据模型加载数据
                /// </summary>
                /// <param name="model">数据模型</param>
                public override void Load([AssignableFrom(typeof(INetworkCameraModel))]IDataModel model)
                {
                        base.Load(model);

                        var gigeCameraModel = model as INetworkCameraModel;
                        IPAddress = IPAddress.Parse(gigeCameraModel.IPAddress);
                }


                /// <summary>
                /// 保存数据到数据模型
                /// </summary>
                /// <param name="model">数据模型</param>
                public override void Save([AssignableFrom(typeof(INetworkCameraModel))]IDataModel model)
                {
                        base.Save(model);

                        var gigeCameraModel = model as INetworkCameraModel;
                        gigeCameraModel.IPAddress = IPAddress.ToString();
                }
        }
}