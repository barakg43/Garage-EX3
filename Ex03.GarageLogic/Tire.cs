using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Tire
    {
        private readonly string r_ManufacturerName;
        private readonly float r_MaximumTirePressure;

        private float m_CurrentTirePressure;

        public Tire(string i_ManufacturerName, float i_MaximumTirePressure, float i_CurrentTirePressure)
        {
            r_ManufacturerName = i_ManufacturerName;
            r_MaximumTirePressure = i_MaximumTirePressure;
            m_CurrentTirePressure = i_CurrentTirePressure;
        }

        public void InflateTire(float i_InflationAmount)
        {
            if(m_CurrentTirePressure + i_InflationAmount <= r_MaximumTirePressure)
            {
                m_CurrentTirePressure += i_InflationAmount;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaximumTirePressure - m_CurrentTirePressure);
            }
        }
    }
}
