using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue, m_MinValue;

        public ValueOutOfRangeException( float i_MaxValue,float  i_MinValue)
            : base  (string.Format("ValueOutOfRangeException MAX :{0}, MIN :{1} ", i_MaxValue, i_MinValue))
        {
        }

    }
}
