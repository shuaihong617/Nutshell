using Nutshell.Extensions;
using System;
using System.Drawing;

namespace Nutshell.Mathematics
{
        public static class Geometry2D
        {
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
                ///         点到直线距离
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
                ///         点到直线距离
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
        }
}