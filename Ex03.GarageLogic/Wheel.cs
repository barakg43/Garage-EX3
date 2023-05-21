using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_ManufacturerName;
        private readonly float r_MaximumTirePressure;
        private float m_CurrentTirePressure;

        public Wheel(string i_ManufacturerName, float i_MaximumTirePressure)
        {
            r_ManufacturerName = i_ManufacturerName;
            r_MaximumTirePressure = i_MaximumTirePressure;
            m_CurrentTirePressure = 0;
        }

        public string ManufacturerName
        {
            get
            {
                return r_ManufacturerName;
            }
        }

        public void InflateTire(float i_InflationAmountToAdd)
        {
            if(m_CurrentTirePressure + i_InflationAmountToAdd <= r_MaximumTirePressure)
            {
                m_CurrentTirePressure += i_InflationAmountToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaximumTirePressure - m_CurrentTirePressure);
            }
        }
        public void InflateTireToMaxPressure()
        {
            m_CurrentTirePressure = r_MaximumTirePressure;
        }
    }
}
