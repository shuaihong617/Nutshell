using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Opc.Xml.Models;
using Nutshell.Automation.Opc;

namespace Nutshell.Automation.Opc.Xml
{
        public class XmlOpcGroupStorager
        {
                protected XmlOpcGroupStorager()
                {
                }

                #region 单例

                /// <summary>
                ///         单例
                /// </summary>
                public static readonly XmlOpcGroupStorager Instance = new XmlOpcGroupStorager();

                #endregion

                public void Load([MustNotEqualNull] OpcGroup opcGroup,
                        [MustNotEqualNull] XmlOpcGroupModel model)
                {
                        opcGroup.Load(model);
			opcGroup.Load(model.XmlOpcItemModels);                        
                }

                public void Save([MustNotEqualNull] OpcGroup opcGroup,
                        [MustNotEqualNull] XmlOpcGroupModel model)
                {
                }
        }
}
