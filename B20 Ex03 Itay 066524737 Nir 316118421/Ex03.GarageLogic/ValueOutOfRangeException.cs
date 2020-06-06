using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue, m_MinValue;
        

        public ValueOutOfRangeException()
            : base("You tried to exceed max capacity... operation failed")
        {
        }

    }
}
