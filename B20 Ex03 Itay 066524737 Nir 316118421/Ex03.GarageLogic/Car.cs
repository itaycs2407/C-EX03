using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Car : Vehicle 
    {
        private eVehicleColor m_Color;
        private eDoors m_NumberOfDoors;

        public eVehicleColor Color { get => m_Color; set => m_Color = value; }
        public eDoors NumberOfDoors { get => m_NumberOfDoors; set => m_NumberOfDoors = value; }
        public Car(string i_OwnerName, string i_OwnerPhoneNumber, string i_LPN, string i_Model, float i_AmountOfEnergy, List<Wheel> i_Wheels, eVehicleColor i_Color, eDoors i_Doors)
        {
            // need to implement base cnsr
            m_Color = i_Color;
            m_NumberOfDoors = i_Doors;
        }

        public override void FillEnergy(int i_AmountToFill)
        {
            throw new NotImplementedException();
        }
    }
}
