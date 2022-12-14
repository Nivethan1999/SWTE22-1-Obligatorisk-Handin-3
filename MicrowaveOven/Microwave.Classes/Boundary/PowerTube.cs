using System;
using Microwave.Classes.Interfaces;

namespace Microwave.Classes.Boundary
{
    public class PowerTube : IPowerTube
    {
        private IOutput myOutput;

        private bool IsOn = false;

        public int _MaximumPower { get; set; } // TubePower prop

        public PowerTube(IOutput output, int maximumpower) // Added to PowerTube ctor
        {
            myOutput = output;
            _MaximumPower = maximumpower;
        }

        public void TurnOn(int power)
        {
            if (power < 1 || _MaximumPower < power)
            {
                throw new ArgumentOutOfRangeException("power", power, "Must be between 1 and MaxVoltage (incl.)");
            }

            if (IsOn)
            {
                throw new ApplicationException("PowerTube.TurnOn: is already on");
            }

            myOutput.OutputLine($"PowerTube works with {power}");
            IsOn = true;
        }

        public void TurnOff()
        {
            if (IsOn)
            {
                myOutput.OutputLine($"PowerTube turned off");
            }

            IsOn = false;
        }
    }
}