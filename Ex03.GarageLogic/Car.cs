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
        private const string k_ColorPropriety = "CarColor";
        private const string k_DoorAmountPropriety = "Amount Of Door";
        public enum eDoorAmount
        {
            TwoDoors = 2,
            ThreeDoors,
            FourDoors,
            FiveDoors

        }


        private eCarColor m_Color;
        private readonly eDoorAmount r_CarDoorNumber;

        public Car(EnergySource.eType i_EnergyType, string i_ModelName, string i_LicensePlate) : base( i_ModelName, i_LicensePlate, i_EnergyType)
        {
            //m_Color = i_Color;
            //r_CarDoorNumber = i_CarDoorAmount;
            SetEnergySource(i_EnergyType);
            CreateTireList();
        }


        public override List<ParameterWrapper> GetUniquePropertiesDataForVehicle()
        {
            List<ParameterWrapper> parameterList = new List<ParameterWrapper>(2);


            parameterList.Add(new ParameterWrapper(typeof(eCarColor), k_ColorPropriety));
            parameterList.Add(new ParameterWrapper(typeof(eDoorAmount), k_ColorPropriety));

            return parameterList;
        }

        public override void SetUniquePropertiesDataForVehicle(List<ParameterWrapper> i_Parameters)
        {
            throw new NotImplementedException();
        }

        protected override void CreateTireList()
        {
            for(ushort i = 0; i < k_WheelAmount; i++)
            {
                r_Tires.Add(new Tire("bla bla",k_MaxAirPressureInTire));
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
