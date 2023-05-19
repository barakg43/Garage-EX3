using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageManager
    {
        private const string k_TieMsg = "Its a tie";
        private readonly Garage r_Garage;
        private readonly UserInterface r_UserInterface;

        
        public GarageManager()
        {
            r_UserInterface = new UserInterface();
            r_Garage = new Garage();
        }

        public void RunMenu()
        {
            bool isUserWantToExit = false;



            while (!isUserWantToExit)
            {
                r_UserInterface.PrintMainMenu();
                switch (r_UserInterface.GetAndCheckUserInputForMenuItem())
                {
                    case UserInterface.eMenuOptions.EnterVehicleToGarage:
                        enterVehicleToGarage();
                        break;
                    case UserInterface.eMenuOptions.ShowVehicleInGarageByStatus:
                        showVehicleListInGarageFilterByStatus();
                        break;
                    case UserInterface.eMenuOptions.ChangeVehicleStatusInGarage:
                        changeVehicleStatus();
                        break;
                    //case UserInterface.eMenuOptions.InflateVehicleTires:
                    //    r_Engine.Create2Players(ePlayerName.Player1, ePlayerName.Computer);
                    //    break;
                    //case UserInterface.eMenuOptions.FuelVehicle:
                    //    r_Engine.Create2Players(ePlayerName.Player1, ePlayerName.Computer);
                    //    break;
                    //case UserInterface.eMenuOptions.ChargeVehicle:
                    //    r_Engine.Create2Players(ePlayerName.Player1, ePlayerName.Computer);
                    //    break;
                    //case UserInterface.eMenuOptions.ShowVehicleDetails:
                    //    r_Engine.Create2Players(ePlayerName.Player1, ePlayerName.Computer);
                    //    break;
                    case UserInterface.eMenuOptions.Quit:
                        isUserWantToExit = true;
                        break;
                }

           
            }
        }

        private void changeVehicleStatus()
        {
            string vehicleLicensePlate = getExistInGarageVehiclePlateNumber();
            VehicleRepairRecord.eRepairStatus repairStatus = r_UserInterface.GetRepairStatusInputToFilterList();

            r_Garage.ChangeVehicleStatus(vehicleLicensePlate, repairStatus);
        }

        private string getExistInGarageVehiclePlateNumber()
        {
            string vehicleLicensePlate = r_UserInterface.GetLicensePlateInputFromUser();
            const bool v_VehicleIsExistInGarage = true;

            while (!r_Garage.IsVehicleExist(vehicleLicensePlate))
            {
                r_UserInterface.PrintVehicleExistence(vehicleLicensePlate, !v_VehicleIsExistInGarage);
                vehicleLicensePlate = r_UserInterface.GetLicensePlateInputFromUser();
            }

            return vehicleLicensePlate;
        }
        private void showVehicleListInGarageFilterByStatus()
        {
            VehicleRepairRecord.eRepairStatus repairStatus = r_UserInterface.GetRepairStatusInputToFilterList();
            List<string> vehicleListInGarage = r_Garage.GetVehiclePlateNumberListFilterByState(repairStatus);
            r_UserInterface.PrintAllElementsInArray(vehicleListInGarage);
        }

        private void enterVehicleToGarage()
        {
            string vehicleLicensePlate = r_UserInterface.GetLicensePlateInputFromUser();
            const bool v_VehicleIsExistInGarage = true;

            if (r_Garage.IsVehicleExist(vehicleLicensePlate))
            {
                r_UserInterface.PrintVehicleExistence(vehicleLicensePlate, v_VehicleIsExistInGarage);
            }
            else
            {
                //TODO: complete with vehicleFactory
            }



        }
       
        

 
 
    }
}
