using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            MenuGenerator menu = new MenuGenerator();
            Garage garage = new Garage();
            string userLPNInput, m_OwnerName, m_OwnerPhoneNumber, m_Model, m_LPN, m_WheelManufactureName;
            int userInput = menu.GetUserInputMainMenu();
            int case1UserInput;
            List<string> vehicleLPNList;
            List<string> electricVehicleLPNList;
            List<string> fueldVehicleLPNList;
            eVehicleState userStateInput;
            float m_CurrentAirPressure, m_CargoVolume, m_CurrentAmountOfEnergy;
            bool m_IsDangerousMaterials;
            while (userInput >= 1 && userInput <=8) 
            {
                switch (userInput)
                {
                    case 1: // Recive new Vehicle.
                        case1UserInput = menu.AddVehicle();
                        menu.GetGenralDetailsFromUser(out m_OwnerName, out m_OwnerPhoneNumber, out m_Model, out m_LPN, out m_WheelManufactureName, out m_CurrentAirPressure,out m_CurrentAmountOfEnergy);
                        switch (case1UserInput)
                        {
                            case 1:
                                // Recive electric car.
                                menu.GetElectricCarDetailsFromUser(out m_CargoVolume, out m_IsDangerousMaterials);
                                garage.ReciveNewElectricCar(m_OwnerName, m_OwnerPhoneNumber, m_LPN, m_Model, m_CurrentAirPressure, m_WheelManufactureName, m_CargoVolume, m_IsDangerousMaterials, m_CurrentAmountOfEnergy);
                                break;
                            case 2:
                                // Recive fueled car.
                                menu.GetFueledCarDetailsFromUser(out m_CargoVolume, out m_IsDangerousMaterials);
                                garage.ReciveNewFueledCar(m_OwnerName, m_OwnerPhoneNumber, m_LPN, m_Model, m_CurrentAirPressure, m_WheelManufactureName, m_CargoVolume, m_IsDangerousMaterials, m_CurrentAmountOfEnergy);
                                break;
                            case 3:
                                // Recive electric motorcycle.
                                menu.GetElectricMotorcycleDetailsFromUser(out m_CargoVolume, out m_IsDangerousMaterials);
                                garage.ReciveNewElectricMotorcycle(m_OwnerName, m_OwnerPhoneNumber, m_LPN, m_Model, m_CurrentAirPressure, m_WheelManufactureName, m_CargoVolume, m_IsDangerousMaterials, m_CurrentAmountOfEnergy);
                                break;
                            case 4:
                                // Recive fueled motorcycle
                                menu.GetFueledMotorcycleDetailsFromUser(out m_CargoVolume, out m_IsDangerousMaterials);
                                garage.ReciveNewFueledMotorcycle(m_OwnerName, m_OwnerPhoneNumber, m_LPN, m_Model, m_CurrentAirPressure, m_WheelManufactureName, m_CargoVolume, m_IsDangerousMaterials, m_CurrentAmountOfEnergy);
                                break;
                            case 5:
                                // Recive Truck
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
                        
                        //get input from user for the state to show by
                        userStateInput = menu.GetStateFromUser("Select state to show all LPN by :");
                        Console.WriteLine(garage.GetAllVehicleLPNByState(userStateInput).ToString());
                        break;
                    case 3:
                        // Change vehicle state by LPN
                        
                        // get all LPN
                        vehicleLPNList = garage.GetAllVehicleLPN();
                        //print the LPN list and get input from user on witch LPN he want to change state ->userLPNInput
                        printAllLpnAndGetInput(vehicleLPNList); 
                        // tell the user what is the current state of the selected LPN and than get input for state
                        Console.WriteLine("The current state of the vehicle is : {0}, in case you choose the new state as the current state,\n No changes will be made !",garage.GetVehicleForDetails(userLPNInput).VehicleState.ToString());
                        userStateInput = menu.GetStateFromUser("Choose the new stage :");
                        garage.ChangeVehicleState(userLPNInput, userStateInput);
                        break;
                    case 4:
                        // Fill air in vehicle
                        vehicleLPNList = garage.GetAllVehicleLPN();
                        //print the LPN list and get input from user on witch LPN he want to fill air in the wheels ->userLPNInput
                        printAllLpnAndGetInput(vehicleLPNList);
                        Vehicle vehicleToFillAir = garage.GetVehicleForDetails(userLPNInput);
                        vehicleToFillAir.FillAirToMaxPressure();
                        break;
                    case 5:
                        // Fill fuled vehicle.

                        // get all LPN for vehicle powered by 
                        fueldVehicleLPNList = garage.GetAllVehicleLPN(eEnergyType.Electric);
                        //print the LPN list for electric vehicles and get input from user on witch LPN he want to charge ->userLPNInput
                        printAllLpnAndGetInput(fueldVehicleLPNList);
                        // need to add : input from user 
                        Vehicle fueledVehicle = garage.GetVehicleForDetails(userLPNInput);
                        Console.WriteLine("The current energy of the vehicle is {0} out of {1}", fueledVehicle.Energy.CurrentEnergy, fueledVehicle.Energy.MaxEnergy);
                        // fill the vehicle.
                        float amountOfFuelToCharge = menu.GetEnergyCapacityToAdd("Please enter amount of fuel to add : ");
                        // ask from user fot fuel type
                        eFuelType FuleTypeToFill = menu.GetFueltypeFromUser();
                        // need to be surronding with try-catch
                        // charge the vehicle
                        fueledVehicle.Energy.FillEnergy(amountOfFuelToCharge, FuleTypeToFill);
                        break;
                    case 6: 
                        // Charge electric vehicle.
                            
                        // get all LPN for vehicle powered by 
                        electricVehicleLPNList = garage.GetAllVehicleLPN(eEnergyType.Electric);
                        //print the LPN list for electric vehicles and get input from user on witch LPN he want to charge ->userLPNInput
                        printAllLpnAndGetInput(electricVehicleLPNList);
                        // need to add : input from user 
                        Vehicle elctricVeheicle = garage.GetVehicleForDetails(userLPNInput);
                        Console.WriteLine("The current energy of the vehicle is {0} out of {1}", elctricVeheicle.Energy.CurrentEnergy, elctricVeheicle.Energy.MaxEnergy);
                        float numberOfMinuesToCharge = menu.GetEnergyCapacityToAdd("Please enter number of minutes to charge : ");
                        
                        // need to be surronding with try-catch
                        // charge the vehicle
                        elctricVeheicle.Energy.FillEnergy(numberOfMinuesToCharge);

                        break;
                    case 7:
                        // Show vehicle details by LPN.
                        vehicleLPNList = garage.GetAllVehicleLPN();
                        //print the LPN list and get input from user on witch LPN he want to change state ->userLPNInput
                        printAllLpnAndGetInput(vehicleLPNList);
                        Console.WriteLine(garage.GetVehicleForDetails(userLPNInput).ToString());
                        break;
                    case 8:
                        // Exit.
                        break;
                         
                }
                userInput = menu.GetUserInputMainMenu();
            }
             void printAllLpnAndGetInput(List<string> i_VehicleLPNToPring)
            {
                Console.WriteLine("This is the list of all vehicles in the garage : \n");
                Console.WriteLine(i_VehicleLPNToPring.ToString());
                userLPNInput = menu.SelectLPN(i_VehicleLPNToPring);
            }

        }
    }
}
