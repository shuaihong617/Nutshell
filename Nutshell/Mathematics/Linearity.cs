// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-04-14
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-04-14
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************


using System;
using System.Diagnostics;
using System.Xml.Serialization;
using Nutshell.Data;
using Nutshell.Data.Models;
using Nutshell.Mathematics.Models;

namespace Nutshell.Mathematics
{
        /// <summary>
        ///         线性参数
        /// </summary>
        [XmlRoot]
        public class Linearity : StorableObject
        {
                public Linearity(float slope = 0f, float intercept = 0f)
                {
                        Slope = slope;
                        Intercept = intercept;
                }

                /// <summary>
                ///         斜率
                /// </summary>
                public float Slope { get;private set; }

                /// <summary>
                ///         截距
                /// </summary>
                public float Intercept { get;private set; }


                public override void Load(IStorableModel model)
                {
                        model.MustNotNull();

                        base.Load(model);

                        var linearityModel = model as LinearityModel;
                        Trace.Assert(linearityModel != null);

                        Slope = linearityModel.Slope;
                        Intercept = linearityModel.Intercept;
                }

                public override string ToString()
                {
                        return String.Format("{0}  斜率:{1:F3}， 截距：{2:F3}",Id, Slope, Intercept);
                }
        }
}