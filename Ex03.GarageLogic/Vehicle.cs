using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class Vehicle
    {
        private string m_ModelName;
        private string m_LicensePlate;
        private float m_RemainingEnergyPercent;

        public Vehicle(string i_ModelName, string i_LicensePlate, float i_RemainingEnergyPercent)
        {
            m_ModelName = i_ModelName;
            m_LicensePlate = i_LicensePlate;
            m_RemainingEnergyPercent = i_RemainingEnergyPercent;
        }
    }
}
