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

        public Truck(EnergySource.eType i_EnergyType, bool i_IsTransportingDangerousMaterials, float i_CargoVolume, string i_ModelName, string i_LicensePlate) : base(i_ModelName, i_LicensePlate, i_EnergyType)
        {
            m_IsTransportingDangerousMaterials = i_IsTransportingDangerousMaterials;
            r_CargoVolume = i_CargoVolume;
        }

        protected override void createTireList()
        {
            throw new NotImplementedException();
        }

        protected override void SetEnergySource(EnergySource.eType i_Type)
        {
            throw new NotImplementedException();
        }
    }
}
