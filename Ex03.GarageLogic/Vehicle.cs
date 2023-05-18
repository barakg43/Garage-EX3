using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private string m_ModelName;
        private string m_LicensePlate;
        private float m_RemainingEnergyPercent;
        private readonly List<Tire> m_Tires;

        public Vehicle(string i_ModelName, string i_LicensePlate, float i_RemainingEnergyPercent, List<Tire> i_Tires)
        {
            m_ModelName = i_ModelName;
            m_LicensePlate = i_LicensePlate;
            m_RemainingEnergyPercent = i_RemainingEnergyPercent;
            m_Tires = i_Tires;
        }
    }
}
