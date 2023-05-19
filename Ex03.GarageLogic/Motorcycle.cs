using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private eMotorcycleLicenseType m_LicenseType;
        private int m_EngineCapacity;

        public Motorcycle(EnergySource.eType i_EnergyType,eMotorcycleLicenseType i_LicenseType, int i_EngineCapacity, string i_ModelName, string i_LicensePlate, float i_RemainingEnergyPercent, List<Tire> i_Tires) : base(i_ModelName, i_LicensePlate, i_EnergyType)
        {
            m_LicenseType = i_LicenseType;
            m_EngineCapacity = i_EngineCapacity;
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
