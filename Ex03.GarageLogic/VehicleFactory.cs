using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{

    public class VehicleFactory
    {
        public enum eAvailableVehicle 
        {
            FuelBike,
            ElectricBike,
            FuelCar,
            ElectricCar,
            Truck,
        }

        public static Vehicle CreateVehicle(eAvailableVehicle i_VehicleType ,string i_ModelName, string i_LicensePlate)
        {
            Vehicle vehicle=null;
            switch(i_VehicleType)
            {
                case eAvailableVehicle.FuelBike:
                    vehicle = new Motorcycle(EnergySource.eType.Fuel, i_ModelName, i_LicensePlate);
                    break;
                case eAvailableVehicle.ElectricBike:
                    vehicle = new Motorcycle(EnergySource.eType.Electric, i_ModelName, i_LicensePlate);
                    break;
                case eAvailableVehicle.FuelCar:
                    vehicle = new Car(EnergySource.eType.Fuel, i_ModelName, i_LicensePlate);
                    break;
                case eAvailableVehicle.ElectricCar:
                    vehicle = new Car(EnergySource.eType.Electric, i_ModelName, i_LicensePlate);
                    break;
                case eAvailableVehicle.Truck:
                    vehicle = new Truck(EnergySource.eType.Fuel, i_ModelName, i_LicensePlate);
                    break;
            }

            return vehicle;
        }
    }
}
