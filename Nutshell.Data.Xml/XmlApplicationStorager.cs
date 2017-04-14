using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Data.Xml.Models;
using Nutshell.IO.Aspects.Locations.Contracts;
using Nutshell.Serializing.Xml;
using Nutshell.Storaging.Xml;

namespace Nutshell.Data.Xml
{
	public class XmlApplicationStorager
	{
		protected XmlApplicationStorager()
		{
		}

		#region 单例

		/// <summary>
		///         单例
		/// </summary>
		public static readonly XmlApplicationStorager Instance = new XmlApplicationStorager();

		#endregion 单例

		public void Load([MustNotEqualNull] Application application,
			[MustFileExist] string fileName)
		{
			var bytes = XmlStorager.Instance.Load(fileName);
			var model = XmlSerializer<XmlApplicationModel>.Instance.Deserialize(bytes);

			application.Load(model);
		}
	}
}