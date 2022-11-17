using System;
using Microwave.Classes.Boundary;
using Microwave.Classes.Interfaces;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;

namespace Microwave.Test.Unit
{
    [TestFixture]
    public class PowerTubeTest
    {
        private PowerTube uut;
        private IOutput output;

        [SetUp]
        public void Setup()
        {
            output = Substitute.For<IOutput>();
            uut = new PowerTube(output,1000);
        }

        [TestCase(1)]
        [TestCase(50)]
        [TestCase(100)]
        [TestCase(999)]
        [TestCase(1000)]
        public void TurnOn_WasOffCorrectPower_CorrectOutput1000Maximumpower(int power)
        {
            uut.TurnOn(power);
            output.Received().OutputLine(Arg.Is<string>(str => str.Contains($"{power}")));
        }

        [TestCase(-5)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1001)]
        [TestCase(1050)]
        public void TurnOn_WasOffOutOfRangePower_ThrowsException1000Maximumpower(int power)
        {
            Assert.Throws<System.ArgumentOutOfRangeException>(() => uut.TurnOn(power));
        }

        [TestCase(1)]
        [TestCase(50)]
        [TestCase(100)]
        [TestCase(199)]
        [TestCase(200)]

        public void TurnOn_WasOffCorrect_CorrectOutput200Maximumpower(int power)
        {
            var maximumpower200 = new PowerTube(output, 200);
            maximumpower200.TurnOn(power);
            output.Received().OutputLine(Arg.Is<string>(str => str.Contains($"{power}")));
        }

        [TestCase(-5)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(201)]
        [TestCase(250)]

        public void TurnOn_WasOffOutRangePower_ThrowsExeption200Maximumpower(int power)
        {
            var maximumpowe200 = new PowerTube(output, 200);
            Assert.Throws<System.ArgumentOutOfRangeException>(() => maximumpowe200.TurnOn(power));
        }

        [TestCase(1)]
        [TestCase(50)]
        [TestCase(100)]
        [TestCase(499)]
        [TestCase(500)]
        public void TurnOn_WasOffCorrectPower_CorrectOutput500Maximumpower(int power)
        {
            var maximumpower500 = new PowerTube(output, 500); // Testing other power tube configuration maximum power instead of hard coded value in setup
            maximumpower500.TurnOn(power);
            output.Received().OutputLine(Arg.Is<string>(str => str.Contains($"{power}")));
        }

        [TestCase(-5)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(501)]
        [TestCase(550)]
        public void TurnOn_WasOffOutOfRangePower_ThrowsException500Maximumpower(int power)
        {
            var maximumpower500 = new PowerTube(output, 500);
            Assert.Throws<System.ArgumentOutOfRangeException>(() => maximumpower500.TurnOn(power));
        }

        [TestCase(1)]
        [TestCase(50)]
        [TestCase(100)]
        [TestCase(799)]
        [TestCase(800)]
        public void TurnOn_WasOffCorrectPower_CorrectOutput800Maximumpower(int power)
        {
            var maximumpower800 = new PowerTube(output, 800); // Testing other power tube configuration maximum power instead of hard coded value in setup uut
            maximumpower800.TurnOn(power);
            output.Received().OutputLine(Arg.Is<string>(str => str.Contains($"{power}")));
        }

        [TestCase(-5)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(801)]
        [TestCase(850)]
        public void TurnOn_WasOffOutOfRangePower_ThrowsException800Maximumpower(int power)
        {
            var maximumpower800 = new PowerTube(output, 800);
            Assert.Throws<System.ArgumentOutOfRangeException>(() => maximumpower800.TurnOn(power));
        }


        [Test]
        public void TurnOff_WasOn_CorrectOutput()
        {
            uut.TurnOn(50);
            uut.TurnOff();
            output.Received().OutputLine(Arg.Is<string>(str => str.Contains("off")));
        }

        [Test]
        public void TurnOff_WasOff_NoOutput()
        {
            uut.TurnOff();
            output.DidNotReceive().OutputLine(Arg.Any<string>());
        }

        [Test]
        public void TurnOn_WasOn_ThrowsException()
        {
            uut.TurnOn(50);
            Assert.Throws<System.ApplicationException>(() => uut.TurnOn(60));
        }
    }
}