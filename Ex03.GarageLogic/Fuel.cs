using System;

namespace Ex03.GarageLogic
{
    public class Fuel : EnergySource
    {
        private const string k_WrongFuelMessage = "Wrong type of fuel given. Type of fuel should be {0}.";
        private readonly eType r_Type;

        public enum eType
        {
            Octan95 = 1,
            Octan96,
            Octan98,
            Soler
        }

        public Fuel(float i_MaxEnergyAmount, eType i_Type)
            : base(i_MaxEnergyAmount)
        {
            r_Type = i_Type;
        }

        public bool IsCorrectFuelType(eType i_Type)
        {
            return i_Type == r_Type;
        }

        public void RefuelVehicle(eType i_Type, float i_FuelAmountToAdd)
        {
            if(!IsCorrectFuelType(i_Type))
            {
                throw new ArgumentException(string.Format(k_WrongFuelMessage, r_Type.ToString()));
            }

            AddEnergyToSource(i_FuelAmountToAdd);
        }

        public override string ToString()
        {
            return $"Fuel:: Type: {r_Type} | Tank Capacity: {MaxEnergyAmount}L | Level: {GetEnergyPercentRemaining():f}% ";
        }
    }
}
