using System;
using Nutshell.Automation.OPC.Models;
using Nutshell.Data;

namespace Nutshell.Automation.OPC
{
	public interface IOpcItem : IIdentityObject, IStorable<IOpcItemModel>
	{
		string Address { get; }

		TypeCode TypeCode { get; }

		/// <summary>
		///         读写模式
		/// </summary>
		ReadWriteMode ReadWriteMode { get; }

		int ClientHandle { get; }

		void RemoteRead();

		void LocalWrite(object value);
	}
}