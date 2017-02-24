using System;
using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Automation.Opc.Models;
using Nutshell.Components;
using Nutshell.Data;
using Nutshell.Extensions;
using Nutshell.Logging.KernelLogging;
using OPCAutomation;
//重命名OpcDAAuto.dll中类名，禁止删除；
using NativeOpcServer = OPCAutomation.OPCServer;
using NativeOpcGroup = OPCAutomation.OPCGroup;
using NativeOpcItem = OPCAutomation.OPCItem;

namespace Nutshell.Automation.Opc
{
	public class OpcItem : StorableObject, IOpcItem
	{
		public OpcItem(string id = "", string address = "",
			TypeCode typeCode = TypeCode.Int32, ReadWriteMode readWriteMode = ReadWriteMode.None)
			: base( id)
		{
			Address = address;
			TypeCode = typeCode;
			ReadWriteMode = readWriteMode;

			Value = null;
			UpdateTime = DateTime.MinValue;
		}

		#region 字段

		private static int _clientHandleIndex;

		#endregion

		#region 字段

		private NativeOpcItem _item;

		#endregion

		public string Address { get; private set; }

		public TypeCode TypeCode { get; private set; }

		/// <summary>
		///         读写模式
		/// </summary>
		public ReadWriteMode ReadWriteMode { get; private set; }

		public int ClientHandle { get; private set; }

		[NotifyPropertyValueChanged]
		public object Value { get; private set; }

		[NotifyPropertyValueChanged]
		public DateTime UpdateTime { get; private set; }

		/// <summary>
		///         从数据模型加载数据
		/// </summary>
		/// <param name="model">数据模型</param>
		public void Load([MustNotEqualNull] IOpcItemModel model)
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

		public void Attach(string serverAddress, NativeOpcGroup group)
		{
			_clientHandleIndex++;
			var name = serverAddress + "." + group.Name + "." + Address;
			try
			{
				ClientHandle = _clientHandleIndex;
				_item = group.OPCItems.AddItem(name, _clientHandleIndex);
			}
			catch (Exception ex)
			{
				this.Fatal(new InvalidOperationException("创建OpcItem失败，错误原因"+ ex));
			}
		}

		public object RemoteRead()
		{
			var server = Parent.Parent as OpcServer;
			Trace.Assert(server != null);

			object result = null;
			try
			{
				if (server.RunMode != RunMode.Release)
				{
					throw new InvalidOperationException(GlobalId + "只能在发布模式下读取远程数据");
				}

				object quality;
				object timestamp;

				_item?.Read((short)OPCDataSource.OPCDevice, out result, out quality, out timestamp);

				Trace.WriteLine(GlobalId + " : " + result);
				LocalWrite(result);

			}
			catch (Exception e)
			{
				result = null;
				LocalWrite(null);
				this.Error("读取失败, 错误原因：" + e);
			}
			return result;
		}

		public void LocalWrite(object value)
		{
			Value = value;
			if (Value != null)
			{
				UpdateTime = DateTime.Now;
				OnReadSuccessed(new ValueEventArgs<object>(Value));
			}
			else
			{
				OnReadFailed(EventArgs.Empty);
			}
		}

		public void RemoteWrite(object value)
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

				_item?.Write(value);
			}
			catch (InvalidOperationException e)
			{
				this.Error("写入失败, 错误原因：" + e);
			}
			catch (Exception e)
			{
				//其他原因写入失败，表示Opc通讯故障
				LocalWrite(null);

				this.Error("写入失败, 错误原因：" + e);
			}
		}

		#region 事件

		/// <summary>
		///         Occurs when [opened].
		/// </summary>
		public event EventHandler<ValueEventArgs<object>> ReadSuccessed;

		/// <summary>
		///         引发 <see cref="E:Opened" /> 事件.
		/// </summary>
		/// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
		protected virtual void OnReadSuccessed(ValueEventArgs<object> e)
		{
			e.Raise(this, ref ReadSuccessed);
		}

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