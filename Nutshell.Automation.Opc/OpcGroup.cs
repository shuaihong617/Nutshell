﻿using Nutshell.Automation.Opc.Models;
using Nutshell.Data;
using Nutshell.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Nutshell.Storaging;
using NativeOpcGroup = OPCAutomation.OPCGroup;

//重命名OPCDAAuto.dll中类名，禁止删除；
using NativeOpcServer = OPCAutomation.OPCServer;

namespace Nutshell.Automation.Opc
{
        public class OpcGroup : StorableObject, IStorable<OpcGroupModel>
        {
                public OpcGroup(string id = "", string address = "", ReadOnlyCollection<OpcItem> opcItems = null)
                        : base(id)
                {
                        Address = address;

                        OpcItems = opcItems ?? new ReadOnlyCollection<OpcItem>(new List<OpcItem>());
                }

                #region 字段

                private readonly Dictionary<int, OpcItem> _opcItemsLookupTable = new Dictionary<int, OpcItem>();

                private NativeOpcGroup _group;

                #endregion 字段

                #region 属性

                public string Address { get; private set; }

                public ReadOnlyCollection<OpcItem> OpcItems { get; private set; }

                #endregion 属性

                public void Load(OpcGroupModel model)
                {
                        base.Load(model);

                        Address = model.Address;

			var items = new List<OpcItem>();
			foreach (var itemModel in model.OpcItemModels)
			{
			        var item = new OpcItem();
			        item.Parent = this;
				item.Load(itemModel);
				items.Add(item);
			}
			OpcItems = items.ToReadOnlyCollection();
		}

                /// <summary>
                ///         保存数据到数据模型
                /// </summary>
                /// <param name="model">写入数据的目的数据模型，该数据模型不能为空引用.</param>
                public void Save(OpcGroupModel model)
                {
                        throw new NotImplementedException();
                }

                public void Attach(NativeOpcServer server, string serverAddress)
                {
                        try
                        {
                                _group = server.OPCGroups.Add(Address);
                        }
                        catch (Exception ex)
                        {
                                _group = null;
                                this.Error($"{Id}连接失败,错误原因{ex}");
                                throw;
                        }

                        this.InfoSuccess($"连接");

                        if (_group == null)
                        {
                                return;
                        }

                        _group.IsActive = true;
                        _group.OPCItems.DefaultIsActive = true;
                        _group.IsSubscribed = true;
                        _group.UpdateRate = 100;

                        foreach (var item in OpcItems)
                        {
                                item.Attach(serverAddress, _group);
                                _opcItemsLookupTable.Add(item.ClientHandle, item);
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

                                var item = _opcItemsLookupTable[handle];
                                var value = quality ? itemValues.GetValue(i) : null;
                                item.LocalWrite(value);
                        }
                }
        }
}