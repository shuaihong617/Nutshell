using System;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Components;
using Nutshell.Data;
using Nutshell.Data.Models;
using Nutshell.Drawing.Shapes.Models;

namespace Nutshell.Drawing.Shapes
{
        /// <summary>
        ///         刻度
        /// </summary>
        public class Scale : StorableObject, IHitTest
        {
                public Scale(string id = null)
                        : base( id)
                {
                        Segment = new Segment(this);
                }

                public Segment Segment { get;private set; }

                public virtual int Value { get; private set; }

                public override void Load([MustAssignableFrom(typeof(IScaleModel))]IDataModel model)
                {

                        base.Load(model);

                        var scaleModel = model as IScaleModel;
                        Value = scaleModel.Value;

                        //scaleModel.SegmentModel.NotNull();
                        //Segment.Load(scaleModel.SegmentModel);

                }

                public override void Save([MustAssignableFrom(typeof(IScaleModel))]IDataModel model)
                {
                        base.Save(model);

                        var scaleModel = model as IScaleModel;
                        scaleModel.Value = Value;

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