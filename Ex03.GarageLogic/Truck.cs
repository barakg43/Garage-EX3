using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const int k_TruckWheelAmount = 14;
        private const float k_MaxTruckTirePressure = 26.0f;
        private const eFuelType k_TruckFuelType = eFuelType.Soler;
        private const float k_TruckFuelCapacity = 135f;

        private bool m_IsTransportingDangerousMaterials;
        private float r_CargoVolume;

        public Truck(EnergySource.eType i_EnergyType, string i_ModelName, string i_LicensePlate, string i_WheelManufacturer) : base(i_ModelName, i_LicensePlate)
        {
            m_EnergyType = i_EnergyType;
            AssembleWheelsToVehicle(i_WheelManufacturer, k_MaxTruckTirePressure, k_TruckWheelAmount);
        }

        public override float GetMaxWheelPressureAllow()
        {
            return k_MaxTruckTirePressure;
        }

        public override List<ParameterWrapper> GetUniquePropertiesDataForVehicle()
        {
            List<ParameterWrapper> parameterList = new List<ParameterWrapper>(2);

            parameterList.Add(new ParameterWrapper(typeof(bool), "Is Transporting Dangerous Materials"));
            parameterList.Add(new ParameterWrapper(typeof(float), "Cargo Volume"));

            return parameterList;
        }

        public override void SetUniquePropertiesDataForVehicle(List<ParameterWrapper> i_Parameters)
        {
            SetEnergySource(m_EnergyType);
            foreach (ParameterWrapper parameter in i_Parameters)
            {
                if (parameter.Type == typeof(float))
                {
                    r_CargoVolume = (float)parameter.Value;
                   
                }
                else if (parameter.Type == typeof(bool))
                {
                    m_IsTransportingDangerousMaterials = (bool)parameter.Value;
                }
            }
        }

        protected override void SetEnergySource(EnergySource.eType i_Type)
        {
            EnergySource = new Fuel(k_TruckFuelCapacity, k_TruckFuelType);
        }
    }
}
