﻿// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-12-17
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-12-17
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Components;

namespace Nutshell.Communication
{
        /// <summary>
        /// 交换机
        /// </summary>
        public abstract class Exchanger:Worker, IExchanger
        {
                protected Exchanger(IdentityObject parent, string id = null) 
                        : base(parent, id)
                {
                }
        }
}
