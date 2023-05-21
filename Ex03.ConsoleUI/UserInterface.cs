using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UserInterface
    {
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

        public enum eIsFiltered
        {
            Filtered = 1,
            NotFiltered,
        }

    

        public void PrintMainMenu()
        {

            Console.Write(
@"###################################################
# 1. Enter vehicle to garage                      #
# 2. Show list of vehicles in garage              #
# 3. Change Status of a vehicle in garage         #
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

        public void PrintVehicleExistence(string i_LicensePlate,bool i_IsExist)//only relevant if car is missing
        {
            string message = i_IsExist ? "already exist" : "not exist";

            Console.WriteLine($@"Vehicle with license plate [{i_LicensePlate}] {message} in garage.");
        }

        public void PrintVehicleNotInGarage(string i_LicensePlate)
        {
            Console.WriteLine($@"Vehicle with license plate [{i_LicensePlate}] not in garage.");
        }

        public string GetLicensePlateInputFromUser()
        {
            Console.WriteLine("Please enter license plate to the desire vehicle:");
            return Console.ReadLine();
        }
    
       

        private int getValidIntegerInRange(int i_MinValue, int i_MaxValue, string i_ObjectName)
        {
            bool inputIsInvalid = true;
            int userInput = 0;

            Console.WriteLine($"Please select a {i_ObjectName} between {i_MinValue} and {i_MaxValue}");
            while (inputIsInvalid)
            {
                int.TryParse(Console.ReadLine(), out userInput);
                inputIsInvalid = !Enum.IsDefined(typeof(eMenuOptions), userInput);
                if(inputIsInvalid)
                {
                    Console.WriteLine(k_InvalidInputMsg);
                }
            }

            return userInput;
        }

        public bool GetUserInputIfWantFilteredVehicleList()
        {
            Array enumValues = Enum.GetValues(typeof(eIsFiltered));
            int minValue = (int)enumValues.GetValue(enumValues.GetLowerBound(0));
            int maxValue = (int)enumValues.GetValue(enumValues.GetUpperBound(0));

            foreach(eIsFiltered option in enumValues)
            {
                Console.WriteLine($"{(int)option}. {option}");
            }
            int userInput = getValidIntegerInRange(minValue, maxValue, "filter option");
            return (eIsFiltered)userInput == eIsFiltered.Filtered;
        }
        
        public VehicleRepairRecord.eRepairStatus GetRepairStatusInput()
        {
            Array enumValues = Enum.GetValues(typeof(eIsFiltered));
            int minValue = (int)enumValues.GetValue(enumValues.GetLowerBound(0));
            int maxValue = (int)enumValues.GetValue(enumValues.GetUpperBound(0));

            foreach(eIsFiltered option in enumValues)
            {
                Console.WriteLine($"{(int)option}. {option}");
            }
            int userInput = getValidIntegerInRange(minValue, maxValue, "filter option");
            return (eIsFiltered)userInput == eIsFiltered.Filtered;
        }
        
        public VehicleRepairRecord.eRepairStatus GetRepairStatusInput()
        {
            int userInput = getValidEnumInputFromUser(typeof(VehicleRepairRecord.eRepairStatus), "repair status");

            return (VehicleRepairRecord.eRepairStatus)userInput;
            // Array enumValues = Enum.GetValues(typeof(VehicleRepairRecord.eRepairStatus));
            // int minValue = (int)enumValues.GetValue(enumValues.GetLowerBound(0));
            // int maxValue = (int)enumValues.GetValue(enumValues.GetUpperBound(0));
            //
            // foreach (VehicleRepairRecord.eRepairStatus repairStatus in enumValues)
            // {
            //     Console.WriteLine($"{(int)repairStatus}. {repairStatus}");
            // }
            // int userInput = getValidIntegerInRange(minValue, maxValue, "repair status");
            //
            // return (VehicleRepairRecord.eRepairStatus)userInput;
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

            int userInput = getValidEnumInputFromUser(typeof(eFuelType), "fuel type");

            return (eFuelType)userInput;
            // Array enumValues = Enum.GetValues(typeof(eFuelType));
            // int minValue = (int)enumValues.GetValue(enumValues.GetLowerBound(0));
            // int maxValue = (int)enumValues.GetValue(enumValues.GetUpperBound(0));
            //
            // foreach (eFuelType fuelType in enumValues)
            // {
            //     Console.WriteLine($"{(int)fuelType}. {fuelType}");
            // }
            //
            // int userInput = getValidIntegerInRange(minValue, maxValue, "fuel type");
            //
            // return (eFuelType)userInput;
        }

        private int getValidEnumInputFromUser(Type i_EnumType,String i_ObjectName)
        {
            int userInput;

            if (!i_EnumType.IsEnum)
            {
                throw new ArgumentException("type is not enum type");
            }
            Array enumValues = Enum.GetValues(i_EnumType);
            int minValue = (int)enumValues.GetValue(enumValues.GetLowerBound(0));
            int maxValue = (int)enumValues.GetValue(enumValues.GetUpperBound(0));

            for (int i = 0; i < enumValues.Length; i++)
            {
                Console.WriteLine($"{(int)enumValues.GetValue(i)}. {enumValues.GetValue(i)}");
            }

            userInput = getValidIntegerInRange(minValue, maxValue, i_ObjectName);

            return userInput;
        }
        private float getValidFloatNumberInputFromUser(string i_InstructionMessage)
        {
            //bool isValidFloatNumber;
            float userInput;

            Console.Write(i_InstructionMessage+": ");
            /*isValidFloatNumber = float.TryParse(Console.ReadLine(), out userInput);
            while (!isValidFloatNumber)
            {
                Console.Write(k_InvalidInputMsg);
                isValidFloatNumber = float.TryParse(Console.ReadLine(), out userInput);
            }*/

            while(!float.TryParse(Console.ReadLine(), out userInput))
            {
                Console.Write(k_InvalidInputMsg);
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
