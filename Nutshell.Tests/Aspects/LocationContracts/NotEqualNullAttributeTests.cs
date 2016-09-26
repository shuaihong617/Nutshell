using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nutshell.Aspects.LocationContracts;

namespace Nutshell.Tests.Aspects.LocationContracts
{
        [TestClass()]
        public class NotEqualNullAttributeTests
        {
                [TestMethod()]
                public void ValidateValueTest()
                {
                        Test(null);
                }

                private void Test([NotEqualNull]object data)
                {
                        Trace.Write(data);
                }
        }
}
