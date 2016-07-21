using System.Xml.Serialization;
using Nutshell.Data.Models;

namespace Nutshell.Drawing.Shapes.Models
{
        /// <summary>
        ///         线段数据模型
        /// </summary>
        [XmlType]
        public class SegmentModel : StorableModel
        {
                /// <summary>
                ///         端点1水平坐标
                /// </summary>
                [XmlAttribute]
                public int X1 { get; set; }

                /// <summary>
                ///         端点1垂直坐标
                /// </summary>
                [XmlAttribute]
                public int Y1 { get; set; }


                /// <summary>
                ///         端点2水平坐标
                /// </summary>
                [XmlAttribute]
                public int X2 { get; set; }

                /// <summary>
                ///         端点2垂直坐标
                /// </summary>
                [XmlAttribute]
                public int Y2 { get; set; }
        }
}