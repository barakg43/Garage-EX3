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

            r_UserInterface.PrintAllElementsInArray(allCVehicleRepairRecords);
        }

        private void chargeVehicle()
        {
            bool vehicleInGarage = getLicensePlateIfVehicleInGarage(out string licensePlate);

            if(vehicleInGarage)
            {
                r_UserInterface.GetElectricAmountToCharge(out float amountToCharge);
                try
                {
                    r_Garage.ChargeVehicleInGarage(licensePlate, amountToCharge);
                    r_UserInterface.PrintMassage($"Charged {amountToCharge:F} hours to [{licensePlate}] successfully.");
                }
                catch(Exception e)
                {
                    r_UserInterface.PrintException(e);
                }
            }
        }

        private void fuelVehicle()
        {
            bool vehicleInGarage = getLicensePlateIfVehicleInGarage(out string licensePlate);

            if(vehicleInGarage)
            {
                r_UserInterface.GetFuelTypeAndAmountToFill(out Fuel.eType fuelType, out float amountToFuel);
                try
                {
                    r_Garage.FuelVehicleInGarage(licensePlate, fuelType, amountToFuel);
                    r_UserInterface.PrintMassage($"Fueled {amountToFuel:F} of {fuelType} to [{licensePlate}] successfully.");
                }
                catch(Exception e)
                {
                    r_UserInterface.PrintException(e);
                }
            }
        }

        private void inflateAllVehicleTires()
        {
            bool vehicleInGarage = getLicensePlateIfVehicleInGarage(out string licensePlate);

            if (vehicleInGarage)
            {
                r_Garage.InflateVehicleTiresToMaxPressure(licensePlate);
                r_UserInterface.PrintMassage($"Inflate all vehicle [{licensePlate}] tires successfully.");
            }
        }

        private void changeVehicleStatusIfExists()
        {
            bool vehicleInGarage = getLicensePlateIfVehicleInGarage(out string licensePlate);
            VehicleRepairRecord.eRepairStatus newRepairStatus, oldRepairStatus;

            if (vehicleInGarage)
            {
                 newRepairStatus = r_UserInterface.GetRepairStatusInput();
                 oldRepairStatus = r_Garage.ChangeVehicleStatus(licensePlate, newRepairStatus);
                 r_UserInterface.PrintMassage($"Changed repair status from [{oldRepairStatus}] to [{newRepairStatus} successfully.");
            }
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

        private void showVehicleListInGarageFilterByStatus()
        {
            bool isFiltered = r_UserInterface.GetUserInputIfWantFilteredVehicleList();
            VehicleRepairRecord.eRepairStatus repairStatus = VehicleRepairRecord.eRepairStatus.InRepair;
            List<string> vehicleListInGarage;

            if (isFiltered)
            {
                repairStatus = r_UserInterface.GetRepairStatusInput();
            }

            vehicleListInGarage = r_Garage.GetVehiclePlateNumberListFilterByState(repairStatus, isFiltered);
            r_UserInterface.PrintAllElementsInArray(vehicleListInGarage);
        }

        private void enterVehicleToGarage()
        {
            string vehicleLicensePlate = r_UserInterface.GetLicensePlateInputFromUser();
            bool isVehicleIsExistInGarage = r_Garage.IsVehicleExist(vehicleLicensePlate);

            if (isVehicleIsExistInGarage)
            {
                r_UserInterface.PrintVehicleExistence(vehicleLicensePlate, isVehicleIsExistInGarage);
                r_UserInterface.PrintMassage($"Vehicle status set to'{VehicleRepairRecord.eRepairStatus.InRepair}'");
            }
            else
            {
                createNewVehicle(vehicleLicensePlate);
                r_UserInterface.PrintMassage($"Successfully enter new vehicle [{vehicleLicensePlate}] to Garage.");
            }
        }

        private void createNewVehicle(string i_LicensePlate)
        {
            string ownerName, ownerPhoneNumber;
            const bool v_AllowNumbersInString = true;
            const bool v_AllowLettersInString = true;
            VehicleFactory.eAvailableVehicle vehicleType = r_UserInterface.GetVehicleTypeInputFromUser();
            string modelName = r_UserInterface.GetInputStringFromUser("model name", v_AllowNumbersInString, v_AllowLettersInString);
            string wheelManufacturer = r_UserInterface.GetInputStringFromUser("Wheel manufacturer", v_AllowNumbersInString, v_AllowLettersInString);
            Vehicle vehicle = VehicleFactory.CreateVehicle(vehicleType, modelName, i_LicensePlate, wheelManufacturer);
            List<ParameterWrapper> proprietyList = r_UserInterface.SetPropertiesForVehicle(vehicle);

            vehicle.SetUniquePropertiesDataForVehicle(proprietyList);
            inflateValidAirPressure(vehicle);
            initialVehicleEnergySourceFilling(vehicle);
            ownerName = r_UserInterface.GetInputStringFromUser("Owner name", !v_AllowNumbersInString, v_AllowLettersInString);
            ownerPhoneNumber = r_UserInterface.GetInputStringFromUser("Owner phone number", v_AllowNumbersInString, !v_AllowLettersInString);
            r_Garage.AddVehicle(vehicle, ownerName, ownerPhoneNumber);
        }

        private void inflateValidAirPressure(Vehicle i_Vehicle)
        {
            float tireAirPressure = r_UserInterface.GetAirPressureInput(i_Vehicle.GetMaxWheelPressureAllow());
            bool isValidAirPressure = false;

            while(!isValidAirPressure)
            {
                try
                {
                    i_Vehicle.InflateAirPressureToAllTires(tireAirPressure);
                    isValidAirPressure = true;
                }
                catch(ValueOutOfRangeException e)
                {
                    r_UserInterface.PrintException(e);
                }

                if(!isValidAirPressure)
                {
                    tireAirPressure = r_UserInterface.GetAirPressureInput(i_Vehicle.GetMaxWheelPressureAllow());
                }
            }
        }

        private void initialVehicleEnergySourceFilling(Vehicle i_Vehicle)
        {
            float energyToFill;

            if (i_Vehicle.EnergyType == EnergySource.eEnergyType.Fuel)
            {
                energyToFill = r_UserInterface.GetInitialEnergyAmount(
                    i_Vehicle.EnergySource.MaxEnergyAmount,
                    "Fuel amount to fill",
                    "liter");
            }
            else
            {
                energyToFill = r_UserInterface.GetInitialEnergyAmount(
                    i_Vehicle.EnergySource.MaxEnergyAmount,
                    "battery amount",
                    "hours");
            }

            i_Vehicle.EnergySource.CurrentEnergyAmount = energyToFill;
        }
    }
}
