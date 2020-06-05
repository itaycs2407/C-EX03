using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue, m_MinValue;

        public ValueOutOfRangeException(float i_MaxValue )
            : base(string.Format("The max capacity is {0} and unforttently you tried to exceed it... operation failed", i_MaxValue))
        {
        }

    }
}
