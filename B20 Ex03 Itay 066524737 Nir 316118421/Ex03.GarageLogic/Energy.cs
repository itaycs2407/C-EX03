using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Energy
    {
        private eEnergyType m_Type;
        private Nullable<eFuelType> m_FuelType;
        private readonly float m_MaxEnergy;
        private float m_CurrentEnergy;

        public float MaxEnergy { get => m_MaxEnergy;  }
        public float CurrentEnergy { get => m_CurrentEnergy; set => m_CurrentEnergy = value; }
        public eEnergyType Type { get => m_Type; set => m_Type = value; }
        public eFuelType FuelType { get => m_FuelType.Value; set => m_FuelType = value; }

        public Energy(eEnergyType i_Type, Nullable<eFuelType> i_FuelType, float i_MaxEnergy, float i_CurrentEnergy)
        {
            m_Type = i_Type;
            m_FuelType = i_FuelType;
            m_MaxEnergy = i_MaxEnergy;
            m_CurrentEnergy = i_CurrentEnergy;
        }
        public virtual void FillEnergy(float i_AmountToFill, eFuelType i_FuelType)
        {
            if (this.FuelType.Equals(i_FuelType))
            {
                m_CurrentEnergy = (m_CurrentEnergy + i_AmountToFill <= m_MaxEnergy) ? m_CurrentEnergy + i_AmountToFill : m_CurrentEnergy;
            }
            else
            {
                // need to throw exception
            }
        }

        public virtual void FillEnergy(float i_AmountToFill)
        {
            m_CurrentEnergy = (m_CurrentEnergy + i_AmountToFill <= m_MaxEnergy) ? m_CurrentEnergy + i_AmountToFill : m_CurrentEnergy;
        }
    }
}
