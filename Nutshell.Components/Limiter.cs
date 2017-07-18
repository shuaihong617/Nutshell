// ***********************************************************************
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

using System.Diagnostics;
using Nutshell.Components.Models;
using Nutshell.Data.Models;
using Nutshell.Storaging;

namespace Nutshell.Components
{
        /// <summary>
        /// 限位
        /// </summary>
        public class Limiter:StorableObject
        {
                /// <summary>
                /// 获取限位模式
                /// </summary>
                /// <value>限位模式</value>
                public LimitMode Mode { get; private set; }

                /// <summary>
                /// 获取精度
                /// </summary>
                /// <value>精度</value>
                public double Accuracy { get; private set; }

                /// <summary>
                /// 获取标准值
                /// </summary>
                /// <value>标准值</value>
                public double Standard { get; private set; }

                /// <summary>
                /// 获取修正值
                /// </summary>
                /// <value>修正值</value>
		public double Addition { get; set; }

                /// <summary>
                /// 获取实际值
                /// </summary>
                /// <value>实际值</value>
                public double Parctice { get; set; }

                /// <summary>
                /// 获取差值结果
                /// </summary>
                /// <value>差值结果</value>
                public double Offset => Parctice - Standard + Addition;

                /// <summary>
                /// 获取实际值是否在合适的区间
                /// </summary>
                /// <value><c>true</c> if this instance is over; otherwise, <c>false</c>.</value>
                public bool IsValid { get; private set; }

                public override void Load(IIdentityModel model)
                {
                        base.Load(model);

                        var subModel = model as LimiterModel;
                        Trace.Assert(subModel != null);

                        Mode = subModel.Mode;
                }

                /// <summary>
                /// Sets the parctice value.
                /// </summary>
                /// <param name="value">The value.</param>
                public virtual void SetParcticeValue(double value)
                {

                }
        }
}
