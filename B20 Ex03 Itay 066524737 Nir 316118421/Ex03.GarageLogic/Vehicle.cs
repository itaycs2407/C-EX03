using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_Model;
        // LPN  = License Plate Number
        private string m_LPN;
        private List<Wheel> wheels;
        private string m_OwnerName; 
        private string m_OwnerPhoneNumber; 
        private Energy energy;
        private eVehicleState vehicleState;

        public string Model { get => m_Model; set => m_Model = value; }
        public string LPN { get => m_LPN; set => m_LPN = value; }
        internal List<Wheel> Wheels { get => wheels; set => wheels = value; }
        public string OwnerName { get => m_OwnerName; set => m_OwnerName = value; }
        public string OwnerPhoneNumber { get => m_OwnerPhoneNumber; set => m_OwnerPhoneNumber = value; }
        public eVehicleState VehicleState { get => vehicleState; set => vehicleState = value; }
        public Energy Energy { get => energy; set => energy = value; }

        public override abstract string ToString();

        public Vehicle(string i_LPN ,string i_Model,  string i_OwnerName, string i_OwnerPhoneNumber)
        {
            LPN = i_LPN;
            OwnerName = i_OwnerName;
            OwnerPhoneNumber = i_OwnerPhoneNumber;
            Model = i_Model;
        }

        public void FillEnergy(float i_AmountToFill)
        {
            Energy.FillEnergy(i_AmountToFill);
        }

        public virtual void FillAirToMaxPressure()
        {
            foreach (Wheel wheel in Wheels)
            {
                if(wheel.CurrentAirPressure < wheel.ManufactureRecommendedAirPressure)
                {
                    wheel.FillAirPressure(wheel.ManufactureRecommendedAirPressure - wheel.CurrentAirPressure);
                }
            }
        }

        //CR :: check guys coding standarts..
        protected  string GetGeneralDetails()
        {
            // add energy details 
            string seperator = "================= GENERAL =======================";
            return string.Format("\n{0} \nOwner Name : {1}\nOwner Phone : {2} \nVehicle LPN : {3} \nVehicle model : {4} \nVehicle state : {5} \n{6}\n{7} ", seperator, this.m_OwnerName, this.m_OwnerPhoneNumber, this.m_LPN, this.m_Model,this.VehicleState,  Wheels[0].ToString(),this.energy.ToString());
        }
    }
}
