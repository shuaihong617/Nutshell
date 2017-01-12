using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using Nutshell.Automation.OPC.Models;
using Nutshell.Data;
using Nutshell.Data.Models;
using OPCAutomation;

//重命名OPCDAAuto.dll中类名，禁止删除；
using NativeOpcServer = OPCAutomation.OPCServer;
using NativeOpcGroup = OPCAutomation.OPCGroup;

namespace Nutshell.Automation.OPC
{
        public interface IOpcGroup : IStorable<IOpcGroupModel>
        {

                #region 属性

                 string Address { get;  }

                 ObservableCollection<IOpcItem> OpcItems { get; }

                #endregion

                 void Load(IEnumerable<IOpcItemModel> itemModels);


	         void AddItem(IOpcItem item);

	         void Attach(NativeOpcServer server, string serverAddress);
        }
}