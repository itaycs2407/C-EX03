using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_Model;

        // LPN  = License Plate Number
        private string m_LPN;
        private List<Wheel> m_Wheels;
        private string m_OwnerName; 
        private string m_OwnerPhoneNumber; 
        private Energy m_Energy;
        private eVehicleState m_VehicleState;

        public string Model { get => m_Model; set => m_Model = value; }

        public string LPN { get => m_LPN; set => m_LPN = value; }

        internal List<Wheel> Wheels { get => m_Wheels; set => m_Wheels = value; }

        public string OwnerName { get => m_OwnerName; set => m_OwnerName = value; }

        public string OwnerPhoneNumber { get => m_OwnerPhoneNumber; set => m_OwnerPhoneNumber = value; }

        public eVehicleState VehicleState { get => m_VehicleState; set => m_VehicleState = value; }

        public Energy Energy { get => m_Energy; set => m_Energy = value; }

        public override abstract string ToString();

        public Vehicle(string i_LPN, string i_OwnerName, string i_OwnerPhoneNumber, string i_Model)
        {
            LPN = i_LPN;
            OwnerName = i_OwnerName;
            OwnerPhoneNumber = i_OwnerPhoneNumber;
            Model = i_Model;
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

        protected string GetGeneralDetails()
        {
            string seperator = "================= GENERAL =======================";
            return string.Format("\n{0} \nOwner Name : {1}\nOwner Phone : {2} \nVehicle LPN : {3} \nVehicle model : {4} \nVehicle state : {5} \n{6}\n{7} ", seperator, this.m_OwnerName, this.m_OwnerPhoneNumber, this.m_LPN, this.m_Model, this.VehicleState, Wheels[0].ToString(), this.m_Energy.ToString());
        }
    }
}
