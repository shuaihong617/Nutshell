using Nutshell.Components;

namespace Nutshell.Drawing.Shapes
{
        /// <summary>
        ///         直线刻度
        /// </summary>
        public class LineScale : Scale, IHitTest
        {
                public LineScale(IdentityObject parent, string id = "")
                        : base(parent, id)
                {
                }

                

                
                /// <summary>
                ///         命中测试
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