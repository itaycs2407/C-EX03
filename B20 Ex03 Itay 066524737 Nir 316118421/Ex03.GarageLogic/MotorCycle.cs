using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class MotorCycle : Vehicle
    {
        private eLicense m_License;
        private float m_EngineVolume;

        public MotorCycle(string i_OwnerName, string i_OwnerPhoneNumber, string i_LPN, string i_Model, float i_AmountOfEnergy, List<Wheel> i_Wheels, eLicense i_License, float i_EngineVolume, eVehicleState i_VehicleState) 
            : base(i_LPN, i_AmountOfEnergy, i_Wheels, i_OwnerName, i_OwnerPhoneNumber, i_Model, new Energy(),  i_VehicleState)
        {
            License = i_License;
            EngineVolume = i_EngineVolume;
        }

        public eLicense License { get => m_License; set => m_License = value; }
        public float EngineVolume { get => m_EngineVolume; set => m_EngineVolume = value; }

        public override void FillEnergy(int i_AmountToFill)
        {
            throw new NotImplementedException();
        }
    }
}
