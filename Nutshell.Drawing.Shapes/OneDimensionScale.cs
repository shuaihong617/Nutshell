// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-07-07
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-07-18
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

namespace Nutshell.Drawing.Shapes
{
        /// <summary>
        /// 一维刻度
        /// </summary>
        public class OneDimensionScale : Scale
        {
                /// <summary>
                /// 初始化<see cref="OneDimensionScale" />的新实例.
                /// </summary>
                /// <param name="parent">The parent.</param>
                /// <param name="id">The identifier.</param>
                public OneDimensionScale(IdentityObject parent, string id = "")
                        : base(parent, id)
                {
                }


                /// <summary>
                /// 命中测试
                /// </summary>
                /// <param name="x">横坐标</param>
                /// <param name="y">纵坐标</param>
                /// <param name="threshold">对点、线等非连通图形测试时阈值</param>
                /// <returns>如果命中返回<c>true</c>, 否则返回<c>false</c></returns>
                public override bool HitTest(float x, float y, float threshold = 16)
                {
                        return y.IsBetween(Y + threshold, Y - threshold);
                }
        }
}