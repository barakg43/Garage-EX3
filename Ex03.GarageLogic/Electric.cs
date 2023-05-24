namespace Ex03.GarageLogic
{
    public class Electric : EnergySource
    {
        public Electric(float i_BatteryTimeCapacity)
            : base(i_BatteryTimeCapacity)
        {
        }

        public void ChargeVehicle(float i_ChargingTimeToAdd)
        {
            try
            {
                AddEnergyToSource(i_ChargingTimeToAdd);
            }
            catch(ValueOutOfRangeException outOfRange)
            {
                throw new ValueOutOfRangeException(outOfRange.MinValue, outOfRange.MaxValue * 60);
            }
        }

        public override string ToString()
        {
            return $"Electric:: Battery Capacity: {MaxEnergyAmount} Hours| Left Energy: {GetEnergyPercentRemaining():F}% ";
        }
    }
}
