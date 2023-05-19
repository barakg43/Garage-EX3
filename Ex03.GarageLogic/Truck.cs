using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsTransportingDangerousMaterials;
        private readonly float r_CargoVolume;

        public Truck(bool i_IsTransportingDangerousMaterials, float i_CargoVolume, string i_ModelName, string i_LicensePlate, float i_RemainingEnergyPercent, List<Tire> i_Tires) : base(i_ModelName, i_LicensePlate, i_Tires)
        {
            m_IsTransportingDangerousMaterials = i_IsTransportingDangerousMaterials;
            r_CargoVolume = i_CargoVolume;
        }
    }
}
