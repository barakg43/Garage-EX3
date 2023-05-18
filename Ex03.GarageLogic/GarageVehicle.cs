using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class GarageVehicle
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eGarageStatus m_GarageStatus;

        private readonly Vehicle r_Vehicle;

        public GarageVehicle(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_GarageStatus = eGarageStatus.RepairInProgress;
            r_Vehicle = i_Vehicle;
        }
    }
}
