using System.Collections.Generic;
using System.Collections.ObjectModel;
using Nutshell.Automation.Opc.Models;
using Nutshell.Components;
using Nutshell.Data;

//重命名OpcDAAuto.dll中类名，禁止删除；
using NativeOpcServer = OPCAutomation.OPCServer;

namespace Nutshell.Automation.Opc
{
        /// <summary>
        ///         OpcServer
        /// </summary>
        /// <remarks>
        ///         处于运行模式下时：
        ///         1. 启动时不连接物理Opc服务器
        ///         2. 通过人工写入模拟Opc项值的变化
        ///         3. Opc项写入请求直接完成
        /// </remarks>
        public interface IOpcServer : IDispatchableComponent, IStorable<IOpcServerModel>
        {
                #region 属性

                string Address { get; }

                NativeOpcServer NativeOpcServer { get; }

                ReadOnlyCollection<IOpcGroup> OpcGroups { get; }

                ReadOnlyCollection<IOpcItem> OpcItems { get; }

		#endregion

	        void AddGroups(ReadOnlyCollection<IOpcGroup> groups);
	}
}