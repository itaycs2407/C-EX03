using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Ex03.GarageLogic;
using Microsoft.Win32;

namespace Ex03.ConsoleUI
{
    class Program
    {
            private static MenuGenerator menu = new MenuGenerator();
            private static Garage garage = new Garage();
            private static string userLPNInput, m_OwnerName, m_OwnerPhoneNumber, m_Model, m_LPN, m_WheelManufactureName;
            private static int case1UserInput ,m_EngineVolume ,userInput = 1;
            private static bool m_IsDangerousMaterials, exit = userInput == 8 ? true : !true;
            private static List<string> vehicleLPNList;
            private static eVehicleState userStateInput;
            private static eLicense m_Lisence;
            private static eVehicleColor m_Color;
            private static eDoors m_Doors;
            private static float m_CurrentAirPressure, m_CargoVolume, m_CurrentAmountOfEnergy;
        static void Main(string[] args)
        {
            while (userInput >= 1 && userInput <=8 && !exit) 
            {
                userInput = menu.GetUserInputMainMenu();
                switch (userInput)
                {
                    case 1: // Recive new Vehicle.
                        case1UserInput = menu.AddVehicle();
                        if (case1UserInput == 6)
                        {
                            break;
                        }
                        menu.GetVehicleLPN(out m_LPN);
                        // check if vehicle already in the garage
                        if (garage.IsLPNExistInGarage(m_LPN))
                        {
                            Console.WriteLine("The vehicle is already in the garage. changhing its state to \"On Repair\"");
                            garage.ChangeVehicleState(m_LPN, eVehicleState.OnRepair);
                            break;
                        }

                        menu.GetGenralDetailsFromUser(out m_OwnerName, out m_OwnerPhoneNumber, out m_Model, out m_WheelManufactureName);
                        switch (case1UserInput) { 
                            case 1:
                                //Recive electric car.
                                //get valid wheel current pressure
                                getUserInputForCarWheelPressure();
                                
                                // get valid current energy 
                                do
                                {
                                    menu.GetCurrentEnergyCapacity(out m_CurrentAmountOfEnergy);
                                }
                                while (!garage.IsValidEnergyCapacity(m_CurrentAmountOfEnergy));

                                getDetailsAndCreateCar(eEnergyType.Electric);
                                break;
                            case 2:
                                // Recive fueled car.

                                //get valid wheel current pressure
                                getUserInputForCarWheelPressure();
                                // get valid current energy 
                                do
                                {
                                    menu.GetCurrentEnergyCapacity(out m_CurrentAmountOfEnergy);
                                }
                                while (!garage.IsValidEnergyCapacity(m_CurrentAmountOfEnergy));

                                getDetailsAndCreateCar(eEnergyType.Fueled);
                                break;
                            case 3:
                                // Recive electric motorcycle.
                                //get valid wheel current pressure
                                getUserInputForMotorWheelPressure();
                                // get valid current energy 
                                do
                                {
                                    menu.GetCurrentEnergyCapacity(out m_CurrentAmountOfEnergy);
                                }
                                while (!garage.IsValidEnergyCapacity(m_CurrentAmountOfEnergy));

                                getDetailsAndCreateMotor(eEnergyType.Electric);
                                break;
                            case 4:
                                // Recive fueled motorcycle
                                //get valid wheel current pressure
                                getUserInputForMotorWheelPressure();
                                // get valid current energy 
                                do
                                {
                                    menu.GetCurrentEnergyCapacity(out m_CurrentAmountOfEnergy);
                                }
                                while (!garage.IsValidEnergyCapacity(m_CurrentAmountOfEnergy));

                                getDetailsAndCreateMotor(eEnergyType.Fueled);
                                break; 
                            case 5:
                                // Recive Truck

                                //get valid wheel current pressure
                                getUserInputForTruckWheelPressure();
                                // get valid current energy 
                                do
                                {
                                    menu.GetCurrentEnergyCapacity(out m_CurrentAmountOfEnergy);
                                }
                                while (!garage.IsValidEnergyCapacity(m_CurrentAmountOfEnergy));

                                menu.GetTruckDetailsFromUser(out m_CargoVolume, out m_IsDangerousMaterials);
                                garage.ReciveNewTruck(m_OwnerName, m_OwnerPhoneNumber, m_LPN, m_Model, m_CurrentAirPressure, m_WheelManufactureName, m_CargoVolume, m_IsDangerousMaterials, m_CurrentAmountOfEnergy);
                                break;
                            case 6: 
                                // Return to previous menu.
                                break;
                        }
                        break;

                    case 2:
                        // Show all vehicle LPN by state.
                        if (vehicleLPNList.Count > 0)
                        {
                            //get input from user for the state to show by
                            userStateInput = menu.GetStateFromUser("Select state to show all LPN by :");
                            vehicleLPNList = garage.GetAllVehicleLPNByState(userStateInput);
                            Console.WriteLine(@"State to be diaplayed : {0}", userStateInput.ToString());
                            printAllLpnAndGetInput(vehicleLPNList, false);
                        }
                        else
                        {
                            Console.WriteLine("No vehicle in the Garage.");
                        }
                        break;
                    case 3:
                        // Change vehicle state by LPN
                        
                        // get all LPN
                        vehicleLPNList = garage.GetAllVehicleLPN();
                        if (vehicleLPNList.Count > 0)
                        {
                            //print the LPN list and get input from user on witch LPN he want to change state ->userLPNInput
                            printAllLpnAndGetInput(vehicleLPNList, true);
                            // tell the user what is the current state of the selected LPN and than get input for state
                            Console.WriteLine("The current state of the vehicle is : {0}, in case you choose the new state as the current state,\nfNo change will be made !",garage.GetVehicleForDetails(userLPNInput).VehicleState.ToString());
                            userStateInput = menu.GetStateFromUser("Choose the new stage :");
                            // add the logic for exit the menu
                            
                            if (userStateInput !=null )
                            {
                                garage.ChangeVehicleState(userLPNInput, userStateInput);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No vehicle in the Garage.");
                        }
                        break;
                    case 4:
                        // Fill air in vehicle
                        vehicleLPNList = garage.GetAllVehicleLPN();
                        if (vehicleLPNList.Count > 0)
                        {
                            //print the LPN list and get input from user on witch LPN he want to fill air in the wheels ->userLPNInput
                            printAllLpnAndGetInput(vehicleLPNList, true);
                            Vehicle vehicleToFillAir = garage.GetVehicleForDetails(userLPNInput);
                            vehicleToFillAir.FillAirToMaxPressure();
                        }
                        else
                        {
                            Console.WriteLine("No vehicle in the Garage.");
                        }
                        break;
                    case 5:
                        // Fill fuled vehicle.

                        // get all LPN for vehicle powered by 
                        vehicleLPNList = garage.GetAllVehicleLPN(eEnergyType.Fueled);
                        if (vehicleLPNList.Count > 0)
                        {
                            //print the LPN list for electric vehicles and get input from user on witch LPN he want to charge ->userLPNInput
                            printAllLpnAndGetInput(vehicleLPNList, true);
                            Vehicle fueledVehicle = garage.GetVehicleForDetails(userLPNInput);
                            Console.WriteLine(@"The current energy of the vehicle is {0:0.00} liter out of {1:0.00} liter", fueledVehicle.Energy.CurrentEnergy, fueledVehicle.Energy.MaxEnergy);
                            // fill the vehicle.
                            float amountOfFuelToCharge = menu.GetEnergyCapacityToAdd("Please enter amount of fuel to add : ");

                            // ask from user for fuel type
                            eFuelType FuleTypeToFill = menu.GetFueltypeFromUser();
                            // need to be surronding with try-catch
                            // charge the vehicle
                            try
                            {
                                fueledVehicle.Energy.FillEnergy(amountOfFuelToCharge, FuleTypeToFill);
                            }
                            catch (ValueOutOfRangeException voor)
                            {
                                Console.WriteLine(voor.Message);
                            }
                            //need to chck if OK
                            catch (ArgumentException a)
                            {
                                Console.WriteLine(a.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No vehicle in the Garage.");
                        }
                        
                        break;
                    case 6: 
                        // Charge electric vehicle.
                            
                        // get all LPN for vehicle powered by 
                        vehicleLPNList = garage.GetAllVehicleLPN(eEnergyType.Electric);
                        //print the LPN list for electric vehicles and get input from user on witch LPN he want to charge ->userLPNInput
                        if (vehicleLPNList.Count > 0)
                        {
                            printAllLpnAndGetInput(vehicleLPNList, true);
                            // need to add : input from user 
                            Vehicle elctricVeheicle = garage.GetVehicleForDetails(userLPNInput);
                            Console.WriteLine(@"The current energy of the vehicle is {0:0.00} hours out of {1:0.00} hours", elctricVeheicle.Energy.CurrentEnergy, elctricVeheicle.Energy.MaxEnergy);
                            float numberOfMinuesToCharge;
                            do
                            {
                                numberOfMinuesToCharge = menu.GetEnergyCapacityToAdd(string.Format(@"Please enter number of minutes to charge between 1 and {0:0}: ", (elctricVeheicle.Energy.MaxEnergy - elctricVeheicle.Energy.CurrentEnergy)*60));
                            }
                            while (((numberOfMinuesToCharge + elctricVeheicle.Energy.CurrentEnergy) /60)  > elctricVeheicle.Energy.MaxEnergy);
                            
                            // need to be surronding with try-catch
                            // charge the vehicle
                            elctricVeheicle.Energy.FillEnergy(numberOfMinuesToCharge);
                        }
                        else
                        {
                            Console.WriteLine("No vehicle in the Garage.");
                        }
                        break;
                    case 7:
                        // Show vehicle details by LPN.
                        vehicleLPNList = garage.GetAllVehicleLPN();
                        if (vehicleLPNList.Count > 0)
                        {
                            //print the LPN list and get input from user on witch LPN he want to change state ->userLPNInput
                            printAllLpnAndGetInput(vehicleLPNList,true);
                            Console.WriteLine(garage.GetVehicleForDetails(userLPNInput).ToString());
                        }
                        else
                        {
                            Console.WriteLine("No vehicle in the Garage.");
                        }
                        break;
                    case 8:
                        // Exit.
                        exit = true;
                        break;
                         
                }
                if (!exit) 
                {
                    Console.WriteLine("Press any key to continue."); 
                    Console.ReadLine();
                }
            }

        }
        private static void printAllLpnAndGetInput(List<string> i_VehicleLPNToPring, bool i_GetInput)
        {
            Console.WriteLine("This is the list of all vehicles in the garage : ");
            foreach (string LPN in i_VehicleLPNToPring)
            {
                Console.WriteLine(@"LPN : {0}", LPN);
            }
            if (i_GetInput)
            {
                userLPNInput = menu.SelectLPN(i_VehicleLPNToPring);
            }
        }
        private static void getDetailsAndCreateCar(eEnergyType i_EnergyType)
            {
                menu.GetCarDetailsFromUser(out m_Color, out m_Doors);
                if (i_EnergyType == eEnergyType.Electric)
                {
                    garage.ReciveNewElectricCar(m_OwnerName, m_OwnerPhoneNumber, m_LPN, m_Model, m_CurrentAirPressure, m_WheelManufactureName, m_CurrentAmountOfEnergy, m_Color, m_Doors);
                }
                else
                {
                    garage.ReciveNewFueledCar(m_OwnerName, m_OwnerPhoneNumber, m_LPN, m_Model, m_CurrentAirPressure, m_WheelManufactureName, m_CurrentAmountOfEnergy, m_Color, m_Doors);
                }

            }
        private static void getDetailsAndCreateMotor(eEnergyType i_EnergyType)
            {
                menu.GetMotorcycleDetailsFromUser(out m_Lisence, out m_EngineVolume);
                if (i_EnergyType == eEnergyType.Electric)
                {
                    garage.ReciveNewElectricMotorcycle(m_OwnerName, m_OwnerPhoneNumber, m_LPN, m_Model, m_CurrentAirPressure, m_WheelManufactureName, m_CurrentAmountOfEnergy, m_Lisence, m_EngineVolume);
                }
                else
                {
                    garage.ReciveNewFueledMotorcycle(m_OwnerName, m_OwnerPhoneNumber, m_LPN, m_Model, m_CurrentAirPressure, m_WheelManufactureName, m_CurrentAmountOfEnergy, m_Lisence, m_EngineVolume);
                }

            }
        private static void getUserInputForCarWheelPressure()
        {
            do
            {
                menu.GetWheelPressure(out m_CurrentAirPressure);
            }
            while (!garage.IsValidWheelPressureForCar(m_CurrentAirPressure));

        }
        private static void getUserInputForMotorWheelPressure()
        {
            do
            {
                menu.GetWheelPressure(out m_CurrentAirPressure);
            }
            while (!garage.IsValidWheelPressureForMotor(m_CurrentAirPressure));

        }
        private static void getUserInputForTruckWheelPressure()
        {
            do
            {
                menu.GetWheelPressure(out m_CurrentAirPressure);
            }
            while (!garage.IsValidWheelPressureForTruck(m_CurrentAirPressure));

        }
    }
}
