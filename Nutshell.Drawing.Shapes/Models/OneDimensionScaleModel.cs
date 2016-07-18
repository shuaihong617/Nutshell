using System.Xml.Serialization;
using Nutshell.Data.Models;

namespace Nutshell.Drawing.Shapes.Models
{
        /// <summary>
        ///         刻度
        /// </summary>
        /// <value>The width.</value>
        [XmlType]
        public class OneDimensionScaleModel : StorableModel
        {
                /// <summary>
                ///         水平坐标
                /// </summary>
                [XmlAttribute]
                public int X { get; set; }

                /// <summary>
                ///         垂直坐标
                /// </summary>
                [XmlAttribute]
                public int Y { get; set; }

                /// <summary>
                ///         刻度值
                /// </summary>
                [XmlAttribute]
                public int Value { get; set; }
        }
}