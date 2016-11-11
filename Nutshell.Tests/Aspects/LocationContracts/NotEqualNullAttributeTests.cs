using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nutshell.Aspects.Locations.Contracts;

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

                private void Test([NSNotEqualNull]object data)
                {
                        Trace.Write(data);
                }
        }
}
