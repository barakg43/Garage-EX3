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
            AddEnergyToSource(i_ChargingTimeToAdd);
        }

        public override string ToString()
        {
            return $"Electric:: Battery Capacity: {MaxEnergyAmount} Hours| Left Energy: {GetEnergyPercentRemaining()}% ";
        }
    }
}
