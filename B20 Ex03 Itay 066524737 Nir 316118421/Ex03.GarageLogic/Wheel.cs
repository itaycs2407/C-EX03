using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Wheel
    {
        private string m_ManufactureName;
        private float m_CurrentAirPressure;
        private float m_ManufactureRecommendedAirPressure;
        private eWheelLocation location;

        public string ManufactureName { get => m_ManufactureName; set => m_ManufactureName = value; }
        public float CurrentAirPressure { get => m_CurrentAirPressure; set => m_CurrentAirPressure = value; }
        public float ManufactureRecommendedAirPressure { get => m_ManufactureRecommendedAirPressure; set => m_ManufactureRecommendedAirPressure = value; }
        public eWheelLocation Location { get => location; set => location = value; }
    }
}
