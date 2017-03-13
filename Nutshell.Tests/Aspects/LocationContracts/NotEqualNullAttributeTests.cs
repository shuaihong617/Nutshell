using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nutshell.Aspects.Locations.Contracts;
using System.Diagnostics;

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

                private void Test([MustNotEqualNull]object data)
                {
                        Trace.Write(data);
                }
        }
}