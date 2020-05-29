using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleGenerator
    {
        private List<Vehicle> m_VehicleList;

        public List<Vehicle> VehicleList { get => m_VehicleList; set => m_VehicleList = value; }

        public Vehicle GetVehicleByLPN(string i_LPN)
        {
            Vehicle vehicleToReturn  = null;
            int i;
            for (i = 0; i < m_VehicleList.Count; i++)
            {
                if (m_VehicleList[i].LPN == i_LPN)
                {
                    vehicleToReturn = m_VehicleList[i];
                    break;
                }
                
            }
            return vehicleToReturn;
        }
    }
}
