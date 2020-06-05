
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
            m_Color = i_Color;
            m_NumberOfDoors = i_Doors;
        }
        public eVehicleColor Color { get => m_Color; set => m_Color = value; }
        public eDoors NumberOfDoors { get => m_NumberOfDoors; set => m_NumberOfDoors = value; }

        
        public override string ToString()
        {
            string generalDetails = GetGeneralDetails();
            string seperator = "================= OTHER =========================";
            string specificDetails = string.Format("\n{0}\nType of vehicle : {1}\nNumber of doors : {2}, {3} \nColor :  {4}", seperator, this.GetType().Name, (int)m_NumberOfDoors,m_NumberOfDoors, m_Color.ToString());

            return string.Format("{0}\n{1}", generalDetails, specificDetails);
        }
     
    }
}
