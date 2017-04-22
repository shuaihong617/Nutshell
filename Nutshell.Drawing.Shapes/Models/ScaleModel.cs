using System.Xml.Serialization;
using Nutshell.Storaging.Models;

namespace Nutshell.Drawing.Shapes.Models
{
        /// <summary>
        ///         刻度
        /// </summary>
        [XmlType]
        public class ScaleModel : DataModel
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
                [XmlAttribute]
                public int Value { get; set; }
        }
}