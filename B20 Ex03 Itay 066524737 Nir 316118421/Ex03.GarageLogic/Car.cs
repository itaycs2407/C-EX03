//CR ::Action:: removed unused usings. .

namespace Ex03.GarageLogic
{
    public class Car : Vehicle 
    {
        private eVehicleColor m_Color;
        private eDoors m_NumberOfDoors;
        public const int k_ManufactureMaxPressure = 32;

        public Car(string i_OwnerName, string i_OwnerPhoneNumber, string i_LPN, string i_Model ,eVehicleColor i_Color, eDoors i_Doors)
            : base(i_LPN, i_OwnerName, i_OwnerPhoneNumber,i_Model)
        {
            // need to implement base cnsr
            m_Color = i_Color;
            m_NumberOfDoors = i_Doors;
        }
        public eVehicleColor Color { get => m_Color; set => m_Color = value; }
        public eDoors NumberOfDoors { get => m_NumberOfDoors; set => m_NumberOfDoors = value; }

        //CR ::Action:: Added base class implemantaion in case we decide to change our mind..
        public override void FillEnergy(float i_AmountToFill)
        {
            //CR ::Action:: Added implementation
            Energy.FillEnergy(i_AmountToFill);   
        }
        public override string ToString()
        {
            //CR ::Action:: Removed this. 
            string generalDetails = GetGeneralDetails();
            string spcificDetails = string.Format("@ \nNumber of doors : {0} \n Color :  {1}", (int)m_NumberOfDoors, m_Color.ToString());
            return string.Format("@{0}\n {1}", generalDetails, spcificDetails);
        }
        //mybe not the good practice - maybe need to be in the Vehicle.cs with the member List<Wheel>. need to fix in all the vehicles
        //CR ::Comment:: Agree with the sentence above..
        public override void FillAirToMaxPressure()
        {
            //CR ::Action:: Remoeve this.
            foreach (Wheel wheel in Wheels)
            {
                wheel.CurrentAirPressure = wheel.ManufactureRecommendedAirPressure;
            }
        }
    }
}
