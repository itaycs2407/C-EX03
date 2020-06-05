using System;


namespace Ex03.GarageLogic
{
    public class MotorCycle : Vehicle
    {
        private eLicense m_License;
        private float m_EngineVolume;
        public const int k_ManufactureMaxPressure = 30;

        public MotorCycle(string i_OwnerName, string i_OwnerPhoneNumber, string i_LPN, string i_Model, eLicense i_License, float i_EngineVolume) 
            : base(i_LPN, i_OwnerName, i_OwnerPhoneNumber, i_Model)
        {
            License = i_License;
            EngineVolume = i_EngineVolume;
        }

        public eLicense License { get => m_License; set => m_License = value; }
        public float EngineVolume { get => m_EngineVolume; set => m_EngineVolume = value; }

        public override string ToString()
        {
            string generalDetails = GetGeneralDetails();
            string seperator = "================= OTHER =========================";
            string spcificDetails = string.Format("\n{0}\nType of vehicle : {1}\nEngine volume : {2} \nLicense {3}", seperator, this.GetType().Name, m_EngineVolume.ToString(), m_License.ToString());
            return string.Format("{0}\n{1}", generalDetails, spcificDetails);
        }
    }
}
