using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private const ushort k_WheelAmount = 5;
        private const ushort k_MaxAirPressureInTire = 33;
        private const Fuel.eType k_FuelTypeForFuelCar = Fuel.eType.Octan95;
        private const ushort k_MaxFuelAmount = 46;
        private const float k_MaxBatteryCapacity = 5.2f;
        private const string k_ColorProperty = "Car Color";
        private const string k_DoorAmountProperty = "Amount Of Door";
        private eColor m_Color;
        private eDoorAmount m_CarDoorNumber;

        public enum eDoorAmount
        {
            TwoDoors = 2,
            ThreeDoors,
            FourDoors,
            FiveDoors
        }

        public enum eColor
        {
            White = 1,
            Black,
            Yellow,
            Red,
        }

        public Car(EnergySource.eEnergyType i_EnergyType, string i_ModelName, string i_LicensePlate, string i_WheelManufacturer) : base(i_ModelName, i_LicensePlate)
        {
            m_EnergyType = i_EnergyType;
            AssembleWheelsToVehicle(i_WheelManufacturer, k_MaxAirPressureInTire, k_WheelAmount);
        }

        public override float GetMaxWheelPressureAllow()
        {
            return k_MaxAirPressureInTire;
        }

        public override List<ParameterWrapper> GetUniquePropertiesDataForVehicle()
        {
            List<ParameterWrapper> parameterList = new List<ParameterWrapper>(2);

            parameterList.Add(new ParameterWrapper(typeof(eColor), k_ColorProperty));
            parameterList.Add(new ParameterWrapper(typeof(eDoorAmount), k_DoorAmountProperty));

            return parameterList;
        }

        public override void SetUniquePropertiesDataForVehicle(List<ParameterWrapper> i_Parameters)
        {
            SetEnergySource(m_EnergyType);
            foreach (ParameterWrapper parameter in i_Parameters)
            {
                if(parameter.Type == typeof(eColor))
                {
                    m_Color = (eColor)parameter.Value;
                }
                else if (parameter.Type == typeof(eDoorAmount))
                {
                    m_CarDoorNumber = (eDoorAmount)parameter.Value;
                }
                else
                {
                    throw new FormatException(k_WrongFormatMessage);
                }
            }
        }

        protected override void SetEnergySource(EnergySource.eEnergyType i_Type)
        {
            if(i_Type == EnergySource.eEnergyType.Electric)
            {
                EnergySource = new Electric(k_MaxBatteryCapacity);
            }
            else if(i_Type == EnergySource.eEnergyType.Fuel)
            {
                EnergySource = new Fuel(k_MaxFuelAmount, k_FuelTypeForFuelCar);
            }
        }

        public override string ToString()
        {
            return $@"Car::
{base.ToString()}
Color: {m_Color}
Door Amount: {(int)m_CarDoorNumber}
Wheel Amount:{k_WheelAmount}";
        }
    }
}
