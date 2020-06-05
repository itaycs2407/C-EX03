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


        public override string ToString()
        {
            string generalDetails = GetGeneralDetails();
            string seperator = "================= OTHER =========================";
            string spcificDetails = string.Format("{0}\nType of vehicle : {1} \nCargo volume : {2} \nCarry dangerous materials : {3}", seperator, this.GetType().Name, m_CargoVolume, m_IsDangerousMaterials.ToString());
            return string.Format("{0}\n{1}", generalDetails, spcificDetails);
        }
   }

}
