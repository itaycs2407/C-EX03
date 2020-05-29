using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle 
    {
        private eVehicleColor m_Color;
        private eDoors m_NumberOfDoors;

        public Car(string i_OwnerName, string i_OwnerPhoneNumber, string i_LPN, string i_Model, float i_AmountOfEnergy, List<Wheel> i_Wheels,eVehicleState i_VehicleState ,eVehicleColor i_Color, eDoors i_Doors)
            : base(i_LPN, i_AmountOfEnergy, i_Wheels, i_OwnerName, i_OwnerPhoneNumber,i_Model, new Energy(), i_VehicleState)
        {
            // need to implement base cnsr
            m_Color = i_Color;
            m_NumberOfDoors = i_Doors;
        }
        public eVehicleColor Color { get => m_Color; set => m_Color = value; }
        public eDoors NumberOfDoors { get => m_NumberOfDoors; set => m_NumberOfDoors = value; }

        public override void FillEnergy(int i_AmountToFill)
        {
            throw new NotImplementedException();
        }
    }
}
