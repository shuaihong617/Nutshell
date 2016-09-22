using System.Xml.Serialization;
using Nutshell.Data.Models;

namespace Nutshell.Drawing.Shapes.Models
{
        /// <summary>
        ///         刻度
        /// </summary>
        [XmlType]
        public class NSScaleModel : StorableModel
        {
                public NSScaleModel()
                {
                        SegmentModel = new NSSegmentModel();
                }

                /// <summary>
                ///         线段数据模型
                /// </summary>
                [XmlElement]
                public NSSegmentModel SegmentModel { get; set; }

                /// <summary>
                ///         刻度值
                /// </summary>
                [XmlAttribute]
                public int Value { get; set; }
        }
}