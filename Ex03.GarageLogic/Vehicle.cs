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
        private readonly List<Tire> m_Tires;
        private EnergySource m_EnergySource=null;

        public Vehicle(string i_ModelName, string i_LicensePlate,  List<Tire> i_Tires)
        {
            m_ModelName = i_ModelName;
            m_LicensePlate = i_LicensePlate;
           
            m_Tires = i_Tires;
        }

        public virtual void SetEnergySource(EnergySource.eType i_EnergyType, float i_MaxCapacityAmount)
        {


        }

        public void InflateAllTireToMaxPressure()
        {
            foreach(Tire singleTire in m_Tires)
            {
                singleTire.InflateTireToMaxPressure();
            }

        }
        public void InflateAirPressureToAllTires(float i_AirPressureToAdd)
        {
            foreach (Tire singleTire in m_Tires)
            {
                singleTire.InflateTire(i_AirPressureToAdd);
            }

        }
        public float MaxEnergyAmountAllow
        {
            get
            {
                return m_EnergySource.MaxEnergyAmount;
            }
        }
       
    }
}
