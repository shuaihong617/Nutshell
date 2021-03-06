﻿// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-09-05
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-09-05
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Components.Models;
using Nutshell.Data.Models;
using Nutshell.Extensions;
using Nutshell.IO.Aspects.Locations.Contracts;
using Nutshell.Serializing.Xml;
using Nutshell.Storaging;
using Nutshell.Storaging.Xml;

namespace Nutshell.Components
{
        /// <summary>
        ///         封装应用程序实例标识
        /// </summary>
        public class AppInstance : StorableObject
        {
                public AppInstance()
                        :this(String.Empty)
                {
                }

                public AppInstance(string id)
                        : this(id, String.Empty, "1.0.0.1")
                {
                }

                public AppInstance(string id, string name, string version, string title="", string company="武汉九鼎", string copyright = "武汉九鼎")
                        :base(id)
                {
                        
                        Name = name.IsNotNullOrEmpty()? name:GetType().ToString();
                        Version = version;
                        Title = title.IsNotNullOrEmpty()?title:GetType().ToString();
                        Company = company;
                        CopyRight = copyright;
                }

                /// <summary>
                ///         获取应用程序名称
                /// </summary>
                /// <value>应用程序名称</value>
                [MustNotEqualNullOrEmpty]
                public string Name { get; private set; }

                /// <summary>
                ///         获取版本
                /// </summary>
                /// <value>版本</value>
                [MustNotEqualNullOrEmpty]
                public string Version { get; set; }

                /// <summary>
                ///         获取应用程序标题
                /// </summary>
                /// <value>应用程序标题</value>
                [MustNotEqualNullOrEmpty]
                public string Title { get; private set; }

                /// <summary>
                ///         获取公司
                /// </summary>
                /// <value>公司</value>
                [MustNotEqualNullOrEmpty]
                public string Company { get; private set; }

                /// <summary>
                ///         获取版权信息
                /// </summary>
                /// <value>版权信息</value>
                [MustNotEqualNullOrEmpty]
                public string CopyRight { get; private set; }

                

                public override void Load(IIdentityModel model)
                {
                        base.Load(model);

                        var subMode = model as AppInstanceModel;
                        Trace.Assert(subMode != null);

                        Name = subMode.Name;
                        Title = subMode.Title;
                        Company = subMode.Company;
                        CopyRight = subMode.CopyRight;
                }

                public void Save(AppInstanceModel model)
                {
                }
        }
}