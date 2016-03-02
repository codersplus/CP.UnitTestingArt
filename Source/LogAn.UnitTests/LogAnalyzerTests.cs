using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogAn;
using NUnit.Framework;
using NUnit;

namespace LogAnTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {

        private LogAnalyzer _logAnalyzer;

        [SetUp]
        public void SetUp()
        {
            _logAnalyzer = new LogAnalyzer();
        }

        [TearDown]
        public void TearDown()
        {
            _logAnalyzer = null;
        }

        [Test]
        public void IsValidLogFileName_BadExtension_ReturnsFalse()
        {
            const string fileName = "file.txt";

            var sut = _logAnalyzer.IsValidLogFileName(fileName);

            Assert.False(sut);
        }

        [Test]
        public void IsValidLogFileName_GoodExtension_ReturnsTrue()
        {
            const string fileName = "file.SLF";

            var sut = _logAnalyzer.IsValidLogFileName(fileName);

            Assert.True(sut);

        }

        [Test]
        public void IsValidLogFileName_GoodExtensionLowercase_ReturnsTrue()
        {
            var result = _logAnalyzer.IsValidLogFileName("filewithgoodextension.slf");

            Assert.True(result);
        }
        [Test]
        public void IsValidLogFileName_GoodExtensionUppercase_ReturnsTrue()
        {
            var result = _logAnalyzer.IsValidLogFileName("filewithgoodextension.SLF");

            Assert.True(result);
        }

        [Test]
        [Ignore("this is for ignore nunit attribute - just for test")]
        public void IsValidLogFileName_EmptyFileName_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => _logAnalyzer.IsValidLogFileName(string.Empty));

            var sut = Assert.Catch<Exception>(() => _logAnalyzer.IsValidLogFileName(string.Empty));

            StringAssert.Contains("file name has to be provided", sut.Message);

        }

        [Test]
        [Category("Fast Tests")]
        public void IsValidLogFileName_EmptyFileName_ThrowsFluent()
        {
            var ex = Assert.Throws<ArgumentException>(() => _logAnalyzer.IsValidLogFileName((string.Empty)));

            Assert.That(ex.Message,Does.Contain("file name has to be provided"));
           
        }

    }
}
