using System.Collections.Generic;
using System.Collections.ObjectModel;
using Nutshell.Automation.OPC.Models;
using Nutshell.Data;

namespace Nutshell.Automation.OPC
{
        /// <summary>
        ///         OPCServer
        /// </summary>
        /// <remarks>
        ///         处于调试模式下时：
        ///         1. 启动时不连接物理OPC服务器
        ///         2. 通过人工写入模拟OPC项值的变化
        ///         3. OPC项写入请求直接完成
        /// </remarks>
        public interface IOpcServer : IControllableDevice, IStorable<IOpcServerModel>
        {
                #region 属性

                string Name { get;  }

                string Address { get; }
                List<OpcGroup> Groups { get; }

                Dictionary<string, IOpcItem> Items { get; }

                ReadOnlyCollection<IOpcItem> DisplayItems { get; }

                #endregion
        }
}