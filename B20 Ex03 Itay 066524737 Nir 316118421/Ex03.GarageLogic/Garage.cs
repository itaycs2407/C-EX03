using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private VehicleGenerator m_VehicleGenerator;
        public void ReciveNewVehilce(Vehicle i_Vehicle)
        {

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

        public void ChangeVehicleState(string i_LPN, eVehicleState i_NewState)
        {
            Vehicle vehicleToChangeTheState = m_VehicleGenerator.GetVehicleByLPN(i_LPN);
            
            if (vehicleToChangeTheState !=null)
            {
                vehicleToChangeTheState.VehicleState = i_NewState;
            }
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
        }
        public Vehicle GetVehicleForDetails(string i_LPN)
        {
            return m_VehicleGenerator.GetVehicleByLPN(i_LPN);
        }

    }
}
