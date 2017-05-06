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

using Nutshell.Components.Models;
using Nutshell.Storaging;

namespace Nutshell.Components
{
        /// <summary>
        /// 限位
        /// </summary>
        public class Distance:StorableObject,IStorable<DistanceModel>
        {
                /// <summary>
                /// 获取精度
                /// </summary>
                /// <value>精度</value>
                public double Accuracy { get; private set; }

                /// <summary>
                /// 获取标准值
                /// </summary>
                /// <value>标准值</value>
                public double StandardValue { get; private set; }
                
                /// <summary>
                /// 获取实际值
                /// </summary>
                /// <value>实际值</value>
                public double ParcticeValue { get; private set; }


                /// <summary>
		///         Gets a value indicating whether this instance is over.
		/// </summary>
		/// <value><c>true</c> if this instance is over; otherwise, <c>false</c>.</value>
		public double Offset { get; set; }


                /// <summary>
                /// 从数据模型加载数据
                /// </summary>
                /// <param name="model">读取数据的源数据模型，该数据模型不能为空引用</param>
                public void Load(DistanceModel model)
		{
			base.Load(model);

			Accuracy = model.Accuracy;
			StandardValue = model.StandardValue;
		}

                /// <summary>
                /// 保存数据到数据模型
                /// </summary>
                /// <param name="model">写入数据的目的数据模型，该数据模型不能为空引用</param>
                /// <exception cref="System.NotImplementedException"></exception>
                public void Save(DistanceModel model)
		{
			throw new System.NotImplementedException();
		}

                public void SetOffset(double offset)
                {
                        Offset = offset;
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
