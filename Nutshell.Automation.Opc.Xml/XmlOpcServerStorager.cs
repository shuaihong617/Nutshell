using System.Collections.Generic;
using System.IO;
using System.Text;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Opc.Xml.Models;
using Nutshell.Automation.Opc;
using Nutshell.Automation.Xml;
using Nutshell.Components.Xml;
using Nutshell.IO.Aspects.Locations.Contracts;
using Nutshell.Serializing.Xml;
using Nutshell.Storaging.Xml;

namespace Nutshell.Automation.Opc.Xml
{
        public class XmlOpcServerStorager:XmlDispatchableDeviceStorager
        {
                protected XmlOpcServerStorager()
                {

                }

                #region 单例

                /// <summary>
                ///         单例
                /// </summary>
                public static readonly XmlOpcServerStorager Instance = new XmlOpcServerStorager();

                #endregion

                public void Load([MustNotEqualNull]OpcServer opcServer,
                        [MustFileExist]string fileName)
                {
                        var bytes = XmlStorager.Instance.Load(fileName);
                        var model= XmlSerializer<XmlOpcServerModel>.Instance.Deserialize(bytes);

                        base.Load(opcServer, model);

			opcServer.Load(model);

			var groups = new List<OpcGroup>(model.XmlOpcGroupModels.Count);
			foreach (var groupModel in model.XmlOpcGroupModels)
			{
				var group = new OpcGroup();
				XmlOpcGroupStorager.Instance.Load(group, groupModel);

				groups.Add(group);
			}
			opcServer.OpcGroups = groups.AsReadOnly();
		}

                public void Save(OpcServer opcServer, string fileName)
                {
                        //var model = new XmlOpcServerModel();
                        //Save(opcServer, model);
                        //var bytes = XmlSerializer<XmlOpcServerModel>.Instance.Serialize(model);
                        //var stream = new StreamWriter(fileName, false, Encoding.UTF8);
                        //stream.Write(bytes);
                        //stream.Close();

                }

                
        }
}
