using Nutshell.Data.Xml.Models;
using Nutshell.Drawing.Shapes.Models;
using System.Xml.Serialization;
using Nutshell.Storaging.Xml.Models;

namespace Nutshell.Drawing.Shapes.Xml.Models
{
        /// <summary>
        ///         刻度
        /// </summary>
        [XmlType]
        public class XmlScaleModel : XmlDataModel, IScaleModel
        {
                public XmlScaleModel()
                {
                        XmlSegmentModel = new XmlSegmentModel();
                }

                /// <summary>
                ///         线段数据模型
                /// </summary>
                [XmlElement]
                public XmlSegmentModel XmlSegmentModel { get; set; }

                /// <summary>
                ///         刻度值
                /// </summary>
                [XmlAttribute]
                public int Value { get; set; }
        }
}