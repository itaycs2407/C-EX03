using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException()
            : base("You tried to exceed max capacity... operation failed")
        {
        }

        public float MaxValue { get => m_MaxValue; set => m_MaxValue = value; }

        public float MinValue { get => m_MinValue; set => m_MinValue = value; }
    }
}
