using System.Xml.Serialization;
using Nutshell.Data.Models;

namespace Nutshell.Drawing.Shapes.Models
{
        /// <summary>
        ///         直线数据模型
        /// </summary>
        /// <value>The width.</value>
        [XmlType]
        public class LineModel : StorableModel
        {
                /// <summary>
                ///         水平坐标
                /// </summary>
                [XmlAttribute]
                public int X1 { get; set; }

                /// <summary>
                ///         垂直坐标
                /// </summary>
                [XmlAttribute]
                public int Y1 { get; set; }


                /// <summary>
                ///         水平坐标
                /// </summary>
                [XmlAttribute]
                public int X2 { get; set; }

                /// <summary>
                ///         垂直坐标
                /// </summary>
                [XmlAttribute]
                public int Y2 { get; set; }
        }
}