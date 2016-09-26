// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-08-02
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-08-04
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Aspects.LocationContracts;

namespace Nutshell.Drawing
{
        /// <summary>
        ///         Class NSBitmap.
        /// </summary>
        public class NSResolution : IdentityObject
        {
                /// <summary>
                ///         初始化<see cref="NSResolution" />的新实例.
                /// </summary>
                /// <param name="parent">The parent.</param>
                /// <param name="id">The identifier.</param>
                /// <param name="horizontal">The horizontal.</param>
                /// <param name="vertical">The vertical.</param>
                public NSResolution(IdentityObject parent, string id, int horizontal, int vertical)
                        : base(parent, id)
                {
                        Horizontal = horizontal;
                        Vertical = vertical;
                }

                /// <summary>
                ///         Gets the width.
                /// </summary>
                [GreaterThan(0)]
                public int Horizontal { get; private set; }

                /// <summary>
                ///         Gets the height.
                /// </summary>
                /// <value>The height.</value>
                [GreaterThan(0)]
                public int Vertical { get; private set; }

                /// <summary>
                /// 返回表示当前对象的字符串。
                /// </summary>
                /// <returns>
                /// 表示当前对象的字符串。
                /// </returns>
                public override string ToString()
                {
                        return string.Format("{0}：水平{1} 垂直{2}", GlobalId, Horizontal, Vertical);
                }
        }
}
