using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicensePlate;
        protected readonly List<Wheel> r_Tires;
        private EnergySource m_EnergySource;
        protected EnergySource.eType m_Type;

        public Vehicle( string i_ModelName, string i_LicensePlate)
        {
            r_ModelName = i_ModelName;
            r_LicensePlate = i_LicensePlate;
            r_Tires = new List<Wheel>();
        }

        public void InflateAllTireToMaxPressure()
        {
            foreach(Wheel singleTire in r_Tires)
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
        public List<Wheel> Tires => r_Tires;

        public EnergySource EnergySource
        {
            get => m_EnergySource;
            protected set => m_EnergySource = value;
        }

        public void InflateAirPressureToAllTires(float i_AirPressureToAdd)
        {
            foreach (Wheel singleTire in r_Tires)
            {
                singleTire.InflateTire(i_AirPressureToAdd);
            }

        }


        public abstract List<ParameterWrapper> GetUniquePropertiesDataForVehicle();
        public abstract void SetUniquePropertiesDataForVehicle(List<ParameterWrapper> i_Parameters);

        protected void AssembleWheelsToVehicle(string i_WheelManufacturer, float i_MaximumTirePressure,int i_WheelAmount)
        {
            for (int i = 0; i < i_WheelAmount; i++)
            {
                r_Tires.Add(new Wheel(i_WheelManufacturer, i_MaximumTirePressure));
            }
        }
        protected abstract void SetEnergySource(EnergySource.eType i_Type);
        public float MaxEnergyAmountAllow => m_EnergySource.MaxEnergyAmount;

        public override string ToString()
        {

            string details = 
$@"License Plate:{r_LicensePlate}
Model Name:{r_ModelName}
Engine:{m_EnergySource}
Vehicle details:
{VehicleToRepair}";

            return details;
        
            return $", {nameof(r_LicensePlate)}: {r_LicensePlate}, {nameof(r_Tires)}: {r_Tires}, {nameof(m_EnergySource)}: {m_EnergySource}, {nameof(m_Type)}: {m_Type}, {nameof(ModelName)}: {ModelName}, {nameof(LicensePlate)}: {LicensePlate}, {nameof(Tires)}: {Tires}, {nameof(EnergySource)}: {EnergySource}, {nameof(MaxEnergyAmountAllow)}: {MaxEnergyAmountAllow}";
        }
    }
}
