namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        private float m_CurrentEnergyAmount;

        protected EnergySource(float i_MaxEnergyAmount)
        {
            m_CurrentEnergyAmount = 0;
            MaxEnergyAmount = i_MaxEnergyAmount;
        }

        public enum eEnergyType
        {
            Electric = 1,
            Fuel
        }

        public float CurrentEnergyAmount
        {
            get
            {
                return m_CurrentEnergyAmount;
            }

            set
            {
                m_CurrentEnergyAmount = value;
            }
        }

        protected void AddEnergyToSource(float i_EnergyAmountToAdd)
        {
            if (m_CurrentEnergyAmount + i_EnergyAmountToAdd > MaxEnergyAmount)
            {
                    throw new ValueOutOfRangeException(0, MaxEnergyAmount - CurrentEnergyAmount);
            }

            m_CurrentEnergyAmount += i_EnergyAmountToAdd;
        }

        public float GetEnergyPercentRemaining()
        {
            float energyPercentRemainFraction = CurrentEnergyAmount / MaxEnergyAmount;

            return energyPercentRemainFraction * 100;
        }

        public float MaxEnergyAmount { get; }

        public override string ToString()
        {
            return $"Max Energy Capacity:{MaxEnergyAmount} | Energy Percent: {GetEnergyPercentRemaining()} ";
        }
    }
}
