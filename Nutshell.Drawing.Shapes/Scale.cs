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
                public Scale(IdentityObject parent, string id = "")
                        : base(parent, id)
                {
                }

                public int X { get; set; }

                public int Y { get; set; }

                public virtual int Value { get; private set; }

                public Ruler Ruler { get; set; }

                public override void Load(IStorableModel model)
                {
                        var scaleModel = model as ScaleModel;
                        scaleModel.MustNotNull();

                        base.Load(model);

                        X = scaleModel.X;
                        Y = scaleModel.Y;
                        Value = scaleModel.Value;
                }

                public override void Save(IStorableModel model)
                {
                        var scaleModel = model as ScaleModel;
                        scaleModel.MustNotNull();

                        base.Save(model);

                        scaleModel.X = X;
                        scaleModel.Y = Y;
                        scaleModel.Value = Value;
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
                        return x.IsBetween(X + threshold, X - threshold)
                               && (y.IsBetween(Y + threshold, Y - threshold));
                }
        }
}