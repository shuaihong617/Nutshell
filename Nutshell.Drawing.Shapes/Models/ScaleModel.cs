using System.Xml.Serialization;
using Nutshell.Data.Models;

namespace Nutshell.Drawing.Shapes.Models
{
        /// <summary>
        ///         刻度
        /// </summary>
        
        public class ScaleModel :IdentityModel
        {
                public ScaleModel()
                {
                        SegmentModel = new SegmentModel();
                }

                /// <summary>
                ///         线段数据模型
                /// </summary>
                [XmlElement]
                public SegmentModel SegmentModel { get; set; }

                /// <summary>
                ///         刻度值
                /// </summary>
                
                public int Value { get; set; }
        }
}