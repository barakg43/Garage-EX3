using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private const int k_MotorcycleWheelAmount = 2;
        private const ushort k_MaxMotorcycleTirePressure = 31;
        private const eFuelType k_MotorcycleFuelType = eFuelType.Octan98;
        private const float k_MotorcycleFuelCapacity = 6.4f;
        private const float k_MotorcycleBatteryCapacity = 2.6f;

        private eMotorcycleLicenseType m_LicenseType;
        private int m_EngineCapacity;

        public Motorcycle(EnergySource.eType i_EnergyType, string i_ModelName, string i_LicensePlate) : base(i_ModelName, i_LicensePlate, i_EnergyType)
        {
            /*m_LicenseType = i_LicenseType;
            m_EngineCapacity = i_EngineCapacity;*/
        }

        public override List<ParameterWrapper> GetUniquePropertiesDataForVehicle()
        {
            throw new NotImplementedException();
        }

        public override void SetUniquePropertiesDataForVehicle(List<ParameterWrapper> i_Parameters)
        {
            throw new NotImplementedException();
        }

        protected override void CreateTireList()
        {
            for(int i = 0; i < k_MotorcycleWheelAmount; i++)
            {
                r_Tires.Add(new Tire("Bike Tire", k_MaxMotorcycleTirePressure));
            }
        }

        protected override void SetEnergySource(EnergySource.eType i_Type)
        {
            if (i_Type == EnergySource.eType.Electric)
            {
                EnergySource = new Electric(k_MotorcycleBatteryCapacity);
            }
            else if (i_Type == EnergySource.eType.Fuel)
            {
                EnergySource = new Fuel(k_MotorcycleFuelCapacity, k_MotorcycleFuelType);
            }
        }
    }
}
