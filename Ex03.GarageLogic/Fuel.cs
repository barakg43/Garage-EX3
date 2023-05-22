using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Fuel:EnergySource
    {
        private const string k_WrongFuelMessage = "Wrong type of fuel given. Type of fuel should be {0}.";
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
                throw new ArgumentException(string.Format(k_WrongFuelMessage, r_FuelType.ToString()));
            }

            AddEnergyToSource(i_FuelAmountToAdd);
        }

        public override string ToString()
        {
            return $"Fuel:: Type: {r_FuelType} | Tank Capacity: {MaxEnergyAmount}L | Level: {GetEnergyPercentRemaining()}% ";
        }
    }

    
}
