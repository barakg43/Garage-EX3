using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class Fuel:EnergySource
    {
        private readonly eFuelType r_FuelType;

        public Fuel(float i_MaxEnergyAmount, eFuelType i_FuelType)
            : base( i_MaxEnergyAmount)
        {
            r_FuelType = i_FuelType;
        }

        public bool IsCorrectFuelType(eFuelType i_FuelType)
        {
            return i_FuelType == r_FuelType;
        }

        public void RefuelVehicle(eFuelType i_FuelType, float i_FuelAmountToAdd)
        {
            if(!IsCorrectFuelType(i_FuelType))
            {
                throw new ArgumentException("Wrong type of fuel to this vehicle.");
            }

            AddEnergyToSource(i_FuelAmountToAdd);
        }

    }

    
}
