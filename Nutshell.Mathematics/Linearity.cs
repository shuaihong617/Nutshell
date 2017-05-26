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

using Nutshell.Data;
using Nutshell.Extensions;
using Nutshell.Mathematics.Models;
using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Storaging;
using Nutshell.Storaging.Models;

namespace Nutshell.Mathematics
{
        /// <summary>
        ///         线性参数
        /// </summary>
        public class Linearity : StorableObject,IStorable<LinearityModel>
        {
                public Linearity(float slope = 0f, float intercept = 0f)
                {
                        Slope = slope;
                        Intercept = intercept;
                }

                /// <summary>
                ///         斜率
                /// </summary>
                public float Slope { get; private set; }

                /// <summary>
                ///         截距
                /// </summary>
                public float Intercept { get; private set; }

                public void Load([MustNotEqualNull]LinearityModel model)
                {
                        base.Load(model);

                        Slope = model.Slope;
                        Intercept = model.Intercept;
                }

                public void Save([MustNotEqualNull] LinearityModel model)
                {
                        model.Slope = Slope;
                        model.Intercept = Intercept;

                        base.Save(model);
                }

                /// <summary>
                ///         返回表示当前对象的字符串。
                /// </summary>
                /// <returns>
                ///         表示当前对象的字符串。
                /// </returns>
                public override string ToString()
                {
                        return $"{GlobalId}  斜率:{Slope:F3}， 截距:{Intercept:F3}";
                }
        }
}