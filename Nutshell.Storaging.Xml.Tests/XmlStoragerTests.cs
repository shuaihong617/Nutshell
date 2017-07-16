using Nutshell.Storaging.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Nutshell.Components;
using Nutshell.Components.Models;

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
                [ExpectedException(typeof(ArgumentException))]
                public void LoadNotExistTest()
                {
                        var bytes = XmlStorager.Instance.Load(@"c:\2.config");
                        Trace.WriteLine(Encoding.UTF8.GetString(bytes));
                }

                [TestMethod()]
                public void LoadTest1()
                {
                        //AppInstanceModel model = new AppInstanceModel
                        //{
                        //        Id = "AppInstanceModel.Id",
                        //        Company = "AppInstanceModel.Compan",
                        //        Name = "AppInstanceModel.Name",
                        //        Title = "AppInstanceModel.Title",
                        //        Version = "AppInstanceModel.Version",
                        //        CopyRight = "AppInstanceModel.CopyRight"
                        //};

                        var app = XmlStorager<AppInstance,AppInstanceModel>.Instance.Load("AppInstanceTest.config");

                        Trace.WriteLine(app.Id);
                }

                
        }
}