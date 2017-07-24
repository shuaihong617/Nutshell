// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-01-05
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-01-05
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.Diagnostics;
using System.Xml.Serialization;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Data.Models;
using Nutshell.Hikvision.DigitalVideo.Models;
using Nutshell.Storaging;

namespace Nutshell.Hikvision.DigitalVideo
{
        /// <summary>
        ///         数字视频设备授权
        /// </summary>
        public class DigitalVideoAuthorization : StorableObject
        {
                public DigitalVideoAuthorization()
                {
                        
                }

                /// <summary>
                ///         获取或设置端口
                /// </summary>
                /// <value>端口</value>
                [MustGreaterThan(0)]
                [XmlAttribute]
                public int PortNumber { get;private set; } = 8000;

                /// <summary>
                ///         获取用户
                /// </summary>
                /// <value>用户</value>
                [MustNotEqualNullOrEmpty]
                public string UserName { get; private set; } = "admin";

                /// <summary>
                ///         获取密码
                /// </summary>
                /// <value>密码</value>
                [MustNotEqualNullOrEmpty]
                public string Password { get; private set; } = "JDKD123456";

                public override void Load(IIdentityModel model)
                {
                        base.Load(model);

                        var subModel = model as DigitalVideoAuthorizationModel;
                        Trace.Assert(subModel != null);

                        UserName = subModel.UserName;
                        Password = subModel.Password;
                }
        }

        
}