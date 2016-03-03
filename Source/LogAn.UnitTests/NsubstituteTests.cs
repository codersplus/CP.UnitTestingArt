using System;
using LogAn.Classes;
using LogAn.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace LogAnTests
{
    [TestFixture]
    public class NsubstituteTests
    {
        [Test]
        public void DelegateCallTest()
        {
            var func = Substitute.For<Func<string>>();
            func().Returns("hello");
            Assert.AreEqual("hello", func());
        }

        [Test]
        public void Write_WhenMocked_ShouldReceiveCallWithPassedParameters()
        {
            var codersBuffer = Substitute.For<ICodersBuffer<int>>();
            codersBuffer.Write(123);
            codersBuffer.Received().Write(123);
        }

        [Test]
        public void Write_WhenWhenWrtieString_ShouldWriteInTheBuffer()
        {
            var sut = new CodersBuffer<string>();
            sut.Write("hello");

            var result = sut.Read();
    
            Assert.AreEqual("hello", result.Peek());

        }

        [Test]
        public void Write_WhenCalled_ShouldAddValueInTheBuffer()
        {
            var codersBuffer = new CodersBuffer<string>();

            codersBuffer.Write("hello");
            codersBuffer.Write("world");

            var sut = codersBuffer.Read();

            Assert.AreEqual(2, sut.Count);
        }

        [Test]
        public void Write_WhenExceedCapacity_ShouldOverrideBufferValues()
        {

            // Arrange
            var codersBuffer = new CodersBuffer<string> {Capacity = 2};
            codersBuffer.Write("hello");
            codersBuffer.Write("generices");
            codersBuffer.Write("world");

            // Act
            var sut = codersBuffer.Read();

            // Assert
            Assert.AreEqual("generices", sut.ToArray()[0]);
            Assert.AreEqual("world", sut.ToArray()[1]);
        }

        [Test]
        public void Should_Execute_Command()
        {
            var command = Substitute.For<ICommand>();
            var sut = new NSubstituteCommand(command);

            sut.ExecuteCommand();
            command.Received().Execute();
        }

        [Test]
        public void ShouldNot_Execute_Command()
        {
            var command = Substitute.For<ICommand>();
            var sut = new NSubstituteCommand(command);

            sut.DonotExecuteCommand();
            command.DidNotReceive().Execute();
        }

        [Test]
        public void Claculator_WhenEventIsRaised_ShouldRaiseEvent()
        {

            var sut = Substitute.For<ICalculator>();
            var eventWasRaised = false;

            sut.PoweringUp += (sender, args) => { eventWasRaised = true; };
            sut.PoweringUp += Raise.Event();

            Assert.That(eventWasRaised);

        }

        [Test]
        public void Calculator_WhenAddMethodCalled_ReceiveCall()
        {
            var sut = Substitute.For<ICalculator>();
            
            sut.Add(1, 2);

            sut.Received().Add(1, 2);


        }

    }
}
