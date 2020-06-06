using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufactureName;
        private float m_CurrentAirPressure;
        private float m_ManufactureRecommendedAirPressure;

        public string ManufactureName { get => m_ManufactureName; set => m_ManufactureName = value; }

        public float CurrentAirPressure { get => m_CurrentAirPressure; set => m_CurrentAirPressure = value; }

        public float ManufactureRecommendedAirPressure { get => m_ManufactureRecommendedAirPressure; set => m_ManufactureRecommendedAirPressure = value; }

        public Wheel(string i_ManufactureName, float i_CurrentAirPressure, float i_ManufactureRecommendedAirPressure)
        {
            ManufactureName = i_ManufactureName;
            CurrentAirPressure = i_CurrentAirPressure;
            ManufactureRecommendedAirPressure = i_ManufactureRecommendedAirPressure;
        }

        public void FillAirPressure(float i_Pressure)
        {
            this.CurrentAirPressure = ((float)(this.CurrentAirPressure + i_Pressure) <= m_ManufactureRecommendedAirPressure) ? this.CurrentAirPressure + i_Pressure : this.CurrentAirPressure;
        }

        public override string ToString()
        {
            string seperator = "================= WHEELS ========================";
            return string.Format("\n{0}\nManufacture Name : {1}\nManufacture Recommended Air Pressure : {2} PSI \nCurrent Air Pressure : {3} PSI", seperator, this.m_ManufactureName, this.m_ManufactureRecommendedAirPressure, this.m_CurrentAirPressure);
        }
    }
}
