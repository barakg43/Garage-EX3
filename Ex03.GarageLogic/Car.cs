using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private const ushort k_WheelAmount = 5;
        private const ushort k_MaxAirPressureInTire = 33;
        private const eFuelType k_FuelTypeForFuelCar = eFuelType.Octan95;
        private const ushort k_MaxFuelAmount = 46;
        private const float k_MaxBatteryCapacity = 5.2f;
        private const string k_ColorPropriety = "Car Color";
        private const string k_DoorAmountPropriety = "Amount Of Door";
        public enum eDoorAmount
        {
            TwoDoors = 2,
            ThreeDoors,
            FourDoors,
            FiveDoors

        }

        private eCarColor m_Color;
        private eDoorAmount m_CarDoorNumber;

        public Car(EnergySource.eType i_EnergyType, string i_ModelName, string i_LicensePlate, string i_WheelManufacturer) : base( i_ModelName, i_LicensePlate)
        {
            m_Type = i_EnergyType;
            AssembleWheelsToVehicle(i_WheelManufacturer, k_MaxAirPressureInTire, k_WheelAmount);
        }


        public override float GetMaxWheelPressureAllow()
        {
            return k_MaxAirPressureInTire;
        }

        public override List<ParameterWrapper> GetUniquePropertiesDataForVehicle()
        {
            List<ParameterWrapper> parameterList = new List<ParameterWrapper>(2);

            parameterList.Add(new ParameterWrapper(typeof(eCarColor), k_ColorPropriety));
            parameterList.Add(new ParameterWrapper(typeof(eDoorAmount), k_DoorAmountPropriety));

            return parameterList;
        }

        public override void SetUniquePropertiesDataForVehicle(List<ParameterWrapper> i_Parameters)
        {
            SetEnergySource(m_Type);
            foreach (ParameterWrapper parameter in i_Parameters)
            {
                if(parameter.Type == typeof(eCarColor))
                {
                    m_Color = (eCarColor)parameter.Value;
                }
                else if (parameter.Type == typeof(eDoorAmount))
                {
                    m_CarDoorNumber = (eDoorAmount)parameter.Value;
                }
            }
        }

  

        protected override void SetEnergySource(EnergySource.eType i_Type)
        {
            if(i_Type == EnergySource.eType.Electric)
            {
                EnergySource = new Electric(k_MaxBatteryCapacity);
            }
            else if(i_Type == EnergySource.eType.Fuel)
            {
                EnergySource = new Fuel(k_MaxFuelAmount, k_FuelTypeForFuelCar);
            }
        }
    }
}
