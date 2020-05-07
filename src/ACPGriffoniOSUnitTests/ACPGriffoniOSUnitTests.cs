
using System;
using NUnit.Framework;
using Com.Adobe.Marketing.Mobile;

namespace ACPGriffoniOSUnitTests
{
    [TestFixture]
    public class ACPGriffoniOSUnitTests
    {
        // ACPGriffon tests
        [Test]
        public void GetACPGriffonExtensionVersion_Returns_CorrectVersion()
        {
            // verify
            Assert.True(ACPGriffon.ExtensionVersion == "1.1.0");
        }
    }
}