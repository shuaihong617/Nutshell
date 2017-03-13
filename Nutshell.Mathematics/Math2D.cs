// ***********************************************************************
// Assembly         : FutureTech
// Author           : 帅红
// EMail            : shuaihong617@qq.com
// Created          : 2014-09-18
//
// Last Modified By : 帅红
// Last Modified On : 2014-08-22
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Nutshell.Mathematics
{
        /// <summary>
        ///         2D数学函数
        /// </summary>
        public class Math2D
        {
                /// <summary>
                ///         一阶线性差值
                /// </summary>
                /// <param name="y1">The y1.</param>
                /// <param name="h1">The h1.</param>
                /// <param name="y2">The y2.</param>
                /// <param name="h2">The h2.</param>
                /// <param name="y">The asynchronous.</param>
                /// <param name="threshold">精度阈值</param>
                /// <returns>System.Double.</returns>
                public static double Intrpolate(double y1, double h1, double y2, double h2, double y,
                        double threshold = 0.5)
                {
                        if (Math.Abs(y - y1) < threshold)
                        {
                                return h1;
                        }

                        if (Math.Abs(y - y2) < threshold)
                        {
                                return h2;
                        }

                        return h1 - (h1 - h2) * (y1 - y) / (y1 - y2);
                }

                /// <summary>
                ///         已知纵坐标求一阶线性插值横坐标
                /// </summary>
                /// <param name="x1">The x1.</param>
                /// <param name="y1">The y1.</param>
                /// <param name="x2">The x2.</param>
                /// <param name="y2">The y2.</param>
                /// <param name="y">The asynchronous.</param>
                /// <param name="threshold">精度阈值</param>
                /// <returns>System.Double.</returns>
                public static float HorizontalIntrpolate(float x1, float y1, float x2, float y2, float y,
                        float threshold = 0.1f)
                {
                        x1.MustNumber();
                        y1.MustNumber();
                        x2.MustNumber();
                        y2.MustNumber();
                        y.MustNumber();
                        threshold.MustNumber();

                        if (Math.Abs(x1 - x2) < threshold)
                        {
                                return (x1 + x2) / 2;
                        }

                        return x1 - (x1 - x2) * (y1 - y) / (y1 - y2);
                }

                /// <summary>
                ///         已知横坐标求一阶线性插值纵坐标
                /// </summary>
                /// <param name="x1">The x1.</param>
                /// <param name="y1">The y1.</param>
                /// <param name="x2">The x2.</param>
                /// <param name="y2">The y2.</param>
                /// <param name="x">The asynchronous.</param>
                /// <param name="threshold">精度阈值</param>
                /// <returns>System.Double.</returns>
                public static float VerticalIntrpolate(float x1, float y1, float x2, float y2, float x,
                        float threshold = 0.1f)
                {
                        x1.MustNumber();
                        y1.MustNumber();
                        x2.MustNumber();
                        y2.MustNumber();
                        x.MustNumber();
                        threshold.MustNumber();

                        if (Math.Abs(x1 - x2) < threshold)
                        {
                                return (x1 + x2) / 2;
                        }

                        return y1 - (y1 - y2) * (x1 - x) / (x1 - x2);
                }

                /// <summary>
                ///         两点之间距离平方
                /// </summary>
                /// <param name="x1">The x1.</param>
                /// <param name="y1">The y1.</param>
                /// <param name="x2">The x2.</param>
                /// <param name="y2">The y2.</param>
                /// <returns>System.Int32.</returns>
                public static int PointToPointSquareDistance(int x1, int y1, int x2, int y2)
                {
                        return (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2);
                }

                /// <summary>
                ///         两点之间距离平方
                /// </summary>
                /// <param name="p1">The p1.</param>
                /// <param name="p2">The p2.</param>
                /// <returns>System.Int32.</returns>
                public static int PointToPointSquareDistance(Point p1, Point p2)
                {
                        return PointToPointSquareDistance(p1.X, p1.Y, p2.X, p2.Y);
                }

                /// <summary>
                ///         已知横坐标求一阶线性插值纵坐标
                /// </summary>
                /// <param name="x1">The x1.</param>
                /// <param name="y1">The y1.</param>
                /// <param name="x2">The x2.</param>
                /// <param name="y2">The y2.</param>
                /// <param name="x">The asynchronous.</param>
                /// <param name="y">The y.</param>
                /// <param name="threshold">精度阈值</param>
                /// <returns>System.Double.</returns>
                public static float PointToLineDistance(float x1, float y1, float x2, float y2, float x, float y,
                        float threshold = 0.1f)
                {
                        x1.MustNumber();
                        y1.MustNumber();
                        x2.MustNumber();
                        y2.MustNumber();
                        x.MustNumber();
                        y.MustNumber();
                        threshold.MustNumber();

                        if (Math.Abs(x1 - x2) < threshold)
                        {
                                return Math.Abs((x1 + x2) / 2 - x);
                        }

                        if (Math.Abs(y1 - y2) < threshold)
                        {
                                return Math.Abs((y1 + y2) / 2 - y);
                        }

                        float a = 1 / (x1 - x2);
                        float b = 1 / (y2 - y1);
                        float c = y1 / (y1 - y2) - x1 / (x1 - x2);

                        float top = Math.Abs(a * x + b * y + c);
                        double bottom = Math.Sqrt(a * a + b * b);

                        return top / (float)bottom;
                }

                /// <summary>
                ///         Points to line distance.
                /// </summary>
                /// <param name="p1">The p1.</param>
                /// <param name="p2">The p2.</param>
                /// <param name="p">The p.</param>
                /// <param name="threshold">The threshold.</param>
                /// <returns>System.Single.</returns>
                public static float PointToLineDistance(Point p1, Point p2, Point p, float threshold = 0.1f)
                {
                        return PointToLineDistance(p1.X, p1.Y, p2.X, p2.Y, p.X, p.Y, threshold);
                }

                /// <summary>
                ///         Horizontas the point to line distance.
                /// </summary>
                /// <param name="x1">The x1.</param>
                /// <param name="y1">The y1.</param>
                /// <param name="x2">The x2.</param>
                /// <param name="y2">The y2.</param>
                /// <param name="x">The x.</param>
                /// <param name="y">The y.</param>
                /// <param name="threshold">The threshold.</param>
                /// <returns>System.Single.</returns>
                public static float PointToLineHorizontalDistance(float x1, float y1, float x2, float y2, float x,
                        float y, float threshold = 0.1f)
                {
                        x1.MustNumber();
                        y1.MustNumber();
                        x2.MustNumber();
                        y2.MustNumber();
                        x.MustNumber();
                        y.MustNumber();
                        threshold.MustNumber();

                        float r = PointToLineDistance(x1, y1, x2, y2, x, y, threshold);
                        float x3 = HorizontalIntrpolate(x1, y1, x2, y2, y, threshold);
                        return r * Math.Sign(x - x3);
                }

                /// <summary>
                ///         Verticals the point to line distance.
                /// </summary>
                /// <param name="x1">The x1.</param>
                /// <param name="y1">The y1.</param>
                /// <param name="x2">The x2.</param>
                /// <param name="y2">The y2.</param>
                /// <param name="x">The x.</param>
                /// <param name="y">The y.</param>
                /// <param name="threshold">The threshold.</param>
                /// <returns>System.Single.</returns>
                public static float PointToLineVerticalDistance(float x1, float y1, float x2, float y2, float x, float y,
                        float threshold = 0.1f)
                {
                        x1.MustNumber();
                        y1.MustNumber();
                        x2.MustNumber();
                        y2.MustNumber();
                        x.MustNumber();
                        y.MustNumber();
                        threshold.MustNumber();

                        float r = PointToLineDistance(x1, y1, x2, y2, x, y, threshold);
                        float y3 = VerticalIntrpolate(x1, y1, x2, y2, x, threshold);

                        return r * Math.Sign(y3 - y);
                }

                /// <summary>
                ///         最小二乘法直线拟合
                /// </summary>
                /// <param name="points">拟合点集合</param>
                /// <returns>二元组, 第一分量表示斜率, 第二分量表示截距</returns>
                public static Tuple<float, float> LeastSquare(List<Point> points)
                {
                        float sumX2 = 0f;
                        float sumX = 0f;
                        float sumXy = 0f;
                        float sumY = 0f;

                        if (points.Count < 2)
                        {
                                return Tuple.Create(0f, 0f);
                        }

                        foreach (Point point in points)
                        {
                                sumX2 += point.X * point.X;
                                sumX += point.X;
                                sumXy += point.X * point.Y;
                                sumY += point.Y;
                        }

                        float deta = sumX2 * points.Count - sumX * sumX;

                        //斜率
                        float k = (sumXy * points.Count - sumX * sumY) / deta;
                        k = k.WillNumber();

                        //截距
                        float d = (sumX2 * sumY - sumXy * sumX) / deta;
                        d = d.WillNumber();

                        return Tuple.Create(k, d);
                }

                /// <summary>
                ///         Crosses the point f.
                /// </summary>
                /// <param name="line1BeginPoint">The line1 begin point.</param>
                /// <param name="line1EndPoint">The line1 end point.</param>
                /// <param name="line2BeginPoint">The line2 begin point.</param>
                /// <param name="line2EndPoint">The line2 end point.</param>
                /// <returns>PointF.</returns>
                public static PointF CrossPointF(Point line1BeginPoint, Point line1EndPoint,
                        Point line2BeginPoint, Point line2EndPoint)
                {
                        float x1 = line1BeginPoint.X;
                        float y1 = line1BeginPoint.Y;

                        float x2 = line1EndPoint.X;
                        float y2 = line1EndPoint.Y;

                        float x3 = line2BeginPoint.X;
                        float y3 = line2BeginPoint.Y;

                        float x4 = line2EndPoint.X;
                        float y4 = line2EndPoint.Y;

                        float dx43 = x4 - x3;
                        float dx21 = x2 - x1;

                        float dy43 = y4 - y3;
                        float dy21 = y2 - y1;

                        float x = (dx43 * (x1 * y2 - x2 * y1) - dx21 * (x3 * y4 - x4 * y3)) / (dy21 * dx43 - dy43 * dx21);
                        float y = (x - x1) * dy21 / dx21 + y1;

                        return new PointF(x, y);
                }
        }
}