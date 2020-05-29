using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string model;
        // LPN  = License Plate Number
        private string lPN;
        private float amoutOfEnergy;
        private List<Wheel> wheels;
        private string ownerName;
        private string ownerPhoneNumber;
        private Energy energy;
        private eVehicleState vehicleState;

        public string Model { get => model; set => model = value; }
        public string LPN { get => lPN; set => lPN = value; }
        public float AmoutOfEnergy { get => amoutOfEnergy; set => amoutOfEnergy = value; }
        public List<Wheel> Wheels { get => wheels; set => wheels = value; }
        public string OwnerName { get => ownerName; set => ownerName = value; }
        public string OwnerPhoneNumber { get => ownerPhoneNumber; set => ownerPhoneNumber = value; }
        public eVehicleState VehicleState { get => vehicleState; set => vehicleState = value; }
        public Energy Energy { get => energy; set => energy = value; }

        public Vehicle(string i_LPN, float i_AmoutOfEnergy, List<Wheel> i_Wheels, string i_OwnerName, string i_OwnerPhoneNumber, string i_Model, Energy i_Energy, eVehicleState i_VehicleState)
        {
            LPN = i_LPN;
            AmoutOfEnergy = i_AmoutOfEnergy;
            Wheels = i_Wheels;
            OwnerName = i_OwnerName;
            OwnerPhoneNumber = i_OwnerPhoneNumber;
            Model = i_Model;
            Energy = i_Energy;
            VehicleState = i_VehicleState;
        }

        public abstract void FillEnergy(int i_AmountToFill);

    }
}
