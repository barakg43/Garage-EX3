using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicensePlate;
        protected readonly List<Wheel> r_Wheels;
        protected const string k_WrongFormatMessage = "Given Parameter type doesn't match any member.";

        private EnergySource m_EnergySource;
        protected EnergySource.eType m_EnergyType;

        public Vehicle(string i_ModelName, string i_LicensePlate)
        {
            r_ModelName = i_ModelName;
            r_LicensePlate = i_LicensePlate;
            r_Wheels = new List<Wheel>();
        }

        public void InflateAllTireToMaxPressure()
        {
            foreach(Wheel singleTire in r_Wheels)
            {
                singleTire.InflateTireToMaxPressure();
            }
        }

        public abstract float GetMaxWheelPressureAllow();
       
        public string ModelName
        {
            get => r_ModelName;
        }

        public string LicensePlate
        {
            get => r_LicensePlate;
        }

        public List<Wheel> Wheels => r_Wheels;

        public EnergySource EnergySource
        {
            get => m_EnergySource;
            protected set => m_EnergySource = value;
        }

        public EnergySource.eType EnergyType
        {
            get => m_EnergyType;
        }

        public void InflateAirPressureToAllTires(float i_AirPressureToAdd)
        {
            foreach (Wheel singleTire in r_Wheels)
            {
                singleTire.InflateTire(i_AirPressureToAdd);
            }
        }

        public abstract List<ParameterWrapper> GetUniquePropertiesDataForVehicle();

        public abstract void SetUniquePropertiesDataForVehicle(List<ParameterWrapper> i_Parameters);

        protected void AssembleWheelsToVehicle(string i_WheelManufacturer, float i_MaximumTirePressure, int i_WheelAmount)
        {
            for (int i = 0; i < i_WheelAmount; i++)
            {
                r_Wheels.Add(new Wheel(i_WheelManufacturer, i_MaximumTirePressure));
            }
        }

        protected abstract void SetEnergySource(EnergySource.eType i_Type);

        public float MaxEnergyAmountAllow => m_EnergySource.MaxEnergyAmount;

        private string getWheelsDetails()
        {
            int wheelNumber = 1;
            StringBuilder allWheelsDetails = new StringBuilder();

            foreach(Wheel wheel in Wheels)
            {
                allWheelsDetails.AppendFormat("{0}. {1}{2}", wheelNumber++, wheel, Environment.NewLine);
            }

            return allWheelsDetails.ToString();
        }

        public override string ToString()
        {
            string details = $@"License Plate:{r_LicensePlate}
Model Name:{r_ModelName}
Wheels:
{getWheelsDetails()}
Engine:{m_EnergySource}";

            return details;
        }
    }
}
