using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const int k_TruckWheelAmount = 14;
        private const int k_MaxTruckTirePressure = 26;
        private const eFuelType k_TruckFuelType = eFuelType.Soler;
        private const float k_TruckFuelCapacity = 135f;

        private bool m_IsTransportingDangerousMaterials;
        private readonly float r_CargoVolume;

        public Truck(EnergySource.eType i_EnergyType, string i_ModelName, string i_LicensePlate) : base(i_ModelName, i_LicensePlate, i_EnergyType)
        {
            /*m_IsTransportingDangerousMaterials = i_IsTransportingDangerousMaterials;
            r_CargoVolume = i_CargoVolume;*/
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
            for (int i = 0; i < k_TruckWheelAmount; i++)
            {
                r_Tires.Add(new Tire("Truck Tire", k_MaxTruckTirePressure));
            }
        }

        protected override void SetEnergySource(EnergySource.eType i_Type)
        {
            EnergySource = new Fuel(k_TruckFuelCapacity, k_TruckFuelType);
        }
    }
}
