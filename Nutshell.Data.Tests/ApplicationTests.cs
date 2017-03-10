using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nutshell.Data.Models;
using Nutshell.Data.Xml.Models;

namespace Nutshell.Data.Tests
{
        [TestClass]
        public class ApplicationTests
        {
                public string TestId = "测试应用程序标识";

                [TestMethod]
                [ExpectedException(typeof (ArgumentException))]
                public void ConstructorNullIdTest()
                {
                        var application = new Application(null);
                }

                [TestMethod]
                [ExpectedException(typeof (ArgumentException))]
                public void ConstructorEmptyIdTest()
                {
                        var application = new Application(string.Empty);
                }

                [TestMethod]
                public void ConstructorTest()
                {
                        var application = new Application(TestId);

                        Assert.AreEqual(application.Id, TestId);
                        Assert.AreEqual(application.GlobalId, TestId);
                }


                [TestMethod]
                [ExpectedException(typeof (ArgumentException))]
                public void LoadEmptyIdTest()
                {
                        var application = new Application(TestId);

                        IDataModel model = new XmlDataModel
                        {
                                Id = string.Empty
                        };

                        application.Load(model);
                }

                [TestMethod]
                public void LoadTest()
                {
                        var application = new Application(TestId);

                        var model = new XmlApplicationModel
                        {
                                Id = "其他"
                        };

                        application.Load(model);
                }
        }
}