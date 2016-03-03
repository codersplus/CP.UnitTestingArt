using LogAn.Classes;
using LogAn.Interfaces;
using NUnit.Framework;
using NSubstitute;

namespace LogAnTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidFileName_BadFileExtension_ReturnsFalse()
        {
            var mockFileExtensionManager = Substitute.For<IFileExtensionManager>();
            mockFileExtensionManager.IsValid("abc.txt").Returns(false);
            var fileExtensionManager = new LogAnalyzer(mockFileExtensionManager);

            var sut = fileExtensionManager.IsValidLogFileName("abc.txt");

            Assert.False(sut);
        }

        [Test]
        public void IsValidFileName_GoodFileExtension_ReturnsTrue()
        {
            var mockFileExtensionManager = Substitute.For<IFileExtensionManager>();
            mockFileExtensionManager.IsValid("abc.slf").Returns(true);
            var fileExtensionManager = new LogAnalyzer(mockFileExtensionManager);

            var sut = fileExtensionManager.IsValidLogFileName("abc.slf");

            Assert.True(sut);
        }


    }
}
