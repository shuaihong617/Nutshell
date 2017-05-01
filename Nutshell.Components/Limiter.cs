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

using Nutshell.Components.Models;
using Nutshell.Storaging;

namespace Nutshell.Components
{
        /// <summary>
        /// 限位
        /// </summary>
        public class Limiter:StorableObject,IStorable<LimiterModel>
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
                public bool IsSuitable { get; private set; }

		/// <summary>
		///         从数据模型加载数据
		/// </summary>
		/// <param name="model">读取数据的源数据模型，该数据模型不能为空引用</param>
		public void Load(LimiterModel model)
		{
			base.Load(model);

			Mode = model.Mode;
			Accuracy = model.Accuracy;
			StandardValue = model.StandardValue;
		}

		/// <summary>
		///         保存数据到数据模型
		/// </summary>
		/// <param name="model">写入数据的目的数据模型，该数据模型不能为空引用</param>
		public void Save(LimiterModel model)
		{
			throw new System.NotImplementedException();
		}

		public virtual void SetParcticeValue(double value)
                {
                        
                }

	        
        }
}
