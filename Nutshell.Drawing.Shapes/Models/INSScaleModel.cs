using Nutshell.Data.Models;
using Nutshell.Storaging.Models;

namespace Nutshell.Drawing.Shapes.Models
{
        /// <summary>
        ///         刻度
        /// </summary>
        public interface IScaleModel : IDataModel
        {
                /// <summary>
                ///         刻度值
                /// </summary>
                int Value { get; set; }
        }
}