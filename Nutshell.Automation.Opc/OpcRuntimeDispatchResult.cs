// ***********************************************************************
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
using System.Collections.ObjectModel;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Opc;

namespace Nutshell.Automation.Opc
{
        /// <summary>
        ///         工作结果接口
        /// </summary>
        public class OpcRuntimeDispatchResult : Result
        {
                public OpcRuntimeDispatchResult([MustNotEqualNull]Version opcVersion, 
			[MustNotEqualNull]ReadOnlyCollection<InstalledOpcServer> installedOpcServers)
                        :base(true)
                {
                        OpcVersion = opcVersion;
                        InstalledOpcServers = installedOpcServers;
                }

                [MustNotEqualNull]
                public ReadOnlyCollection<InstalledOpcServer> InstalledOpcServers { get; private set; }

                [MustNotEqualNull]
                public Version OpcVersion { get; private set; }
        }
}