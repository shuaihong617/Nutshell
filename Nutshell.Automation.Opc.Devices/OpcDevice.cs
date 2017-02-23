using Nutshell.Aspects.Locations.Contracts;

namespace Nutshell.Automation.Opc.Devices
{
	/// <summary>
	///         基于Opc通讯的元器件
	/// </summary>
	public abstract class OpcDevice<T> : IndependentDevice where T : struct
	{
		protected OpcDevice(string id, [MustNotEqualNull] OpcItem opcItem)
			: base( id)
		{
			OpcPoint = new OpcNullable<T>(this, "Opc点", opcItem);
		}

		/// <summary>
		///         数据
		/// </summary>
		public OpcNullable<T> OpcPoint { get; private set; }
	}
}
