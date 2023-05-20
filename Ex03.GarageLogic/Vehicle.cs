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
        protected readonly List<Tire> r_Tires;
        private EnergySource m_EnergySource;

        public Vehicle( string i_ModelName, string i_LicensePlate, EnergySource.eType i_EnergyType)
        {
            r_ModelName = i_ModelName;
            r_LicensePlate = i_LicensePlate;
            r_Tires = new List<Tire>();
            SetEnergySource(i_EnergyType);
            CreateTireList();
        }

        public void InflateAllTireToMaxPressure()
        {
            foreach(Tire singleTire in r_Tires)
            {
                singleTire.InflateTireToMaxPressure();
            }

        }

        public string ModelName
        {
            get => r_ModelName;
        }
        public string LicensePlate
        {
            get => r_LicensePlate;
        }
        public List<Tire> Tires => r_Tires;

        public EnergySource EnergySource
        {
            get => m_EnergySource;
            protected set => m_EnergySource = value;
        }

        public void InflateAirPressureToAllTires(float i_AirPressureToAdd)
        {
            foreach (Tire singleTire in r_Tires)
            {
                singleTire.InflateTire(i_AirPressureToAdd);
            }

        }

        protected abstract void CreateTireList();
        protected abstract void SetEnergySource(EnergySource.eType i_Type);
        public float MaxEnergyAmountAllow => m_EnergySource.MaxEnergyAmount;
    }
}
