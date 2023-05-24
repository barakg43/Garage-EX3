﻿using System;

namespace Ex03.GarageLogic
{
    public class WrongEnergyTypeException : Exception
    {
        private const string k_ExceptionMsg = "This vehicle doesn't run on {0}, but on {1}";

        public WrongEnergyTypeException(EnergySource.eEnergyType i_GivenEnergyType, EnergySource.eEnergyType i_RequiredEnergyType)
            : base(string.Format(k_ExceptionMsg, i_GivenEnergyType, i_RequiredEnergyType))
        {
        }
    }
}
