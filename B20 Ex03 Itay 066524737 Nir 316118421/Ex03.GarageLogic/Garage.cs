using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private VehicleGenerator m_VehicleGenerator = new VehicleGenerator();

        public void ReciveNewTruck(string i_OwnerName, string i_OwnerPhoneNumber, string i_LPN, string i_Model, float i_CurrentPressure, string i_ManufactureName, float i_CargoVolume, bool i_IsDangerousMaterials,  float i_AmountOfEnergy)
        {
            m_VehicleGenerator.AddNewTruck(i_CurrentPressure, i_OwnerName, i_OwnerPhoneNumber, i_LPN, i_Model,  i_AmountOfEnergy, i_CargoVolume, i_IsDangerousMaterials, i_ManufactureName);
        }

        public void ReciveNewFueledCar(string i_OwnerName, string i_OwnerPhoneNumber, string i_LPN, string i_Model, float i_CurrentPressure, string i_ManufactureName,  float i_AmountOfEnergy, eVehicleColor i_VehicleColor, eDoors i_Doors )
        {
            m_VehicleGenerator.AddNewCar(i_CurrentPressure, i_OwnerName, i_OwnerPhoneNumber, i_LPN, i_Model, i_AmountOfEnergy, i_ManufactureName, eEnergyType.Fueled, i_VehicleColor, i_Doors, eFuelType.Octan96);
        }

        public void ReciveNewElectricCar(string i_OwnerName, string i_OwnerPhoneNumber, string i_LPN, string i_Model, float i_CurrentPressure, string i_ManufactureName, float i_AmountOfEnergy, eVehicleColor i_VehicleColor, eDoors i_Doors)
        {
            m_VehicleGenerator.AddNewCar(i_CurrentPressure, i_OwnerName, i_OwnerPhoneNumber, i_LPN, i_Model, i_AmountOfEnergy, i_ManufactureName, eEnergyType.Electric, i_VehicleColor, i_Doors);
        }

        public void ReciveNewElectricMotorcycle(string i_OwnerName, string i_OwnerPhoneNumber, string i_LPN, string i_Model, float i_CurrentPressure, string i_ManufactureName, float i_AmountOfEnergy, eLicense i_License, int i_EngineVolume)
        {
            m_VehicleGenerator.AddNewMotor(i_CurrentPressure, i_OwnerName, i_OwnerPhoneNumber, i_LPN, i_Model, i_AmountOfEnergy, i_ManufactureName, i_License, i_EngineVolume, eEnergyType.Electric);
        }

        public void ReciveNewFueledMotorcycle(string i_OwnerName, string i_OwnerPhoneNumber, string i_LPN, string i_Model, float i_CurrentPressure, string i_ManufactureName, float i_AmountOfEnergy, eLicense i_License, int i_EngineVolume)
        {
            m_VehicleGenerator.AddNewMotor(i_CurrentPressure, i_OwnerName, i_OwnerPhoneNumber, i_LPN, i_Model, i_AmountOfEnergy, i_ManufactureName, i_License, i_EngineVolume, eEnergyType.Fueled, eFuelType.Octan95);
        }

        public bool IsLPNExistInGarage(string m_LPN)
        {
            return m_VehicleGenerator.GetVehicleByLPN(m_LPN) != null;
        }

        public List<string> GetAllVehicleLPNByState(eVehicleState i_State)
        {
            List<string> LPNList = new List<string>();
            foreach(Vehicle vehicle in m_VehicleGenerator.VehicleList)
            {
                if (vehicle.VehicleState == i_State)
                {
                    LPNList.Add(vehicle.LPN);
                }
            }

            return LPNList;
        }

        public List<string> GetAllVehicleLPN()
        {
            List<string> LPNList = new List<string>();
            foreach (Vehicle vehicle in m_VehicleGenerator.VehicleList)
            {
                LPNList.Add(vehicle.LPN);
            }

            return LPNList;
        }

        public bool IsValidEnergyCapacity(float i_CurrentAmountOfEnergy)
        {
            return i_CurrentAmountOfEnergy <= 1;
        }

        public List<string> GetAllVehicleLPN(eEnergyType i_EnergyType)
        {
            List<string> LPNList = new List<string>();
            foreach (Vehicle vehicle in m_VehicleGenerator.VehicleList)
            {
                if (vehicle.Energy.Type.Equals(i_EnergyType))
                {
                    LPNList.Add(vehicle.LPN);
                }
            }

            return LPNList;
        }

        public void ChangeVehicleState(string i_LPN, eVehicleState i_NewState)
        {
            Vehicle vehicleToChangeTheState = m_VehicleGenerator.GetVehicleByLPN(i_LPN);
            
            if (vehicleToChangeTheState != null)
            {
                vehicleToChangeTheState.VehicleState = i_NewState;
            }
        }
              
        public Vehicle GetVehicleForDetails(string i_LPN)
        {
            return m_VehicleGenerator.GetVehicleByLPN(i_LPN);
        }

        public bool IsValidWheelPressureForCar(float m_CurrentAirPressure)
        {
            return m_CurrentAirPressure <= Car.k_ManufactureMaxPressure;
        }

        public bool IsValidWheelPressureForMotor(float i_CurrentAirPressure)
        {
            return i_CurrentAirPressure <= MotorCycle.k_ManufactureMaxPressure;
        }

        public bool IsValidWheelPressureForTruck(float i_CurrentAirPressure)
        {
            return i_CurrentAirPressure <= Truck.k_ManufactureMaxPressure;
        }
    }
}
