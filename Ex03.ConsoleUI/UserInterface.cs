using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UserInterface
    {
        private const string k_InvalidInputMsg = "The input you entered is invalid. Please try again: ";
        private const float k_MinutesInHour = 60f;

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

        private enum eBooleanValue
        {
            False = 0,
            True 
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
###################################################
");
        }

        private static string addSpacesToCamelCaseWord(string i_InputCamelCaseWords)
        {
            string result;
            StringBuilder outputStringBuilder;

            if (string.IsNullOrEmpty(i_InputCamelCaseWords))
            {
                result = i_InputCamelCaseWords;
            }
            else
            {
                outputStringBuilder = new StringBuilder();
                outputStringBuilder.Append(i_InputCamelCaseWords[0]);
                for (int i = 1; i < i_InputCamelCaseWords.Length; i++)
                {
                    if (char.IsUpper(i_InputCamelCaseWords[i]) && (i + 1 < i_InputCamelCaseWords.Length && !char.IsUpper(i_InputCamelCaseWords[i + 1])))
                    {
                        outputStringBuilder.Append(' ');
                    }

                    outputStringBuilder.Append(i_InputCamelCaseWords[i]);
                }

                result = outputStringBuilder.ToString();
            }

            return result;
        }

        public eMenuOptions GetAndCheckUserInputForMenuItem()
        {
            int userInput = getValidIntegerInRange((int)eMenuOptions.EnterVehicleToGarage, (int)eMenuOptions.Quit, "menu option", typeof(eMenuOptions));

            return (eMenuOptions)userInput;
        }

        public void PrintVehicleExistence(string i_LicensePlate, bool i_IsExist)
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
            Console.Write("Please enter license plate to the desire vehicle: ");

            return Console.ReadLine();
        }

        public void PrintException(Exception i_Exception)
        {
            Console.WriteLine(i_Exception.Message);
        }

        private int getValidIntegerInRange(int i_MinValue, int i_MaxValue, string i_ObjectName, Type i_ObjectType)
        {
            bool inputIsValid = false;
            int userInput = 0;

            Console.Write($"Please select a {i_ObjectName} between {i_MinValue} and {i_MaxValue}: ");
            while (!inputIsValid)
            {
                inputIsValid = int.TryParse(Console.ReadLine(), out userInput);
                if(inputIsValid)
                {
                    if (i_ObjectType.IsEnum)
                    {
                        inputIsValid = Enum.IsDefined(i_ObjectType, userInput);
                    }
                    else
                    {
                        inputIsValid = userInput >= i_MinValue && userInput <= i_MaxValue;
                    }
                }

                if(!inputIsValid)
                {
                    Console.Write(k_InvalidInputMsg);
                }
            }

            return userInput;
        }

        private float getValidFloatInputInRange(float i_MinValue, float i_MaxValue, string i_ObjectName, string i_Unit)
        {
            bool inputIsInvalid = true;
            float userInput = 0f;

            Console.Write($"Please select a float number of {i_ObjectName} between {i_MinValue} and {i_MaxValue} in {i_Unit}: ");
            while (inputIsInvalid)
            {
                inputIsInvalid = !float.TryParse(Console.ReadLine(), out userInput)
                                 || (userInput < i_MinValue || userInput > i_MaxValue);
                if (inputIsInvalid)
                {
                    Console.Write(k_InvalidInputMsg);
                }
            }

            return userInput;
        }

        public bool GetUserInputIfWantFilteredVehicleList()
        {
            int userInput = getValidEnumInputFromUser(typeof(eIsFiltered), "filter option");

            return (eIsFiltered)userInput == eIsFiltered.Filtered;
        }
        
        public VehicleRepairRecord.eRepairStatus GetRepairStatusInput()
        {
            int userInput = getValidEnumInputFromUser(typeof(VehicleRepairRecord.eRepairStatus), "repair status");

            return (VehicleRepairRecord.eRepairStatus)userInput;
        }

        public void PrintAllElementsInArray<T>(List<T> i_ElementArray)
        {
            if(i_ElementArray == null || i_ElementArray.Count == 0)
            {
                Console.WriteLine("No Element to print.");
            }
            else
            {
                foreach (T element in i_ElementArray)
                {
                    Console.WriteLine(element.ToString());
                }
            }
        }

        private Fuel.eType getValidFuelTypeFromUser()
        {
            int userInput = getValidEnumInputFromUser(typeof(Fuel.eType), "fuel type");

            return (Fuel.eType)userInput;
        }

        private int getValidEnumInputFromUser(Type i_EnumType, string i_ObjectName)
        {
            int userInput;
            Array enumValues;
            int minValue, maxValue;

            if (!i_EnumType.IsEnum)
            {
                throw new ArgumentException("type is not enum type");
            }

             enumValues = Enum.GetValues(i_EnumType);
             minValue = (int)enumValues.GetValue(enumValues.GetLowerBound(0));
             maxValue = (int)enumValues.GetValue(enumValues.GetUpperBound(0));
             for (int i = 0; i < enumValues.Length; i++)
            {
                Console.WriteLine($"{(int)enumValues.GetValue(i)}. {addSpacesToCamelCaseWord(enumValues.GetValue(i).ToString())}");
            }

            userInput = getValidIntegerInRange(minValue, maxValue, i_ObjectName, i_EnumType);

            return userInput;
        }

        private float getValidFloatNumberInputFromUser(string i_InstructionMessage)
        {
            float userInput;

            Console.Write(i_InstructionMessage + ": ");
            while(!float.TryParse(Console.ReadLine(), out userInput))
            {
                Console.Write(k_InvalidInputMsg);
            }

            return userInput;
        }

        public float GetInitialEnergyAmount(float i_MaxEnergy, string i_ObjectType, string i_Unit)
        {
            return getValidFloatInputInRange(0, i_MaxEnergy, i_ObjectType, i_Unit);
        }

        public void GetFuelTypeAndAmountToFill(out Fuel.eType o_FuelType, out float o_FuelAmountToAdd)
        {
            o_FuelAmountToAdd = getValidFloatNumberInputFromUser("Please enter the amount of fuel(liters) to add the vehicle");
            o_FuelType = getValidFuelTypeFromUser();
        }

        public void GetElectricAmountToCharge(out float o_ElectricAmountToAdd)
        {
            o_ElectricAmountToAdd =
                getValidFloatNumberInputFromUser("Please enter the amount of minutes to charge the vehicle") / k_MinutesInHour;
        }

        public string GetInputStringFromUser(string i_Name, bool i_AllowNumbersInString, bool i_AllowLettersInString)
        {
                bool isValidInput = false;
                string userInput, inputType;

                if(i_AllowNumbersInString && !i_AllowLettersInString)
                {
                    inputType = "digits only";
                }
                else if(!i_AllowNumbersInString && i_AllowLettersInString)
                {
                    inputType = "letters only";
                }
                else
                {
                    inputType = "digits and letters";
                }
                
                Console.Write($"please enter {i_Name} for the vehicle({inputType} allow): ");
                userInput = Console.ReadLine();
                while(!isValidInput)
                {
                    isValidInput = true;
                    for(int i = 0; userInput != null && i < userInput.Length && isValidInput; i++)
                    {
                        isValidInput = (i_AllowLettersInString && char.IsLetter(userInput[i])) 
                                       || (i_AllowNumbersInString && char.IsDigit(userInput[i]))
                                       || (i_AllowLettersInString && char.IsWhiteSpace(userInput[i]));
                    }

                    if(!isValidInput)
                    {
                        Console.Write(k_InvalidInputMsg);
                        userInput = Console.ReadLine();
                    }
                }

                return userInput;
        }

        public VehicleFactory.eAvailableVehicle GetVehicleTypeInputFromUser()
        {
            int userInput = getValidEnumInputFromUser(typeof(VehicleFactory.eAvailableVehicle), "vehicle type");

            return (VehicleFactory.eAvailableVehicle)userInput;
        }

        public List<ParameterWrapper> SetPropertiesForVehicle(Vehicle i_Vehicle)
        {
            List<ParameterWrapper> vehicleProprietyList = i_Vehicle.GetUniquePropertiesDataForVehicle();

            foreach (ParameterWrapper parameter in vehicleProprietyList)
            {
                if(parameter.Type.IsEnum)
                {
                    parameter.Value = getValidEnumInputFromUser(parameter.Type, parameter.Name);
                }
                else if(parameter.Type == typeof(int))
                {
                    parameter.Value = getValidIntegerInRange(0, int.MaxValue, parameter.Name, typeof(int));
                }
                else if (parameter.Type == typeof(float))
                {
                    parameter.Value = getValidFloatNumberInputFromUser($"Please enter float number of {parameter.Name}");
                }
                else if (parameter.Type == typeof(bool))
                {
                    parameter.Value = (eBooleanValue)getValidEnumInputFromUser(typeof(eBooleanValue), parameter.Name)
                                       == eBooleanValue.True;
                }
            }

            return vehicleProprietyList;
        }

        public float GetAirPressureInput(float i_MaxWheelPressureAllow)
        {
            float airPressureInput =
                getValidFloatNumberInputFromUser($"Please enter the amount of air pressure to inflate the tires in vehicle (0-{i_MaxWheelPressureAllow})");

            return airPressureInput;
        }

        public void PrintMassage(string i_Massage)
        {
            Console.WriteLine(i_Massage);
        }
    }
}
