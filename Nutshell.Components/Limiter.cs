﻿// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-04-22
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-05-02
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳.. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Components.Models;
using Nutshell.Storaging;

namespace Nutshell.Components
{
        /// <summary>
        /// 限位
        /// </summary>
        public class Limiter:Distance,IStorable<LimiterModel>
        {
                /// <summary>
                /// 获取限位模式
                /// </summary>
                /// <value>限位模式</value>
                public LimitMode Mode { get; private set; }

                /// <summary>
                /// 获取实际值是否在合适的区间
                /// </summary>
                /// <value><c>true</c> if this instance is over; otherwise, <c>false</c>.</value>
                public bool IsValid { get; private set; }

                /// <summary>
                /// 从数据模型加载数据
                /// </summary>
                /// <param name="model">读取数据的源数据模型，该数据模型不能为空引用</param>
                public void Load(LimiterModel model)
		{
			base.Load(model);

			Mode = model.Mode;
		}

                /// <summary>
                /// 保存数据到数据模型
                /// </summary>
                /// <param name="model">写入数据的目的数据模型，该数据模型不能为空引用</param>
                /// <exception cref="System.NotImplementedException"></exception>
                public void Save(LimiterModel model)
		{
			throw new System.NotImplementedException();
		}
        }
}
