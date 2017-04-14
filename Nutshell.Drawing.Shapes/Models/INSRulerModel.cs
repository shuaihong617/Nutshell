using Nutshell.Data.Models;
using Nutshell.Storaging.Models;

namespace Nutshell.Drawing.Shapes.Models
{
        /// <summary>
        ///         标尺数据模型
        /// </summary>
        public interface IRulerModel : IDataModel
        {
                /// <summary>
                ///         方向
                /// </summary>
                /// <value>The width.</value>
                Direction Direction { get; set; }

                /// <summary>
                ///         单位
                /// </summary>
                /// <value>The width.</value>
                string Unit { get; set; }
        }
}