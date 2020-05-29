using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Energy
    {
        private eEnergyType m_Type;
        private eFuelType m_FuelType;
        private float m_MaxEnergy;
        private float m_CurrentEnergy;

        public float MaxEnergy { get => m_MaxEnergy; set => m_MaxEnergy = value; }
        public float CurrentEnergy { get => m_CurrentEnergy; set => m_CurrentEnergy = value; }
        public eEnergyType Type { get => m_Type; set => m_Type = value; }
        public eFuelType FuelType { get => m_FuelType; set => m_FuelType = value; }

        public virtual void FillEnergy(int i_AmountToFill)
        {
            m_CurrentEnergy = (m_CurrentEnergy + i_AmountToFill <= m_MaxEnergy) ? m_CurrentEnergy + i_AmountToFill : m_CurrentEnergy;
        }
    }
}
