using System;
using System.Collections.Generic;
using System.Diagnostics;
using Nutshell.Automation.OPC.Models;
using Nutshell.Components;
using Nutshell.Data;
using Nutshell.Data.Models;
using Nutshell.Hardware;
using Nutshell.Log;

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
        public class OpcServer : Device
        {
                public OpcServer(IdentityObject parent, string id = "", string name = "", string address = "")
                        : base(parent, id)
                {
                        Name = name;
                        Address = address;

                        Groups = new List<OPCGroup>();
                        Items = new Dictionary<string, IOPCItem>();
                }

                #region 字段

                public static int ClientHandleIndex;

                private OPCAutomation.OPCServer _server;

                #endregion

                #region 属性

                public string Name { get; private set; }

                public string Address { get; private set; }


                public List<OPCGroup> Groups { get; private set; }

                public Dictionary<string, IOPCItem> Items { get; private set; }

                #endregion

                public override void Load(IIdentityModel model)
                {
                        base.Load(model);

                        var serverModel = model as OPCServerModel;
                        Trace.Assert(serverModel != null);

                        Name = serverModel.Name;
                        Address = serverModel.Address;

                        var groupModels = serverModel.OPCGroupModels;

                        foreach (var groupModel in groupModels)
                        {
                                var group = new OPCGroup(this);
                                group.Load(groupModel);

                                AddGroup(group);
                        }
                }

                protected void AddGroup(OPCGroup group)
                {
                        Groups.Add(group);

                        foreach (var item in group.Items)
                        {
                                Items.Add(item.Id, item);

                                if (DebugMode == DebugMode.Debug)
                                {
                                        //item.Reset();
                                }
                        }
                }


                protected override bool OpenCore()
                {
                        if (DebugMode == DebugMode.Debug)
                        {
                                return true;
                        }

                        try
                        {
                                _server = new OPCAutomation.OPCServer();
                                _server.Connect(Name);
                        }
                        catch (Exception e)
                        {
                                this.Error(Id + " " + Name + "  连接失败," + e);
                                return false;
                        }

                        this.InfoSuccess("连接" + Name);

                        return true;
                }

                protected override bool CloseCore()
                {
                        if (DebugMode == DebugMode.Debug)
                        {
                                return true;
                        }
                        _server.Disconnect();
                        return true;
                }

                public void Attach()
                {
                        if (DebugMode == DebugMode.Debug)
                        {
                                return;
                        }

                        foreach (var group in Groups)
                        {
                                group.Attach(_server, Address);
                        }
                }
        }
}