using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UserInterface
    {
        private const char k_Quit = 'Q';
        private const string k_InvalidInputMsg = "The input you entered is invalid. Please try again: ";

        public enum eMenuOptions
        {
            EnterVehicleToGarage = 1,
            ShowVehicleInGarageByStatus,
            ChangeVehicleStatusInGarage,
            InflateVehicleTires,
            FuelVehicle,
            ChargeVehicle,
            ShowVehicleDetails,
            Quit,
        }

    

        public void PrintMainMenu()
        {

            Console.Write(
@"###################################################
# 1. Enter vehicle to garage                      #
# 2. Start game against another player            #
# 3. Print vehicle list in the garage             #
# 4. Inflate all vehicle tire to maximum pressure #
# 5. Fuel the vehicle                             #
# 6. Charge the vehicle                           #
# 7. Print all vehicle details                    #
# 8. Quit                                         #
###################################################");
        }




        public eMenuOptions GetAndCheckUserInputForMenuItem()
        {
            int userInput = getValidIntegerInRange((int)eMenuOptions.EnterVehicleToGarage, (int)eMenuOptions.Quit,"menu option");
            return (eMenuOptions)userInput;
        }

        public void PrintVehicleExistence(string i_LicensePlate,bool i_IsExist)
        {
            string massage = i_IsExist ? "already exist" : "not exist";

            Console.WriteLine($@"Vehicle with license plate [{i_LicensePlate}] {massage} in garage.");
        }
        public string GetLicensePlateInputFromUser()
        {
            Console.WriteLine("Please enter license plate to the desire vehicle:");
            return Console.ReadLine();
        }
    
       

        private int getValidIntegerInRange(int i_MinValue, int i_MaxValue, string i_ObjectName)
        {
            bool inputIsInvalid = true,isIntegerNumber;
            int userInput = 0;

            Console.WriteLine($"Please select a {i_ObjectName} between {i_MinValue} and {i_MaxValue}");
            while (inputIsInvalid)
            {
                isIntegerNumber= int.TryParse(Console.ReadLine(), out userInput);
                inputIsInvalid = !isIntegerNumber || userInput < i_MinValue || userInput > i_MaxValue;
                if(inputIsInvalid)
                {
                    Console.WriteLine(k_InvalidInputMsg);
                }
            }

            return userInput;
        }

        
        public VehicleRepairRecord.eRepairStatus GetRepairStatusInputToFilterList()
        {
            int userInput;
            Array enumValues = Enum.GetValues(typeof(VehicleRepairRecord.eRepairStatus));
            int minValue = (int)enumValues.GetValue(enumValues.GetLowerBound(0));
            int maxValue = (int)enumValues.GetValue(enumValues.GetUpperBound(0));

            foreach (VehicleRepairRecord.eRepairStatus repairStatus in enumValues)
            {
                Console.WriteLine($"{(int)repairStatus}. {repairStatus}");
            }
            userInput = getValidIntegerInRange(minValue, maxValue, "repair status");

            return (VehicleRepairRecord.eRepairStatus)userInput;
        }
        public void PrintAllElementsInArray<T>(List<T> i_ElementArray)
        {
            foreach(T element in i_ElementArray)
            {
                Console.WriteLine(element.ToString());
            }
        }

        private eFuelType getValidFuelTypeFromUser()
        {
            int userInput;
            Array enumValues = Enum.GetValues(typeof(eFuelType));
            int minValue = (int)enumValues.GetValue(enumValues.GetLowerBound(0));
            int maxValue = (int)enumValues.GetValue(enumValues.GetUpperBound(0));

            foreach (eFuelType fuelType in enumValues)
            {
                Console.WriteLine($"{(int)fuelType}. {fuelType}");
            }

            userInput = getValidIntegerInRange(minValue, maxValue, "fuel type");

            return (eFuelType)userInput;
        }

        private float getValidFloatNumberInputFromUser(string i_InstructionMessage)
        {
            bool isValidFuelNumber;
            float userInput;

            Console.Write(i_InstructionMessage+": ");
            isValidFuelNumber = float.TryParse(Console.ReadLine(), out userInput);
            while (!isValidFuelNumber)
            {
                Console.Write(k_InvalidInputMsg);
                isValidFuelNumber = float.TryParse(Console.ReadLine(), out userInput);
            }

            return userInput;
        }
        public void GetFuelTypeAndAmountToFill(out eFuelType o_FuelType, out float o_FuelAmountToAdd)
        {

            o_FuelAmountToAdd = getValidFloatNumberInputFromUser("Please enter the amount of fuel to add the vehicle");
            o_FuelType = getValidFuelTypeFromUser();
          
        }

        public void GetElectricAmountToCharge(out float o_ElectricAmountToAdd)
        {
            o_ElectricAmountToAdd =
                getValidFloatNumberInputFromUser("Please enter the amount of electric to charge the vehicle");
        }
    }

}
