using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutshell.Automation.Opc.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nutshell.Automation.Opc;
using Nutshell.Data;

namespace Nutshell.Automation.Opc.Xml.Tests
{
        [TestClass()]
        public class XmlOpcServerStoragerTests
        {
                [TestMethod()]
                public void LoadTest()
                {
			Application application = new Application("Opc测试程序");
			OpcServer opcServer = new OpcServer(application);
                        XmlOpcServerStorager.Instance.Load(opcServer, "server.config");
                }

                [TestMethod()]
                public void SaveTest()
                {
                        Assert.Fail();
                }
        }
}
