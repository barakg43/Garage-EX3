using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class WrongEnergyTypeException: Exception
    {
        private const string k_ExceptionMsg = "This vehicle doesn't run on {0}, but on {1}";//bad phrasing

        public WrongEnergyTypeException(EnergySource.eType i_GivenEnergyType, EnergySource.eType i_RequiredEnergyType)
            : base(string.Format(k_ExceptionMsg, i_GivenEnergyType, i_RequiredEnergyType))
        { }
    }
}
