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

        public void AddVehicle(Vehicle i_VehicleToRepair, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            if(IsVehicleExist(i_VehicleToRepair.LicensePlate))
            {
                throw new FormatException(
                    $"Vehicle with plate number [{i_VehicleToRepair.LicensePlate}] already exist");
            }

            r_Vehicles.Add(i_VehicleToRepair.LicensePlate, new VehicleRepairRecord(i_VehicleToRepair, i_OwnerName, i_OwnerPhoneNumber));
        }

        public bool IsVehicleExist(string i_VehicleLicensePlate)
        {
            return r_Vehicles.ContainsKey(i_VehicleLicensePlate);
        }

        public List<string> GetVehiclePlateNumberListFilterByState(VehicleRepairRecord.eRepairStatus i_RepairStatus, bool i_IsFiltered)
        {
            List<string> filteredList;

            if(!i_IsFiltered)
            {
                filteredList = r_Vehicles.Keys.ToList();
            }
            else
            {
                filteredList = new List<string>();
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

        public VehicleRepairRecord.eRepairStatus ChangeVehicleStatus(string i_VehicleLicensePlate, VehicleRepairRecord.eRepairStatus i_RepairStatus)
        {
            VehicleRepairRecord.eRepairStatus oldRepairStatus;

            checkIfVehicleExistInGarage(i_VehicleLicensePlate);
            oldRepairStatus = r_Vehicles[i_VehicleLicensePlate].RepairStatus;
            r_Vehicles[i_VehicleLicensePlate].RepairStatus = i_RepairStatus;

            return oldRepairStatus;
        }

        public void InflateVehicleTiresToMaxPressure(string i_VehicleLicensePlate)
        {
            checkIfVehicleExistInGarage(i_VehicleLicensePlate);
            r_Vehicles[i_VehicleLicensePlate].VehicleToRepair.InflateAllTireToMaxPressure();
        }

        public void FuelVehicleInGarage(string i_VehicleLicensePlate, Fuel.eType i_FuelType, float i_AmountToFuel)
        {
            Vehicle vehicleToFuel;

            checkIfVehicleExistInGarage(i_VehicleLicensePlate);
            vehicleToFuel = r_Vehicles[i_VehicleLicensePlate].VehicleToRepair;
            if(vehicleToFuel.EnergySource is Fuel fuel)
            {
                fuel.RefuelVehicle(i_FuelType, i_AmountToFuel);
            }
            else
            {
                throw new WrongEnergyTypeException(EnergySource.eEnergyType.Fuel, EnergySource.eEnergyType.Electric);
            }
        }

        public void ChargeVehicleInGarage(string i_VehicleLicensePlate, float i_ElectricAmountToAdd)
        {
            Vehicle vehicleToCharge;

            checkIfVehicleExistInGarage(i_VehicleLicensePlate);
            vehicleToCharge = r_Vehicles[i_VehicleLicensePlate].VehicleToRepair;
            if (vehicleToCharge.EnergySource is Electric electric)
            {
                electric.ChargeVehicle(i_ElectricAmountToAdd);
            }
            else
            {
                throw new WrongEnergyTypeException(EnergySource.eEnergyType.Fuel, EnergySource.eEnergyType.Electric);
            }
        }

        private void checkIfVehicleExistInGarage(string i_LicensePlate)
        {
            if (!IsVehicleExist(i_LicensePlate))
            {
                throw new ArgumentException($"Vehicle {i_LicensePlate} not exist in garage");
            }
        }

        public List<VehicleRepairRecord> GetAllVehicleRecords()
        {
            return r_Vehicles.Values.ToList();
        }
    }
}
