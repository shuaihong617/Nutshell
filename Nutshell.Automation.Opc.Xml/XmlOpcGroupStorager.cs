using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Opc.Xml.Models;

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

                #endregion 单例

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