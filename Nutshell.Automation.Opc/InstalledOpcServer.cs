// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-02-11
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-02-11
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************
using Nutshell.Aspects.Locations.Contracts;

namespace Nutshell.Automation.Opc
{
        /// <summary>
        /// 系统已安装OpcServer
        /// </summary>
        public class InstalledOpcServer : IdentityObject
        {
                /// <summary>
                /// 初始化<see cref="InstalledOpcServer"/>的新实例.
                /// </summary>
                /// <param name="address">OpcServer地址.</param>
                public InstalledOpcServer([MustNotEqualNullOrEmpty]string address)
                        : base(address)
                {
                        Address = address;
                }

                #region 属性

                /// <summary>
                /// 获取OpcServer地址.
                /// </summary>
                /// <value>OpcServer地址.</value>
                [MustNotEqualNullOrEmpty]
                public string Address { get; private set; }

                #endregion 属性
        }
}