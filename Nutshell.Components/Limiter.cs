// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-04-21
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-04-21
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳.. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

namespace Nutshell.Components
{
        /// <summary>
        /// 限位
        /// </summary>
        public class Limiter
        {
                /// <summary>
                /// Gets the mode.
                /// </summary>
                /// <value>The mode.</value>
                public LimitMode Mode { get; private set; }

                public double Accuracy { get; private set; }

                /// <summary>
                /// Gets the standard value.
                /// </summary>
                /// <value>The standard value.</value>
                public double StandardValue { get; private set; }
                /// <summary>
                /// Gets the parctical value.
                /// </summary>
                /// <value>The parctical value.</value>
                public double ParcticeValue { get; private set; }

                /// <summary>
                /// Gets a value indicating whether this instance is over.
                /// </summary>
                /// <value><c>true</c> if this instance is over; otherwise, <c>false</c>.</value>
                public double IsSuitable { get; private set; }

                public void SetParcticeValue(double value)
                {
                        
                }
        }
}
