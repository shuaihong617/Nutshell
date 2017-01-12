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

                        Trace.WriteLine("驱动版本：" +  runtime.RuntimeInformation.DriverVersion);

                        foreach (var name in runtime.OpcServerNames)
                        {
                                Trace.WriteLine("OPC服务器：" + name);
                        }

                        Assert.AreNotEqual(runtime.OpcServerNames.Count , 0);
                }
        }
}