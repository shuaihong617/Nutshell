using System;
using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Automation.OPC.Models;
using Nutshell.Data;
using Nutshell.Data.Models;
using Nutshell.Automation;
using Nutshell.Components;
using Nutshell.Log;
using OPCAutomation;

//重命名OPCDAAuto.dll中类名，禁止删除；
using NativeOpcServer = OPCAutomation.OPCServer;
using NativeOpcGroup = OPCAutomation.OPCGroup;
using NativeOpcItem = OPCAutomation.OPCItem;

namespace Nutshell.Automation.OPC
{
        public class OpcItem<T> : StorableObject, IOpcItem where T : struct
        {
                public OpcItem(IdentityObject parent, string id = "", string address = "",
                        TypeCode typeCode = TypeCode.Int32, ReadWriteMode readWriteMode = ReadWriteMode.None)
                        : base(parent, id)
                {
                        Address = address;
                        TypeCode = typeCode;
                        ReadWriteMode = readWriteMode;

                        _data = new ObservableNullableObject<T>(this, string.Empty);
                }

                #region 字段

                private NativeOpcItem _item;
	        private readonly ObservableNullableObject<T> _data;

                #endregion

                public string Address { get; private set; }

                public TypeCode TypeCode { get; private set; }

                /// <summary>
                ///         读写模式
                /// </summary>
                public ReadWriteMode ReadWriteMode { get; private set; }

                public int ClientHandle { get; private set; }

                public ObservableNullableObject<T> Data
                {
                        get
                        {
                                Trace.Assert(_data != null);
                                return _data;
                        }
                }

		[WillNotifyPropertyChanged]
                public DateTime UpdateTime { get; private set; }

	        /// <summary>
                ///         从数据模型加载数据
                /// </summary>
                /// <param name="model">数据模型</param>
                public void Load([MustNotEqualNull]IOpcItemModel model)
                {
                        base.Load(model);


                        Address = model.Address;
                        TypeCode = model.TypeCode;
                        ReadWriteMode = model.ReadWriteMode;
                }

	        /// <summary>
	        ///         保存数据到数据模型
	        /// </summary>
	        /// <param name="model">写入数据的目的数据模型，该数据模型不能为null</param>
	        public void Save(IOpcItemModel model)
	        {
		        throw new NotImplementedException();
	        }

	        public void Attach(string address, OPCAutomation.OPCGroup group)
                {
                        OpcServer.ClientHandleIndex++;
                        var name = address + "." + group.Name + "." + Address;
                        _item = group.OPCItems.AddItem(name, OpcServer.ClientHandleIndex);
                        ClientHandle = OpcServer.ClientHandleIndex;
                }

                public void RemoteRead()
                {
                        var server = Parent.Parent as OpcServer;
                        Debug.Assert(server != null);

                        try
                        {
                                if (server.RunMode != RunMode.Release)
                                {
                                        throw new InvalidOperationException(GlobalId + "只能在发布模式下读取远程数据");
                                }

                                object quality;
                                object timestamp;

                                object result;
                                _item.Read((short) OPCDataSource.OPCDevice, out result, out quality, out timestamp);

                                Trace.WriteLine(GlobalId + " : " + result);

                                LocalWrite(result);
                        }
                        catch (Exception e)
                        {
                                LocalWrite(null);
                                this.Error("读取失败, 错误原因：" + e);
                        }
                }

                public void LocalWrite(object obj)
                {
                        dynamic d = Data;

                        if (obj == null)
                        {
                                d.NullableValue =null;
                                return;
                        }

                        switch (TypeCode)
                        {
                                case TypeCode.Boolean:
                                        var bo = bool.Parse(obj.ToString());
                                        d.NullableValue =bo;
                                        break;

                                case TypeCode.Single:
                                        var si = float.Parse(obj.ToString());
                                        d.NullableValue =si;
                                        break;

                                case TypeCode.Byte:
                                        var by = byte.Parse(obj.ToString());
                                        d.NullableValue =by;
                                        break;

                                case TypeCode.Int16:
                                        var sh = short.Parse(obj.ToString());
                                        d.NullableValue = sh;
                                        break;

                                case TypeCode.UInt16:
                                        var i16 = ushort.Parse(obj.ToString());
                                        d.NullableValue =i16;
                                        break;

                                case TypeCode.Int32:
                                        var i32 = int.Parse(obj.ToString());
                                        d.NullableValue =i32;
                                        break;

                                default:
                                        throw new ArgumentOutOfRangeException();
                        }
                }

                public void RemoteWrite(T t)
                {
                        var server = Parent.Parent as OpcServer;
                        Debug.Assert(server != null);

                        try
                        {
                                if (server.RunMode != RunMode.Release)
                                {
                                        throw new InvalidOperationException(GlobalId + "只能在发布模式下写入远程数据");
                                }

                                if (!ReadWriteMode.HasFlag(ReadWriteMode.Write))
                                {
                                        throw new InvalidOperationException(GlobalId + "读写模式不具备远程数据写入权限");
                                }
                                _item.Write(t);
                        }
                        catch (InvalidOperationException e)
                        {
                                this.Error("写入失败, 错误原因：" + e);
                        }
                        catch (Exception e)
                        {
                                //其他原因写入失败，表示OPC通讯故障
                                LocalWrite(null);

                                this.Error("写入失败, 错误原因：" + e);
                        }
                }

                #region 事件

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                public event EventHandler<EventArgs> ReadFailed;

                /// <summary>
                ///         引发 <see cref="E:Opened" /> 事件.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnReadFailed(EventArgs e)
                {
                        e.Raise(this, ref ReadFailed);
                }

                #endregion
        }
}