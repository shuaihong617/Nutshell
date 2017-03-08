using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nutshell.Automation.Opc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutshell.Automation.Opc.Tests
{
        [TestClass()]
        public class OpcRuntimeTests
        {
                [TestMethod()]
                public void StartTest()
                {
                        var runtime = OpcRuntime.Instance;
                        runtime.Start();


                        foreach (var installedOpcServer in runtime.InstalledOpcServers)
                        {
                                Trace.WriteLine("Opc服务器：" + installedOpcServer);
                        }

                        Assert.AreNotEqual(runtime.InstalledOpcServers.Count , 0);
                }
        }
}