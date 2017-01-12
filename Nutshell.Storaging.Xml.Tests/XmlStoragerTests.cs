using System;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nutshell.Storaging.Xml.Tests
{
        [TestClass]
        public class XmlStoragerTests
        {
                [TestMethod]
                public void LoadTest()
                {
                        var bytes = XmlStorager.Instance.Load(@"c:\1.config");
                        Trace.WriteLine(Encoding.UTF8.GetString(bytes));
                }

                [TestMethod]
                [ExpectedException(typeof (ArgumentException))]
                public void LoadNotExistTest()
                {
                        var bytes = XmlStorager.Instance.Load(@"c:\2.config");
                        Trace.WriteLine(Encoding.UTF8.GetString(bytes));
                }
        }
}
