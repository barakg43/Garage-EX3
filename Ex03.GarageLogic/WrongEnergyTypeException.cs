using System;

namespace Ex03.GarageLogic
{
    public class WrongEnergyTypeException : FormatException
    {
        private const string k_ExceptionMsg = "This vehicle run on {0}, not on {1} energy.";

        public WrongEnergyTypeException(EnergySource.eEnergyType i_GivenEnergyType, EnergySource.eEnergyType i_RequiredEnergyType)
            : base(string.Format(k_ExceptionMsg, i_RequiredEnergyType, i_GivenEnergyType ))
        {
        }
    }
}
