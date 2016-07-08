using System.Collections.Generic;
using System.Xml.Serialization;
using Nutshell.Data.Models;

namespace Nutshell.Drawing.Shapes.Models
{
        /// <summary>
        ///         标尺数据模型
        /// </summary>
        [XmlRoot]
        public class RulerModel : StorableModel
        {
                /// <summary>
                ///         方向
                /// </summary>
                /// <value>The width.</value>
                [XmlAttribute]
                public Direction Direction { get; set; }

                /// <summary>
                ///         单位
                /// </summary>
                /// <value>The width.</value>
                [XmlAttribute]
                public string Unit { get; set; }

                /// <summary>
                ///         刻度集合
                /// </summary>
                /// <value>The width.</value>
                [XmlArray]
                public List<ScaleModel> ScaleModels { get; set; }
        }
}