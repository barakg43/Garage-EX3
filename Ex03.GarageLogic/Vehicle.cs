using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicensePlate;
        protected readonly List<Tire> r_Tires;
        private EnergySource m_EnergySource;

        public Vehicle( string i_ModelName, string i_LicensePlate, EnergySource.eType i_EnergyType)
        {
            m_ModelName = i_ModelName;
            m_LicensePlate = i_LicensePlate;
            r_Tires = new List<Tire>();
            SetEnergySource(i_EnergyType);
            createTireList();
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
            get => m_ModelName;
        }
        public string LicensePlate
        {
            get => m_LicensePlate;
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

        protected abstract void createTireList();
        protected abstract void SetEnergySource(EnergySource.eType i_Type);
        public float MaxEnergyAmountAllow
        {
            get
            {
                return m_EnergySource.MaxEnergyAmount;
            }
        }
       
    }
}
