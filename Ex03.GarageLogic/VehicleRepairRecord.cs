namespace Ex03.GarageLogic
{
    public class VehicleRepairRecord
    {
        public Vehicle VehicleToRepair
        {
            get;
        }

        public string OwnerName { get; }

        public string OwnerPhoneNumber { get; }

        public enum eRepairStatus
        {
            InRepair = 1,
            Repaired,
            Paid
        }
        
        public eRepairStatus RepairStatus { get; set; }

        public VehicleRepairRecord(Vehicle i_VehicleToRepair, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            VehicleToRepair = i_VehicleToRepair;
            OwnerName = i_OwnerName;
            OwnerPhoneNumber = i_OwnerPhoneNumber;
            RepairStatus = eRepairStatus.InRepair;
        }

        public override string ToString()
        {
          string details =
$@"++++++++++++++ Vehicle ++++++++++++++
Owner name:{OwnerName}
Owner Phone Number:{OwnerPhoneNumber}
Vehicle repair status:{RepairStatus}
{VehicleToRepair}";

          return details;
        }
    }
}
