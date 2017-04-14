using Nutshell.Data.Models;
using Nutshell.Storaging.Models;

namespace Nutshell.Drawing.Shapes.Models
{
        /// <summary>
        ///         线段数据模型
        /// </summary>
        public interface ISegmentModel : IDataModel
        {
                /// <summary>
                ///         端点1水平坐标
                /// </summary>
                int X1 { get; set; }

                /// <summary>
                ///         端点1垂直坐标
                /// </summary>
                int Y1 { get; set; }

                /// <summary>
                ///         端点2水平坐标
                /// </summary>
                int X2 { get; set; }

                /// <summary>
                ///         端点2垂直坐标
                /// </summary>
                int Y2 { get; set; }
        }
}