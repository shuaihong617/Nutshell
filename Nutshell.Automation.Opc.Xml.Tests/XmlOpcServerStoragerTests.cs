using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nutshell.Data;

namespace Nutshell.Automation.Opc.Xml.Tests
{
        [TestClass]
        public class XmlOpcServerStoragerTests
        {
                [TestMethod]
                public void LoadTest()
                {
                        var application = new Application("Opc测试程序");

                        var opcServer = new OpcServer();
                        opcServer.Parent = application;

                        XmlOpcServerStorager.Instance.Load(opcServer, "server.config");
                }

                [TestMethod]
                public void SaveTest()
                {
                        Assert.Fail();
                }
        }
}