using System;
using System.Collections.Generic;
//CR ::Action:: removed unused usings..

namespace Ex03.GarageLogic
{
    public class VehicleGenerator
    {
        private List<Vehicle> m_VehicleList;

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

        public void AddNewCar(float i_CurrentPressure, string i_OwnerName, string i_OwnerPhoneNumber, string i_LPN, string i_Model, float i_AmountOfEnergy, string i_ManufactureName,eEnergyType i_EnergyType, eVehicleColor i_Color, eDoors i_Doors, Nullable<eFuelType> i_FuleType)
        {
            if (i_EnergyType == eEnergyType.Electric && i_FuleType is eFuelType)
            {
                // need to throw exception - energy type is electric but fuel type is fule
            }
            Car newCar = new Car(i_OwnerName, i_OwnerPhoneNumber, i_LPN,i_Model, i_Color, i_Doors);
            //CR ::Comment:: Why wont we set enum containting those values?
            float EnergyCapacity = i_EnergyType == eEnergyType.Electric ? (float) 2.1 : 60;
            Energy newEnergyPack = new Energy(i_EnergyType, i_FuleType, EnergyCapacity, i_AmountOfEnergy);
            newCar.VehicleState = eVehicleState.OnRepair;
            newCar.Energy = newEnergyPack;
            newCar.Wheels = addWheelsByNumber(4, Car.k_ManufactureMaxPressure, i_CurrentPressure, i_ManufactureName);
            addNewVehicle(newCar);
        }
        public void AddNewMotor(float i_CurrentPressure, string i_OwnerName, string i_OwnerPhoneNumber, string i_LPN, string i_Model, float i_AmountOfEnergy, string i_ManufactureName,eLicense i_License, int i_EngineVolume, eEnergyType i_EnergyType,  Nullable<eFuelType> i_FuleType)
        {
            if (i_EnergyType == eEnergyType.Electric && i_FuleType is eFuelType)
            {
                // need to throw exception - energy type is electric but fuel type is fule
            }
            MotorCycle newMotor = new MotorCycle(i_OwnerName, i_OwnerPhoneNumber, i_LPN, i_Model, i_License, i_EngineVolume);
            //CR ::Comment:: Why wont we set enum containting those values?
            float EnergyCapacity = i_EnergyType == eEnergyType.Electric ? (float)1.2 : 7;
            Energy newEnergyPack = new Energy(i_EnergyType, i_FuleType, EnergyCapacity, i_AmountOfEnergy);

            //TODO :: CR ::Comment:: Feels like we write duplicate lines in each viechile .. why shouldnt we move those lines in to add func / or side func?
            newMotor.VehicleState = eVehicleState.OnRepair;
            newMotor.Energy = newEnergyPack;
            newMotor.Wheels = addWheelsByNumber(2, MotorCycle.k_ManufactureMaxPressure, i_CurrentPressure, i_ManufactureName);
            addNewVehicle(newMotor);
        }
        public void AddNewTruck(float i_CurrentPressure, string i_OwnerName, string i_OwnerPhoneNumber, string i_LPN, string i_Model, float i_AmountOfEnergy, float i_CargoVolume, bool i_IsDangerousMaterials,string i_ManufactureName)
        {
            Truck newTruck = new Truck(i_OwnerName,i_OwnerPhoneNumber,i_LPN,i_Model, i_CargoVolume, i_IsDangerousMaterials);
            Energy newEnergyPack = new Energy(eEnergyType.Fueled,eFuelType.Soler, 120, i_AmountOfEnergy);
            newTruck.VehicleState = eVehicleState.OnRepair;
            newTruck.Energy = newEnergyPack;
            newTruck.Wheels =  addWheelsByNumber(16, Truck.k_ManufactureMaxPressure, i_CurrentPressure, i_ManufactureName);
            addNewVehicle(newTruck);
        }
        private List<Wheel> addWheelsByNumber(int i_NumberOfWheels, float i_MaxManufacturePressure, float i_CurrentPresure, string i_ManufactureName)
        {
            int i;
            List<Wheel> ListToReturn = new List<Wheel>();
            for (i=0;i<i_NumberOfWheels;i++)
            {
                if (i_MaxManufacturePressure >= i_CurrentPresure)
                {
                    ListToReturn.Add(new Wheel(i_ManufactureName, i_CurrentPresure, i_MaxManufacturePressure));
                }
                else
                {
                    //need to throw exception
                }
            }
            return ListToReturn;
        }
    }
}
