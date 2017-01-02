using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.OPC.Models;

//重命名OPCDAAuto.dll中类名，禁止删除；
using NativeOpcServer = OPCAutomation.OPCServer; 

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
        public class OpcServer : ControllableDevice, IOpcServer
        {
                public OpcServer([MustNotEqualNull]IdentityObject parent, 
                        string id = "", string name = "", string address = "")
                        : base(parent, id)
                {
                        Name = name;
                        Address = address;

                        Groups = new List<OpcGroup>();
                        Items = new Dictionary<string, IOpcItem>();
                }

                #region 字段

                public static int ClientHandleIndex;

                private NativeOpcServer _server;

                #endregion

                #region 属性

                public string Name { get; private set; }

                public string Address { get; private set; }


                public List<OpcGroup> Groups { get; }

                public Dictionary<string, IOpcItem> Items { get; }
                public ReadOnlyCollection<IOpcItem> DisplayItems { get; }

                #endregion

                public void Load([MustNotEqualNull] IOpcServerModel model)
                {
                        base.Load(model);

                        Name = model.Name;
                        Address = model.Address;

                        //var groupModels = serverModel.OPCGroupModels;

                        //foreach (var groupModel in groupModels)
                        //{
                        //        var group = new OpcGroup(this);
                        //        group.Load(groupModel);

                        //        AddGroup(group);
                        //}
                }

                public void Save(IOpcServerModel model)
                {
                        throw new NotImplementedException();
                }

                protected void AddGroup(OpcGroup group)
                {
                        Groups.Add(group);

                        foreach (var item in group.Items)
                        {
                                Items.Add(item.Id, item);

                                //if (RunMode == RunMode.Debug)
                                //{
                                //        //item.Reset();
                                //}
                        }
                }


                //protected override bool OpenCore()
                //{
                //        //if (RunMode == RunMode.Debug)
                //        //{
                //        //        return true;
                //        //}

                //        //try
                //        //{
                //        //        _server = new OPCAutomation.OPCServer();
                //        //        _server.Connect(Name);
                //        //}
                //        //catch (Exception e)
                //        //{
                //        //        this.Error(Id + " " + Name + "  连接失败," + e);
                //        //        return false;
                //        //}

                //        //this.InfoSuccess("连接" + Name);

                //        return true;
                //}

                //protected override bool CloseCore()
                //{
                //        //if (RunMode == RunMode.Debug)
                //        //{
                //        //        return true;
                //        //}
                //        //_server.Disconnect();
                //        return true;
                //}

                public void Attach()
                {
                        //if (RunMode == RunMode.Debug)
                        //{
                        //        return;
                        //}

                        foreach (var group in Groups)
                        {
                                group.Attach(_server, Address);
                        }
                }
        }
}