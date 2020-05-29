using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        string m_Model;

        // LPN  == License Plate Number
        private string m_LPN;
        private float m_AmoutOfEnergy;
        public List<Wheel> m_Wheels;
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;

        public Vehicle(string i_LPN, float i_AmoutOfEnergy, List<Wheel> i_Wheels, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            m_LPN = i_LPN;
            m_AmoutOfEnergy = i_AmoutOfEnergy;
            m_Wheels = i_Wheels;
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
        }

        public abstract void FillEnergy(int i_AmountToFill);

    }
}
