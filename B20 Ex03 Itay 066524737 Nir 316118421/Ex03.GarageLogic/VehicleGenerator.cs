using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class VehicleGenerator
    {
        public const float k_MotorFuelTank = 7;
        public const float k_MotorElectricCapacity = 1.2f;
        public const float k_CarFuelTank = 60;
        public const float k_CarElectricCapacity = 2.1f;
        public const float k_TruckFuelTank = 120;
        private const int k_CarNumberOfWheels = 4;
        private const int k_MotorcycleNumberOfWheels = 2;
        private const int k_TruckNumberOfWheels = 16;
        private List<Vehicle> m_VehicleList = new List<Vehicle>();

        public List<Vehicle> VehicleList { get => m_VehicleList; set => m_VehicleList = value; }

        public Vehicle GetVehicleByLPN(string i_LPN)
        {
            Vehicle vehicleToReturn  = null;
            int i;
            for (i = 0; i < m_VehicleList.Count; i++)
            {
                if (m_VehicleList[i].LPN == i_LPN)
                {
                    vehicleToReturn = m_VehicleList[i];
                    break;
                }
            }

            return vehicleToReturn;
        }

        private void addNewVehicle(Vehicle i_Vehicle)
        {
            VehicleList.Add(i_Vehicle);
        }

        public void AddNewCar(float i_CurrentPressure, string i_OwnerName, string i_OwnerPhoneNumber, string i_LPN, string i_Model, float i_AmountOfEnergy, string i_ManufactureName, eEnergyType i_EnergyType, eVehicleColor i_Color, eDoors i_Doors, eFuelType i_FuleType = eFuelType.None)
        {
            if (i_EnergyType == eEnergyType.Electric && i_FuleType != eFuelType.None)
            {
                throw new ArgumentException();
            }

            Car newCar = new Car(i_OwnerName, i_OwnerPhoneNumber, i_LPN, i_Model, i_Color, i_Doors);
            float EnergyCapacity = i_EnergyType == eEnergyType.Electric ? (float) k_CarElectricCapacity : k_CarFuelTank;
            initializeVehicleProps(newCar, i_EnergyType, EnergyCapacity, i_AmountOfEnergy, i_CurrentPressure, i_ManufactureName, k_CarNumberOfWheels, Car.k_ManufactureMaxPressure, i_FuleType);
        }

        public void AddNewMotor(float i_CurrentPressure, string i_OwnerName, string i_OwnerPhoneNumber, string i_LPN, string i_Model, float i_AmountOfEnergy, string i_ManufactureName, eLicense i_License, int i_EngineVolume, eEnergyType i_EnergyType,  eFuelType i_FuleType = eFuelType.None)
        {
            if (i_EnergyType == eEnergyType.Electric && i_FuleType != eFuelType.None)
            {
                throw new ArgumentException();
            }

            MotorCycle newMotor = new MotorCycle(i_OwnerName, i_OwnerPhoneNumber, i_LPN, i_Model, i_License, i_EngineVolume);
            float EnergyCapacity = i_EnergyType == eEnergyType.Electric ? (float)k_MotorElectricCapacity : k_MotorFuelTank;
            initializeVehicleProps(newMotor, i_EnergyType, EnergyCapacity, i_AmountOfEnergy, i_CurrentPressure, i_ManufactureName, k_MotorcycleNumberOfWheels, MotorCycle.k_ManufactureMaxPressure, i_FuleType);
        }

        public void AddNewTruck(float i_CurrentPressure, string i_OwnerName, string i_OwnerPhoneNumber, string i_LPN, string i_Model, float i_AmountOfEnergy, float i_CargoVolume, bool i_IsDangerousMaterials, string i_ManufactureName)
        {
            Truck newTruck = new Truck(i_OwnerName, i_OwnerPhoneNumber, i_LPN, i_Model, i_CargoVolume, i_IsDangerousMaterials);
            initializeVehicleProps(newTruck, eEnergyType.Fueled, k_TruckFuelTank, i_AmountOfEnergy, i_CurrentPressure, i_ManufactureName, k_TruckNumberOfWheels, Truck.k_ManufactureMaxPressure, eFuelType.Soler);
        }

        private void initializeVehicleProps(Vehicle i_NewVehicle, eEnergyType i_EnergyType, float i_TruckFuelTank, float i_AmountOfEnergy, float i_CurrentPressure, string i_ManufactureName, int i_TruckNumberOfWheels, float i_ManufactureMaxPressure, eFuelType i_FuelType = eFuelType.None)
        {
            i_NewVehicle.VehicleState = eVehicleState.OnRepair;
            i_NewVehicle.Energy = new Energy(i_EnergyType, i_FuelType, i_TruckFuelTank, i_AmountOfEnergy);
            i_NewVehicle.Wheels = addWheelsByNumber(i_TruckNumberOfWheels, i_ManufactureMaxPressure, i_CurrentPressure, i_ManufactureName);
            addNewVehicle(i_NewVehicle);
        }

        private List<Wheel> addWheelsByNumber(int i_NumberOfWheels, float i_MaxManufacturePressure, float i_CurrentPresure, string i_ManufactureName)
        {
            int i;
            List<Wheel> ListToReturn = new List<Wheel>();
            for (i = 0; i < i_NumberOfWheels; i++)
            {
                if (i_MaxManufacturePressure >= i_CurrentPresure)
                {
                    ListToReturn.Add(new Wheel(i_ManufactureName, i_CurrentPresure, i_MaxManufacturePressure));
                }
                else
                {
                    throw new ValueOutOfRangeException();
                }
            }

            return ListToReturn;
        }
    }
}
