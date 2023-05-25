using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private const int k_TruckWheelAmount = 14;
        private const float k_MaxTruckTirePressure = 26.0f;
        private const Fuel.eType k_TruckFuelType = Fuel.eType.Soler;
        private const float k_TruckFuelCapacity = 135f;
        private bool m_IsTransportingDangerousMaterials;
        private float m_CargoVolume;

        public Truck(EnergySource.eEnergyType i_EnergyType, string i_ModelName, string i_LicensePlate, string i_WheelManufacturer) : base(i_ModelName, i_LicensePlate)
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
                    m_CargoVolume = (float)parameter.Value;
                }
                else if (parameter.Type == typeof(bool))
                {
                    m_IsTransportingDangerousMaterials = (bool)parameter.Value;
                }
                else
                {
                    throw new FormatException(k_WrongFormatMessage);
                }
            }
        }

        protected override void SetEnergySource(EnergySource.eEnergyType i_Type)
        {
            EnergySource = new Fuel(k_TruckFuelCapacity, k_TruckFuelType);
        }

        public override string ToString()
        {
            return $@"Truck::
{base.ToString()}
Is Transporting Dangerous Materials: {m_IsTransportingDangerousMaterials}
Cargo Volume: {m_CargoVolume}
Wheel Amount:{k_TruckWheelAmount}";
        }
    }
}
