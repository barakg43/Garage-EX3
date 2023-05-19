using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {

        private float m_CurrentEnergyAmount;

        public EnergySource(float i_CurrentEnergyAmount, float i_MaxEnergyAmount)
        {
            m_CurrentEnergyAmount = i_CurrentEnergyAmount;
            MaxEnergyAmount = i_MaxEnergyAmount;
        }

        public enum eType
        {
            Electric,
            Fuel
        }
        public float CurrentEnergyAmount
        {
            get
            {
                return m_CurrentEnergyAmount;
            }
        }

        protected void SetCurrentEnergyAmount(float i_CurrentEnergyAmount)
        {
            if (i_CurrentEnergyAmount > MaxEnergyAmount)
            {
                    throw new ValueOutOfRangeException(0, MaxEnergyAmount - CurrentEnergyAmount);
            }

            m_CurrentEnergyAmount = i_CurrentEnergyAmount;
            
        }
        public float GetEnergyPercentRemaining()
        {
            float energyPercentRemainFraction = 1-(CurrentEnergyAmount / MaxEnergyAmount);
            return energyPercentRemainFraction * 100;
        }
        public float MaxEnergyAmount { get; }
    }
}
