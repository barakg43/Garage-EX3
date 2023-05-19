
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public bool IsVehicleExist(string i_VehicleLicensePlate)
        {
            throw new NotImplementedException();
        }

        public List<string> GetVehiclePlateNumberListFilterByState(VehicleRepairRecord.eRepairStatus i_RepairStatus)
        {
            throw new NotImplementedException();
        }

        public void ChangeVehicleStatus(string i_VehicleLicensePlate, VehicleRepairRecord.eRepairStatus i_RepairStatus)
        {
            throw new NotImplementedException();
        }

        public void InflateVehicleTiresToMaxPerssure(string i_VehicleLicensePlate)
        {
            throw new NotImplementedException();
        }

        public void FuelVehicleInGarage(string i_VehicleLicensePlate, eFuelType i_FuelType, float i_AmountToFuel)
        {
            throw new NotImplementedException();
        }

        public void ChargeVehicleInGarage(string i_VehicleLicensePlate, float i_OElectricAmountToAdd)
        {
            throw new NotImplementedException();
        }

        public List<VehicleRepairRecord> GetAllVehicleRecords()
        {
            throw new NotImplementedException();
        }
    }
}
