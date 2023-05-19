using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Electric :EnergySource
    {
        public Electric(float i_CurrentEnergyAmount, float i_BatteryTimeCapacity)
            : base(i_CurrentEnergyAmount, i_BatteryTimeCapacity)
        {
        }

        public void ChargingVehicle(float i_ChargingTimeToAdd)
        {
            CurrentEnergyAmount += i_ChargingTimeToAdd;
        }
    }
}
