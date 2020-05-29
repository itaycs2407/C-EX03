using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private float m_CargoVolume;
        private bool m_IsDangerousMaterials;

        public Truck(string i_OwnerName, string i_OwnerPhoneNumber, string i_LPN, string i_Model, float i_AmountOfEnergy, List<Wheel> i_Wheels, float i_CargoVolume, bool i_IsDangerousMaterials, eVehicleState i_VehicleState) 
            : base(i_LPN, i_AmountOfEnergy, i_Wheels, i_OwnerName, i_OwnerPhoneNumber, i_Model, new Energy(), i_VehicleState)
        {
            m_CargoVolume = i_CargoVolume;
            m_IsDangerousMaterials = i_IsDangerousMaterials;
        }

        public float CargoVolume { get => m_CargoVolume; set => m_CargoVolume = value; }
        public bool IsDangerousMaterials { get => m_IsDangerousMaterials; set => m_IsDangerousMaterials = value; }

        public override void FillEnergy(int i_AmountToFill)
        {
            throw new NotImplementedException();
        }
    }
}
