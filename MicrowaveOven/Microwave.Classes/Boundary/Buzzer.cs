using Microwave.Classes.Interfaces;

namespace Microwave.Classes.Boundary
{
    public class Buzzer : IBuzzer
    {
        private IOutput _output;
        
        public Buzzer(IOutput output)
        {
            _output = output;
        }
        
        public void Buzz(int duration, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                _output.OutputLine($"Buzzer turned on for {duration} ms");
            }
        }
    }
}