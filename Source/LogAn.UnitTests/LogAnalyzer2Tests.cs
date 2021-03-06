﻿using System;
using LogAn.Classes;
using LogAn.Interfaces;
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
            mockWebService.LogError("Filename too short:abc.txt");

            var logAnalyzer2 = new LogAnalyzer2(mockWebService, mockEmailService);
            logAnalyzer2.Analyze("abc.txt");

            mockWebService.Received().LogError("Filename too short:abc.txt");
        }
        [Test]
        public void Analyze_ToShortNameWhenRaiseException_SendAnEmail()
        {
            var mockWebService = Substitute.For<IWebService>();
            var mockEmailService = Substitute.For<IEmailService>();

            mockWebService.When(x=>x.LogError(string.Empty))
                          .Do(x => { throw  new Exception();});

            mockEmailService.SendEmail("to", "subject", "body");
            var logAnalyzer2 = new LogAnalyzer2(mockWebService, mockEmailService);
            logAnalyzer2.Analyze("abc.txt");

            mockEmailService.Received().SendEmail("to", "subject", "body");
        }

    }
}
