
using System;
using System.Collections.Generic;
using System.Linq;


namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, VehicleRepairRecord> r_Vehicles;

        public Garage()
        {
            r_Vehicles = new Dictionary<string, VehicleRepairRecord>();
        }

        public enum eGarageStatus
        {
            RepairInProgress,
            RepairDone,
            Payed,
        }

        public void AddVehicle(VehicleRepairRecord i_NewVehicle)
        {
            r_Vehicles.Add(i_NewVehicle.VehicleToRepair.LicensePlate, i_NewVehicle);
        }
        public bool IsVehicleExist(string i_VehicleLicensePlate)
        {
            return r_Vehicles.ContainsKey(i_VehicleLicensePlate);
        }

        public List<string> GetVehiclePlateNumberListFilterByState(VehicleRepairRecord.eRepairStatus i_RepairStatus, bool i_IsFiltered)
        {
            List<string> filteredList = new List<string>();
            if(!i_IsFiltered)
            {
                filteredList = r_Vehicles.Keys.ToList();
            }
            else
            {
                foreach (KeyValuePair<string, VehicleRepairRecord> licensePlateAndVehicle in r_Vehicles)
                {
                    if (licensePlateAndVehicle.Value.RepairStatus == i_RepairStatus)
                    {
                        filteredList.Add(licensePlateAndVehicle.Key);
                    }
                }
            }
            
            return filteredList;
        }

        public void ChangeVehicleStatus(string i_VehicleLicensePlate, VehicleRepairRecord.eRepairStatus i_RepairStatus)
        {
            VehicleRepairRecord vehicleToUpdate = r_Vehicles[i_VehicleLicensePlate];
            vehicleToUpdate.RepairStatus = i_RepairStatus;
        }

        public void InflateVehicleTiresToMaxPressure(string i_VehicleLicensePlate)
        {
            r_Vehicles[i_VehicleLicensePlate].VehicleToRepair.InflateAllTireToMaxPressure();
        }

        public void FuelVehicleInGarage(string i_VehicleLicensePlate, eFuelType i_FuelType, float i_AmountToFuel)
        {
            Vehicle vehicleToFuel = r_Vehicles[i_VehicleLicensePlate].VehicleToRepair;

            if(vehicleToFuel.EnergySource is Fuel fuel)
            {
                fuel.RefuelVehicle(i_FuelType, i_AmountToFuel);
            }
            else
            {
                throw new WrongEnergyTypeException(EnergySource.eType.Fuel, EnergySource.eType.Electric);
            }
        }

        public void ChargeVehicleInGarage(string i_VehicleLicensePlate, float i_ElectricAmountToAdd)
        {
            Vehicle vehicleToCharge = r_Vehicles[i_VehicleLicensePlate].VehicleToRepair;
            if (vehicleToCharge.EnergySource is Electric electric)
            {
                electric.ChargeVehicle(i_ElectricAmountToAdd);
            }
            else
            {
                throw new WrongEnergyTypeException(EnergySource.eType.Fuel, EnergySource.eType.Electric);
            }
        }

        public List<VehicleRepairRecord> GetAllVehicleRecords()
        {
            throw new NotImplementedException();
        }
    }
}
