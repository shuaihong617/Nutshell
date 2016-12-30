using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using Nutshell.Automation.OPC.Models;
using Nutshell.Data;
using Nutshell.Data.Models;
using OPCAutomation;

namespace Nutshell.Automation.OPC
{
        public class OpcGroup : IdentityObject
        {
                public OpcGroup(IdentityObject parent, string id = "", string address="")
                        : base(parent, id)
                {
                        Address = address;
                        Items = new List<IOpcItem>();
                }

                #region 字段

                

                private readonly Dictionary<int, IOpcItem> _subscribeItems = new Dictionary<int, IOpcItem>();

                private OPCAutomation.OPCGroup _group;

                #endregion

                #region 属性

                public string Address { get; private set; }

                public List<IOpcItem> Items { get; private set; }

                #endregion


                public override void Load(IIdentityModel model)
                {
                        base.Load(model);


                        var groupModel = model as OPCGroupModel;
                        Trace.Assert(groupModel != null);

                        Address = groupModel.Address;

                        //var groupModels = groupModel.OPCItemModels;

                        //foreach (var itemModel in groupModels)
                        //{
                        //        //var item = new OPCItem(this);
                        //        //item.Load(itemModel);
                        //        //AddItem(item);
                        //}
                }

                public void AddItem(IOpcItem item)
                {
                        Items.Add(item);
                }

                public void Attach(OPCAutomation.OPCServer server, string serverAddress)
                {
                        
                                        _group = server.OPCGroups.Add(Address);
                                        _group.IsActive = true;
                                        _group.OPCItems.DefaultIsActive = true;
                                        _group.IsSubscribed = true;
                                        _group.UpdateRate = 100;
                                               

                        foreach (var item in Items)
                        {
                                dynamic d = item;
                                d.Attach(serverAddress, _group);
                                _subscribeItems.Add(d.ClientHandle, d);
                        }

                        _group.DataChange += DataChange;
                }

                private void DataChange(int transactionId, int numItems, ref Array clientHandles, ref Array itemValues,
                        ref Array qualities, ref Array timeStamps)
                {
                        if (qualities == null)
                        {
                                throw new ArgumentNullException("qualities");
                        }

                        for (var i = 1; i < numItems + 1; i++)
                        {
                                var handle = int.Parse(clientHandles.GetValue(i).ToString());
                                var quality = qualities.GetValue(i).ToString() == "192"; //192 == good

                                var item = _subscribeItems[handle];
                                var value = quality ? itemValues.GetValue(i) : null;
                                item.LocalWrite(value);
                        }
                }
        }
}