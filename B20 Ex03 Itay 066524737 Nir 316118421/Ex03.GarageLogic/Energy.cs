using System;

namespace Ex03.GarageLogic
{
    public class Energy
    {
        private readonly float r_MaxEnergy;
        private eEnergyType m_Type;
        private eFuelType m_FuelType;
        private float m_CurrentEnergy;

        public float MaxEnergy { get => r_MaxEnergy; }

        public float CurrentEnergy { get => m_CurrentEnergy; set => m_CurrentEnergy = value; }

        public eEnergyType Type { get => m_Type; set => m_Type = value; }

        public eFuelType FuelType { get => m_FuelType; set => m_FuelType = value; }

        public Energy(eEnergyType i_Type, eFuelType i_FuelType, float i_MaxEnergy, float i_CurrentEnergy)
        {
            Type = i_Type;
            m_FuelType = i_FuelType;
            r_MaxEnergy = i_MaxEnergy;
            CurrentEnergy = i_CurrentEnergy * i_MaxEnergy;
        }

        public virtual void FillEnergy(float i_AmountToFill, eFuelType i_FuelType)
        {
            if (FuelType.Equals(i_FuelType))
            {
                FillEnergy(i_AmountToFill);
            }
            else
            {
                throw new ArgumentException("The fuel you wanted to fill is not the fuel car is powered with. operation failed");
            }
        }
        
        public override string ToString()
        {
            bool v_IsElectric = this.Type == eEnergyType.Electric;
            string energyTankAttribute = v_IsElectric ? "Hours" : "Liter";
            string fuelTypeToShow = v_IsElectric ? "Not relevant" : this.m_FuelType.ToString();
            string seperator = "================= ENERGY ========================";
            return string.Format("\n{0}\nEnergy type : {1}\nFuel type : {2} \nMax energy capacity : {3:0.0} {4}\nCurrent energy capacity : {5:0.0} {6}", seperator, this.m_Type, fuelTypeToShow, this.r_MaxEnergy, energyTankAttribute, this.m_CurrentEnergy, energyTankAttribute);
        }

        public virtual void FillEnergy(float i_AmountToFill)
        {
            if (this.Type == eEnergyType.Electric)
            {
                if ((i_AmountToFill / 60) + this.m_CurrentEnergy <= this.MaxEnergy)
                {
                    this.m_CurrentEnergy += i_AmountToFill / 60;
                }
                else
                {
                    throw new ValueOutOfRangeException();
                }
            }
            else
            {
                if (this.m_CurrentEnergy + i_AmountToFill <= this.r_MaxEnergy)
                {
                    this.m_CurrentEnergy += i_AmountToFill;
                }
                else
                {
                    throw new ValueOutOfRangeException();
                }
            }
        }
    }
}
