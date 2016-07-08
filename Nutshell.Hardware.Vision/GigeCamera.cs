// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-03-11
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-03-11
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.Diagnostics;

using System.Net;
using Nutshell.Data;
using Nutshell.Data.Models;
using Nutshell.Drawing.Imaging;
using Nutshell.Hardware.Vision.Models;
using Nutshell.Log;

namespace Nutshell.Hardware.Vision
{
        public abstract class GigeCamera : Camera
        {
                protected GigeCamera(IdentityObject parent, string id, int width, int height, PixelFormat pixelFormat, string ipAddress)
                        : base(parent, id,width,height, pixelFormat)
                {
                        IPAddress = IPAddress.Parse(ipAddress);
                }

                /// <summary>
                ///         IP地址
                /// </summary>
                public IPAddress IPAddress { get; private set; }

                public override void Load(IStorableModel model)
                {
                        base.Load(model);
                       

                        var gigeCameraModel = model as GigeCameraModel;
                        Trace.Assert(gigeCameraModel != null);

                        IPAddress = IPAddress.Parse(gigeCameraModel.IPAddress);
                }


                public override void Save(IStorableModel model)
                {
                        base.Save(model);

                        var gigeCameraModel = model as GigeCameraModel;
                        Trace.Assert(gigeCameraModel != null);

                        gigeCameraModel.IPAddress = IPAddress.ToString();
                }
        }
}