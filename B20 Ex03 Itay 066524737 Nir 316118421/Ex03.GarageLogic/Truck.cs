using System;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private float m_CargoVolume;
        private bool m_IsDangerousMaterials;
        public const int k_ManufactureMaxPressure = 28;

        public Truck(string i_OwnerName, string i_OwnerPhoneNumber, string i_LPN, string i_Model, float i_CargoVolume, bool i_IsDangerousMaterials) 
            : base(i_LPN, i_OwnerName, i_OwnerPhoneNumber, i_Model)
        {
            m_CargoVolume = i_CargoVolume;
            m_IsDangerousMaterials = i_IsDangerousMaterials;
        }

        public float CargoVolume { get => m_CargoVolume; set => m_CargoVolume = value; }
        public bool IsDangerousMaterials { get => m_IsDangerousMaterials; set => m_IsDangerousMaterials = value; }

        //CR ::Comment:: Why not having the same function in the abstract class ? feels like duplicate 
        public override void FillEnergy(float i_AmountToFill)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string generalDetails = GetGeneralDetails();
            string spcificDetails = string.Format(@" \nCargo volume : {0} \n Carry dangerous materials {1}", m_CargoVolume, m_IsDangerousMaterials.ToString());
            return string.Format(@"{0}\n {1}", generalDetails, spcificDetails);
        }
   }

}
