using System;

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
            if (FuelType.Equals(i_FuelType))
            {
                FillEnergy(i_AmountToFill);
            }
            else
            {
                throw new ArgumentException();
            }
        }
        public override string ToString()
        {
            string energyTankAttribute = this.Type == eEnergyType.Electric ? "Hours" : "Liter";
            string seperator = "================= ENERGY ========================";
            return string.Format("\n{0}\nEnergy type : {1}\nFuel type : {2} \nMax energy capacity : {3} {4}\nCurrent energy capacity : {5} {6}", seperator, this.m_Type, this.m_FuelType, this.m_MaxEnergy, energyTankAttribute ,this.m_CurrentEnergy, energyTankAttribute);
        }

        public virtual void FillEnergy(float i_AmountToFill)
        {
            if (m_CurrentEnergy + i_AmountToFill <= m_MaxEnergy)
            {
                m_CurrentEnergy = m_CurrentEnergy + i_AmountToFill;
            }
            else
            {
                float maxLimit = VehicleGenerator.k_CarFuelTank;
                if (this.Type == eEnergyType.Electric)
                {
                    maxLimit = VehicleGenerator.k_CarElectricCapacity;
                }
                else if (this.FuelType == eFuelType.Soler)
                {
                    maxLimit = VehicleGenerator.k_TruckFuelTank;
                }
                throw new ValueOutOfRangeException(maxLimit);
            }
        }

    }
}
