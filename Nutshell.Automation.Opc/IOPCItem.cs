using System;
using Nutshell.Automation.OPC.Models;
using Nutshell.Data;

//重命名OPCDAAuto.dll中类名，禁止删除；
using NativeOpcGroup = OPCAutomation.OPCGroup;
using NativeOpcItem = OPCAutomation.OPCItem;

namespace Nutshell.Automation.OPC
{
	public interface IOpcItem : IStorable<IOpcItemModel>
	{
		string Address { get; }

		TypeCode TypeCode { get; }

		/// <summary>
		///         读写模式
		/// </summary>
		ReadWriteMode ReadWriteMode { get; }

		object Value { get;}

		DateTime UpdateTime { get;}

		int ClientHandle { get; }

	        void Attach(string serverAddress, NativeOpcGroup group);


                object RemoteRead();

		void LocalWrite(object value);
	}
}