using LogAn.Classes;
using NSubstitute;
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

            Settings.Instacnce.ScreenName();

            Assert.AreEqual("Screen Name", mockSettings.ScreenName());

        }


        [Test]
        public void ScreenName_WhenCalled_ReturnsString2()
        {
            var mockSettings = Substitute.For<ISetting>();
            mockSettings.ScreenName().Returns("Screen Name2");

            Settings.Instacnce.ScreenName();

            Assert.AreEqual("Screen Name2", mockSettings.ScreenName());

        }

    }
}
