using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using Nutshell.Automation.Opc.Models;
using Nutshell.Data;
using Nutshell.Data.Models;
using OPCAutomation;

//重命名OpcDAAuto.dll中类名，禁止删除；
using NativeOpcServer = OPCAutomation.OPCServer;

namespace Nutshell.Automation.Opc
{
        public interface IOpcGroup : IStorable<IOpcGroupModel>
        {

                #region 属性

                 string Address { get;  }

                 ReadOnlyCollection<IOpcItem> OpcItems { get; }

                #endregion

                 void Load(IEnumerable<IOpcItemModel> itemModels);

	         void Attach(NativeOpcServer server, string serverAddress);
        }
}