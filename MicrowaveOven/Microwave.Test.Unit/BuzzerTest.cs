using Microwave.Classes.Boundary;
using Microwave.Classes.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Microwave.Test.Unit
{
    [TestFixture]
    public class BuzzerTest
    {
        private Buzzer uut;
        private IOutput _output;

        [SetUp]
        public void Setup()
        {
            _output = Substitute.For<IOutput>();
            uut = new Buzzer(_output);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Buzz_Output_Called(int amount)
        {
            uut.Buzz(200, amount);
            _output.Received(amount).OutputLine(Arg.Is<string>(str => str.Contains("Buzzer turned on for 200 ms")));
        }
    }
}