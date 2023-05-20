using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageManager
    {
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
                        //changeVehicleStatus();
                        changeVehicleStatusIfExists();
                        break;
                    case UserInterface.eMenuOptions.InflateVehicleTires:
                        inflateAllVehicleTires();
                        break;
                    case UserInterface.eMenuOptions.FuelVehicle:
                        fuelVehicle();
                        break;
                    case UserInterface.eMenuOptions.ChargeVehicle:
                        chargeVehicle();
                        break;
                    case UserInterface.eMenuOptions.ShowVehicleDetails:
                        printAllVehicleDetailsInGarage();
                        break;
                    case UserInterface.eMenuOptions.Quit:
                        isUserWantToExit = true;
                        break;
                }
            }
        }

        private void printAllVehicleDetailsInGarage()
        {
            List<VehicleRepairRecord> allCVehicleRepairRecords = r_Garage.GetAllVehicleRecords();
        }

        private void chargeVehicleIfInGarage()
        {

        }

        private void chargeVehicle()
        {
            bool vehicleInGarage = getLicensePlateIfVehicleInGarage(out string licensePlate);
            if(vehicleInGarage)
            {
                r_UserInterface.GetElectricAmountToCharge(out float amountToCharge);
                r_Garage.ChargeVehicleInGarage(licensePlate, amountToCharge);
            }
            
        }


        private void fuelVehicle()
        {
            bool vehicleInGarage = getLicensePlateIfVehicleInGarage(out string licensePlate);
            if(vehicleInGarage)
            {
                r_UserInterface.GetFuelTypeAndAmountToFill(out eFuelType fuelType, out float amountToFuel);
                try
                {
                    r_Garage.FuelVehicleInGarage(licensePlate, fuelType, amountToFuel);
                }
                catch(Exception e)
                {
                    //print exception
                }
            }
            
        }

        private void inflateAllTiresIfVehicleExits()
        {
            bool vehicleInGarage = getLicensePlateIfVehicleInGarage(out string licensePlate);
            if (vehicleInGarage)
            {
                r_Garage.InflateVehicleTiresToMaxPressure(licensePlate);
            }

        }

        private void inflateAllVehicleTires()
        {
            string vehicleLicensePlate = getExistInGarageVehiclePlateNumber();
            r_Garage.InflateVehicleTiresToMaxPressure(vehicleLicensePlate);
        }

        private void changeVehicleStatusIfExists()
        {
            bool vehicleInGarage = getLicensePlateIfVehicleInGarage(out string licensePlate);

            if(vehicleInGarage)
            {
                VehicleRepairRecord.eRepairStatus repairStatus = r_UserInterface.GetRepairStatusInputToFilterList();//different method for this?
                r_Garage.ChangeVehicleStatus(licensePlate, repairStatus);
            }
        }

        private void changeVehicleStatus()
        {
            string vehicleLicensePlate = getExistInGarageVehiclePlateNumber();
            VehicleRepairRecord.eRepairStatus repairStatus = r_UserInterface.GetRepairStatusInputToFilterList();

            r_Garage.ChangeVehicleStatus(vehicleLicensePlate, repairStatus);
        }

        private bool getLicensePlateIfVehicleInGarage(out string o_LicensePlate)
        {
            o_LicensePlate = r_UserInterface.GetLicensePlateInputFromUser();
            bool vehicleInGarage = r_Garage.IsVehicleExist(o_LicensePlate);
            if(!vehicleInGarage)
            {
                r_UserInterface.PrintVehicleNotInGarage(o_LicensePlate);
            }

            return vehicleInGarage;
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
