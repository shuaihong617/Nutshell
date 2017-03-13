// ***********************************************************************

// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-12-09
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-12-09
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Nutshell.Mathematics
{
        /// <summary>
        ///         线性插值工具类
        /// </summary>
        public static class LinearInterpolation
        {
                /// <summary>
                ///         一阶线性差值
                /// </summary>
                /// <param name="x1">The y1.</param>
                /// <param name="y1">The h1.</param>
                /// <param name="x2">The y2.</param>
                /// <param name="y2">The h2.</param>
                /// <param name="x">The asynchronous.</param>
                /// <param name="threshold">精度阈值</param>
                /// <returns>System.float.</returns>
                public static float Intrpolate(float x1, float y1, float x2, float y2, float x,
                        float threshold = 0.1f)
                {
                        x1.MustNumber();
                        y1.MustNumber();
                        x2.MustNumber();
                        y2.MustNumber();
                        x.MustNumber();
                        threshold.MustNumber();

                        if (Math.Abs(x - x1) < threshold)
                        {
                                return y1;
                        }

                        if (Math.Abs(x - x2) < threshold)
                        {
                                return y2;
                        }

                        return y1 - (y1 - y2) * (x1 - x) / (x1 - x2);
                }

                /// <summary>
                ///         2D直角坐标系下根据已知点集合和横坐标, 区间内插值求纵坐标
                /// </summary>
                /// <param name="points">点集合, 不要求横坐标有序</param>
                /// <param name="x">横坐标</param>
                /// <param name="threshold">精度阈值</param>
                /// <returns>纵坐标</returns>
                /// <remarks>横坐标在点集区间内时插值求值, 在区间外时取极值</remarks>
                public static float Intrpolate(List<PointF> points, float x, float threshold = 0.1f)
                {
                        points.Count.MustGreaterThanOrEqual(2);

                        foreach (PointF point in points)
                        {
                                point.X.MustNumber();
                                point.Y.MustNumber();
                        }

                        x.MustNumber();
                        threshold.MustNumber();

                        List<PointF> orderPoints = points.OrderBy(i => i.X).ToList();

                        PointF great = orderPoints.Last();

                        PointF small = orderPoints.First();

                        if (x > great.X)
                        {
                                return great.Y;
                        }

                        if (x < small.X)
                        {
                                return small.Y;
                        }

                        foreach (PointF point in orderPoints)
                        {
                                if (x.IsEqual(point.X))
                                {
                                        return point.Y;
                                }

                                if (small.X < point.X && point.X < x)
                                {
                                        small = point;
                                }

                                if (x < point.X && point.X < great.X)
                                {
                                        great = point;
                                }
                        }

                        return great.Y - (great.Y - small.Y) * (great.X - x) / (great.X - small.X);
                }
        }
}