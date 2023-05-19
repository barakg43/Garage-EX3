using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private const uint k_MinDoorsNumber = 2;
        private const uint k_MaxDoorsNumber = 5;

        private eCarColor m_Color;
        private readonly uint r_CarDoorNumber;

        public Car(eCarColor i_Color, uint i_CarDoorNumber, string i_ModelName, string i_LicensePlate, float i_RemainingEnergyPercent, List<Tire> i_Tires) : base(i_ModelName, i_LicensePlate, i_Tires)
        {
            m_Color = i_Color;
            r_CarDoorNumber = i_CarDoorNumber;
        }
    }
}
