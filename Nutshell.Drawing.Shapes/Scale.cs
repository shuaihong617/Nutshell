using Nutshell.Components;
using Nutshell.Data;
using Nutshell.Drawing.Shapes.Models;
using Nutshell.Extensions;
using System;

namespace Nutshell.Drawing.Shapes
{
        /// <summary>
        ///         刻度
        /// </summary>
        public class Scale : StorableObject, IHitable, IStorable<IScaleModel>
        {
                public Scale(string id = "")
                        : base(id)
                {
                        Segment = new Segment();
                }

                public Segment Segment { get; }

                public virtual int Value { get; private set; }

                public void Load(IScaleModel model)
                {
                        base.Load(model);

                        Value = model.Value;

                        //scaleModel.SegmentModel.NotNull();
                        //Segment.Load(scaleModel.SegmentModel);
                }

                public void Save(IScaleModel model)
                {
                        base.Save(model);

                        model.Value = Value;

                        //Segment.Save(scaleModel.SegmentModel);
                }

                /// <summary>
                ///         命中测试
                /// </summary>
                /// <param name="x">横坐标</param>
                /// <param name="y">纵坐标</param>
                /// <param name="threshold">对点、线等非连通图形测试时阈值</param>
                /// <returns>如果命中返回<c>true</c>, 否则返回<c>false</c></returns>
                public virtual bool HitTest(float x, float y, float threshold = 16)
                {
                        var xmax = Math.Max(Segment.X1, Segment.X2);
                        var xmin = Math.Min(Segment.X1, Segment.X2);

                        var ymax = Math.Max(Segment.Y1, Segment.Y2);
                        var ymin = Math.Min(Segment.Y1, Segment.Y2);

                        return x.IsBetween(xmax + threshold, xmin - threshold)
                               && (y.IsBetween(ymax + threshold, ymin - threshold));
                }
        }
}