using System.Collections.Generic;
//CR ::Action:: removed unused usings..

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string model;
        // LPN  = License Plate Number
        private string lPN;
        private List<Wheel> wheels;
        private string ownerName; //CR::Comment:: Is needed?
        private string ownerPhoneNumber; //CR:: Comment:: Is Needed?
        private Energy energy;
        private eVehicleState vehicleState; // Here?

        public string Model { get => model; set => model = value; }
        public string LPN { get => lPN; set => lPN = value; }
        internal List<Wheel> Wheels { get => wheels; set => wheels = value; }
        public string OwnerName { get => ownerName; set => ownerName = value; }
        public string OwnerPhoneNumber { get => ownerPhoneNumber; set => ownerPhoneNumber = value; }
        public eVehicleState VehicleState { get => vehicleState; set => vehicleState = value; }
        public Energy Energy { get => energy; set => energy = value; }

        //CR ::Action:: Since threres no need of cars owner name - added default value
        public Vehicle(string i_LPN, string i_Model,  string i_OwnerName = "", string i_OwnerPhoneNumber = "")
        {
            LPN = i_LPN;
            OwnerName = i_OwnerName;
            OwnerPhoneNumber = i_OwnerPhoneNumber;
            Model = i_Model;
        }

        //public abstract void FillEnergy(float i_AmountToFill);

        //CR ::Action:: added base class implentation .. 
        public virtual void FillEnergy(float i_AmountToFill)
        {
            Energy.FillEnergy(i_AmountToFill);
        }

        public virtual string GetGeneralDetails()
        {
            string seperator = "===========================================";
            return string.Format("@\n {0} \n Vehicle model : {1} \n Owner Name : {2}\n Owner Phone : {3} \n Vehicle LPN : {4} \n {5}", seperator, this.model, this.ownerName, this.ownerPhoneNumber, this.lPN, seperator);
        }

        //public abstract void FillAirToMaxPressure();

        //CR ::Action:: added the base class function .. 
        public virtual void FillAirToMaxPressure()
        {
            foreach (Wheel wheel in Wheels)
            {
                wheel.CurrentAirPressure = wheel.ManufactureRecommendedAirPressure;
            }
        }
    }
}
