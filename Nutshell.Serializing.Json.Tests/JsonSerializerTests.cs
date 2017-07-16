using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nutshell.Serializing.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutshell.Components;
using Nutshell.Components.Models;

namespace Nutshell.Serializing.Json.Tests
{
        [TestClass()]
        public class JsonSerializerTests
        {
                [TestMethod()]
                public void SerializeTest()
                {
                        AppInstanceModel model = new AppInstanceModel
                        {
                                Id = "AppInstanceModel.Id",
                                Company = "AppInstanceModel.Compan",
                                Name = "AppInstanceModel.Name",
                                Title = "AppInstanceModel.Title",
                                Version = "AppInstanceModel.Version",
                                CopyRight = "AppInstanceModel.CopyRight"
                        };

                        var bytes = JsonSerializer<AppInstanceModel>.Instance.Serialize(model);

                        var str = Encoding.UTF8.GetString(bytes);
                        using (var stream = new StreamWriter("AppInstanceModel.config"))
                        {
                                stream.Write(str);
                        }
                }

                [TestMethod()]
                public void DeserializeTest()
                {
                        Assert.Fail();
                }
        }
}