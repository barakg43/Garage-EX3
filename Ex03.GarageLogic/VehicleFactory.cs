﻿using System;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        public enum eAvailableVehicle 
        {
            FuelBike = 1,
            ElectricBike,
            FuelCar,
            ElectricCar,
            Truck,
        }

        public static Vehicle CreateVehicle(eAvailableVehicle i_VehicleType, string i_ModelName, string i_LicensePlate, string i_WheelManufacturer)
        {
            Vehicle vehicle;

            switch(i_VehicleType)
            {
                case eAvailableVehicle.FuelBike:
                    vehicle = new Motorcycle(EnergySource.eEnergyType.Fuel, i_ModelName, i_LicensePlate, i_WheelManufacturer);
                    break;
                case eAvailableVehicle.ElectricBike:
                    vehicle = new Motorcycle(EnergySource.eEnergyType.Electric, i_ModelName, i_LicensePlate, i_WheelManufacturer);
                    break;
                case eAvailableVehicle.FuelCar:
                    vehicle = new Car(EnergySource.eEnergyType.Fuel, i_ModelName, i_LicensePlate, i_WheelManufacturer);
                    break;
                case eAvailableVehicle.ElectricCar:
                    vehicle = new Car(EnergySource.eEnergyType.Electric, i_ModelName, i_LicensePlate, i_WheelManufacturer);
                    break;
                case eAvailableVehicle.Truck:
                    vehicle = new Truck(EnergySource.eEnergyType.Fuel, i_ModelName, i_LicensePlate, i_WheelManufacturer);
                    break;
                default:
                    throw new ArgumentException($"Factory NOT implemented building a {i_VehicleType} vehicle");
            }

            return vehicle;
        }
    }
}
