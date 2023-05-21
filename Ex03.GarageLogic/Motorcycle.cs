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

        public Motorcycle(EnergySource.eType i_EnergyType, string i_ModelName, string i_LicensePlate, string i_WheelManufacturer) : base(i_ModelName, i_LicensePlate)
        {
            /*m_LicenseType = i_LicenseType;
            m_EngineCapacity = i_EngineCapacity;*/
            m_Type = i_EnergyType;
            AssembleWheelsToVehicle(i_WheelManufacturer, k_MaxMotorcycleTirePressure, k_MotorcycleWheelAmount);
        }

        public override float GetMaxWheelPressureAllow()
        {
            return k_MaxMotorcycleTirePressure;
        }

        public override List<ParameterWrapper> GetUniquePropertiesDataForVehicle()
        {
            List<ParameterWrapper> parameterList = new List<ParameterWrapper>(2);


            parameterList.Add(new ParameterWrapper(typeof(eMotorcycleLicenseType), "License Type"));
            parameterList.Add(new ParameterWrapper(typeof(int), "Engine Capacity"));

            return parameterList;
        }

        public override void SetUniquePropertiesDataForVehicle(List<ParameterWrapper> i_Parameters)
        {
            SetEnergySource(m_Type);
            foreach (ParameterWrapper parameter in i_Parameters)
            {
                if (parameter.Type == typeof(eMotorcycleLicenseType))
                {
                    m_LicenseType = (eMotorcycleLicenseType)parameter.Value;
                }
                else if (parameter.Type == typeof(int))
                {
                    m_EngineCapacity = (int)parameter.Value;
                }
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
