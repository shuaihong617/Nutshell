using System;
using Nutshell.Automation.OPC.Models;
using Nutshell.Data;

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

		object RemoteRead();

		void LocalWrite(object value);
	}
}