using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using LogAn;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;

namespace LogAnTests
{
    [TestFixture]
    public class SettingsTests
    {
        [Test]
        public void ScreenName_WhenCalled_ReturnsString()
        {
            var mockSettings = Substitute.For<ISetting>();
            mockSettings.ScreenName().Returns("Screen Name");

            var sut = Settings.Instacnce.ScreenName();

            Assert.AreEqual("Screen Name", mockSettings.ScreenName());

        }


        [Test]
        public void ScreenName_WhenCalled_ReturnsString2()
        {
            var mockSettings = Substitute.For<ISetting>();
            mockSettings.ScreenName().Returns("Screen Name2");

            var sut = Settings.Instacnce.ScreenName();

            Assert.AreEqual("Screen Name2", mockSettings.ScreenName());

        }

    }
}
