using System.Collections.Generic;
//CR ::Acion:: removed unused usings..

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private VehicleGenerator m_VehicleGenerator = new VehicleGenerator();


        public void ReciveNewTruck(string i_OwnerName, string i_OwnerPhoneNumber, string i_LPN, string i_Model, float i_CurrentPressure, 
            string i_ManufactureName, float i_CargoVolume, bool i_IsDangerousMaterials,  float i_AmountOfEnergy)
        {
            m_VehicleGenerator.AddNewTruck(i_CurrentPressure, i_OwnerName, i_OwnerPhoneNumber, i_LPN, i_Model,  i_AmountOfEnergy, i_CargoVolume, i_IsDangerousMaterials, i_ManufactureName);
        }
        public void ReciveNewFueledCar(string i_OwnerName, string i_OwnerPhoneNumber, string i_LPN, string i_Model, float i_CurrentPressure,
            string i_ManufactureName,  float i_AmountOfEnergy,eVehicleColor i_VehicleColor,eDoors i_Doors,eFuelType i_FuelType)
        {
            m_VehicleGenerator.AddNewCar(i_CurrentPressure, i_OwnerName, i_OwnerPhoneNumber, i_LPN, i_Model, i_AmountOfEnergy, i_ManufactureName,eEnergyType.Fueled, i_VehicleColor, i_Doors,i_FuelType);
        }
        public void ReciveNewElectricCar(string i_OwnerName, string i_OwnerPhoneNumber, string i_LPN, string i_Model, float i_CurrentPressure,
            string i_ManufactureName, float i_AmountOfEnergy, eVehicleColor i_VehicleColor, eDoors i_Doors)
        {
            m_VehicleGenerator.AddNewCar(i_CurrentPressure, i_OwnerName, i_OwnerPhoneNumber, i_LPN, i_Model, i_AmountOfEnergy, i_ManufactureName, eEnergyType.Electric, i_VehicleColor, i_Doors, null);
        }
        public void ReciveNewFueledMotorcycle(string i_OwnerName, string i_OwnerPhoneNumber, string i_LPN, string i_Model, float i_CurrentPressure,
            string i_ManufactureName, float i_AmountOfEnergy, eLicense i_License, int i_EngineVolume, eFuelType i_FuelType)
        {
            m_VehicleGenerator.AddNewMotor(i_CurrentPressure, i_OwnerName, i_OwnerPhoneNumber, i_LPN, i_Model, i_AmountOfEnergy, i_ManufactureName, i_License, i_EngineVolume, eEnergyType.Fueled, i_FuelType);
        }
        public void ReciveNewElectricMotorcycle(string i_OwnerName, string i_OwnerPhoneNumber, string i_LPN, string i_Model, float i_CurrentPressure,
            string i_ManufactureName, float i_AmountOfEnergy, eLicense i_License, int i_EngineVolume)
        {
            m_VehicleGenerator.AddNewMotor(i_CurrentPressure, i_OwnerName, i_OwnerPhoneNumber, i_LPN, i_Model, i_AmountOfEnergy, i_ManufactureName,i_License,i_EngineVolume,eEnergyType.Electric, null);
        }

        // check how to define list as a memeber like guys wants......
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
            
            if (vehicleToChangeTheState !=null)
            {
                vehicleToChangeTheState.VehicleState = i_NewState;
            }
            //CR ::Comment:: Guess an exception is needed
        }
        public void ChargeElectricVehicle(string i_LPN, int  i_MinutesToCharge)
        {
            Vehicle vehicleToCharge = m_VehicleGenerator.GetVehicleByLPN(i_LPN);
            if (vehicleToCharge != null)
            {
                if (vehicleToCharge.Energy.Type == eEnergyType.Electric)
                {
                    vehicleToCharge.Energy.CurrentEnergy = vehicleToCharge.Energy.CurrentEnergy + i_MinutesToCharge <= vehicleToCharge.Energy.MaxEnergy ?
                        vehicleToCharge.Energy.CurrentEnergy + i_MinutesToCharge : vehicleToCharge.Energy.CurrentEnergy;
                }
            } // need to thorw exception.
        }
        public void FillFuledVehicle(string i_LPN, eFuelType i_FuelType, float i_AmountToFill)
        {
            Vehicle vehicleToFuel = m_VehicleGenerator.GetVehicleByLPN(i_LPN);
            if (vehicleToFuel != null)
            {
                if (vehicleToFuel.Energy.Type == eEnergyType.Fueled && vehicleToFuel.Energy.FuelType == i_FuelType)
                {
                    vehicleToFuel.Energy.CurrentEnergy = vehicleToFuel.Energy.CurrentEnergy + i_AmountToFill <= vehicleToFuel.Energy.MaxEnergy ?
                        vehicleToFuel.Energy.CurrentEnergy + i_AmountToFill : vehicleToFuel.Energy.CurrentEnergy;
                }
            } // need to throw exception    
        }
        public void FillAllWheelsToMaxPressure(string i_LPN)
        {
            Vehicle vehicleToFillWheels = m_VehicleGenerator.GetVehicleByLPN(i_LPN);
            if (vehicleToFillWheels != null)
            {
                foreach(Wheel wheel in vehicleToFillWheels.Wheels)
                {
                    wheel.CurrentAirPressure = wheel.ManufactureRecommendedAirPressure;
                }
            }
            //CR ::Comment:: Guess an exception is needed
        }
        public Vehicle GetVehicleForDetails(string i_LPN)
        {
            return m_VehicleGenerator.GetVehicleByLPN(i_LPN);
        }

    }
}
