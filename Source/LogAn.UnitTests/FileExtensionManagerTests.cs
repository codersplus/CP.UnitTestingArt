using System;
using LogAn.Classes;
using LogAn.Interfaces;
using NUnit.Framework;

namespace LogAnTests
{
    [TestFixture]
    public class FileExtensionManagerTests
    {

        private IFileExtensionManager _fileExtensionManager;

        [SetUp]
        public void SetUp()
        {
            _fileExtensionManager = new FileExtensionManager();
        }

        [TearDown]
        public void TearDown()
        {
            _fileExtensionManager = null;
        }

        [Test]
        public void IsValid_BadExtension_ReturnsFalse()
        {
            const string fileName = "file.txt";

            var sut = _fileExtensionManager.IsValid(fileName);

            Assert.False(sut);
        }

        [Test]
        public void IsValid_GoodExtension_ReturnsTrue()
        {
            const string fileName = "file.SLF";

            var sut = _fileExtensionManager.IsValid(fileName);

            Assert.True(sut);

        }

        [Test]
        public void IsValid_GoodExtensionLowercase_ReturnsTrue()
        {
            var result = _fileExtensionManager.IsValid("filewithgoodextension.slf");

            Assert.True(result);
        }
        [Test]
        public void IsValid_GoodExtensionUppercase_ReturnsTrue()
        {
            var result = _fileExtensionManager.IsValid("filewithgoodextension.SLF");

            Assert.True(result);
        }

        [Test]
        public void IsValid_EmptyFileName_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => _fileExtensionManager.IsValid(string.Empty));

            var sut = Assert.Catch<Exception>(() => _fileExtensionManager.IsValid(string.Empty));

            StringAssert.Contains("file name has to be provided", sut.Message);

        }

        [Test]
        [Category("Fast Tests")]
        public void IsValid_EmptyFileName_ThrowsFluent()
        {
            var ex = Assert.Throws<ArgumentException>(() => _fileExtensionManager.IsValid(string.Empty));

            Assert.That(ex.Message,Does.Contain("file name has to be provided"));
        }

    }
}
