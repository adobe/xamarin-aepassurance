using System;
using NUnit.Framework;
using Com.Adobe.Marketing.Mobile;

namespace ACPGriffonAndroidUnitTests
{
    [TestFixture]
    public class ACPGriffonAndroidUnitTests
    {
        // ACPGriffon tests
        [Test]
        public void GetACPGriffonExtensionVersion_Returns_CorrectVersion()
        {
            // verify
            Assert.True(ACPGriffon.ExtensionVersion() == "1.1.5");
        }
    }
}
