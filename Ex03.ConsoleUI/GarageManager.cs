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
                    r_UserInterface.PrintException(e);
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
                VehicleRepairRecord.eRepairStatus repairStatus = r_UserInterface.GetRepairStatusInput();
                r_Garage.ChangeVehicleStatus(licensePlate, repairStatus);
            }
        }

        private void changeVehicleStatus()
        {
            string vehicleLicensePlate = getExistInGarageVehiclePlateNumber();
            VehicleRepairRecord.eRepairStatus repairStatus = r_UserInterface.GetRepairStatusInput();

            r_Garage.ChangeVehicleStatus(vehicleLicensePlate, repairStatus);
        }

        private bool getLicensePlateIfVehicleInGarage(out string o_LicensePlate)
        {
            bool vehicleInGarage;

            o_LicensePlate = r_UserInterface.GetLicensePlateInputFromUser();
            vehicleInGarage = r_Garage.IsVehicleExist(o_LicensePlate);
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
            bool isFiltered = r_UserInterface.GetUserInputIfWantFilteredVehicleList();
            VehicleRepairRecord.eRepairStatus repairStatus = VehicleRepairRecord.eRepairStatus.InRepair;
            if (isFiltered)
            {
                repairStatus = r_UserInterface.GetRepairStatusInput();
            }

            List<string> vehicleListInGarage = r_Garage.GetVehiclePlateNumberListFilterByState(repairStatus, isFiltered);
            r_UserInterface.PrintAllElementsInArray(vehicleListInGarage);
        }

        private void enterVehicleToGarage()
        {
            string vehicleLicensePlate = r_UserInterface.GetLicensePlateInputFromUser();
            bool isVehicleIsExistInGarage = r_Garage.IsVehicleExist(vehicleLicensePlate);
            if (isVehicleIsExistInGarage)
            {
                r_UserInterface.PrintVehicleExistence(vehicleLicensePlate, isVehicleIsExistInGarage);
            }
            else
            {
                createNewVehicle(vehicleLicensePlate);
            }
        }


        private void createNewVehicle(string i_LicensePlate)
        {
            VehicleFactory.eAvailableVehicle vehicleType = r_UserInterface.GetVehicleTypeInputFromUser();
            string modelName = r_UserInterface.GetInputStringFromUser("model name");
            string wheelManufacturer = r_UserInterface.GetInputStringFromUser("Wheel manufacturer");
            Vehicle vehicle = VehicleFactory.CreateVehicle(vehicleType, modelName, i_LicensePlate, wheelManufacturer);
            List<ParameterWrapper> proprietyList = r_UserInterface.SetProprietiesForVehicle(vehicle);

            vehicle.SetUniquePropertiesDataForVehicle(proprietyList);
        }


    }
}
