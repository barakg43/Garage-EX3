namespace Ex03.GarageLogic
{
    public class VehicleRepairRecord
    {
        public Vehicle VehicleToRepair { get; }

        public string OwnerName { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public enum eRepairStatus
        {
            InRepair = 1,
            Repaired,
            Paid
        }
    

        public eRepairStatus RepairStatus { get; set; }

        

        public VehicleRepairRecord(Vehicle i_VehicleToRepair ,string i_OwnerName, string i_OwnerPhoneNumber)
        {
            VehicleToRepair = i_VehicleToRepair;
            OwnerName = i_OwnerName;
            OwnerPhoneNumber = i_OwnerPhoneNumber;
            RepairStatus = eRepairStatus.InRepair;
        }


        public override string ToString()
        {
          string details=
$@"Owner name:{OwnerName}
Owner Phone Number:{OwnerPhoneNumber}
Vehicle repair stats:{RepairStatus}
Vehicle details{VehicleToRepair}";

          return details;
        }
    }
}
