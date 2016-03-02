using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogAn;
using NUnit.Framework;
using NSubstitute;

namespace LogAnTests
{
    [TestFixture]
    public class LogAnalyzer2Tests
    {

        [Test]
        public void Analyze_TooShortName_CallesWebService()
        {
            var mockWebService = Substitute.For<IWebService>();
            var mockEmailService = Substitute.For<IEmailService>();

            var logAnalyzer2 = new LogAnalyzer2(mockWebService, mockEmailService);

            logAnalyzer2.Analyze("abc.txt");

            mockWebService.Received().LogError("Filename too short:abc.txt");
        }
        [Test]
        public void Analyze_ToShortNameWhenRaiseException_SendAnEmail()
        {
            var mockWebService = Substitute.For<IWebService>();
            mockWebService.When(x=>x.LogError(string.Empty))
                          .Do(x => { throw  new Exception();});
            var mockEmailService = Substitute.For<IEmailService>();

            mockEmailService.SendEmail("to", "subject", "body");
            var logAnalyzer2 = new LogAnalyzer2(mockWebService, mockEmailService);
            logAnalyzer2.Analyze("abc.txt");

            mockEmailService.Received().SendEmail("to", "subject", "body");
        }

    }
}
