
namespace Ex03.GarageLogic
{
    class Wheel
    {
        private string m_ManufactureName;
        private float m_CurrentAirPressure;
        private float m_ManufactureRecommendedAirPressure;

        public string ManufactureName { get => m_ManufactureName; set => m_ManufactureName = value; }
        public float CurrentAirPressure { get => m_CurrentAirPressure; set => m_CurrentAirPressure = value; }
        public float ManufactureRecommendedAirPressure { get => m_ManufactureRecommendedAirPressure; set => m_ManufactureRecommendedAirPressure = value; }

        public Wheel(string i_ManufactureName, float i_CurrentAirPressure, float i_ManufactureRecommendedAirPressure)
        {
            m_ManufactureName = i_ManufactureName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_ManufactureRecommendedAirPressure = i_ManufactureRecommendedAirPressure;
    }
        public void FillAirPressure(float i_Pressure)
        {
            m_CurrentAirPressure = CurrentAirPressure + i_Pressure <= m_ManufactureRecommendedAirPressure
                ? CurrentAirPressure + i_Pressure : CurrentAirPressure;
            // need to throw exception
        }
    }
}
