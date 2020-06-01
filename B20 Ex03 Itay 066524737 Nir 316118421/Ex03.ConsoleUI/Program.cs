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
            string userLPNInput;
            int userInput = menu.GetUserInputMainMenu();
            int case1UserInput;
            eVehicleState userStateInput;
            while (userInput >= 1 && userInput <=8) 
            {
                switch (userInput)
                {
                    case 1: // Recive new Vehicle.
                        case1UserInput = menu.AddVehicle();
                        switch (case1UserInput)
                        {
                            case 1: // Recive electric car.
                            case 2: // Recive fueled car.
                            case 3: // Recive electric motorcycle.
                            case 4: // Recive fueled motorcycle
                            case 5: // Recive Truck
                            case 6: 
                                // Return to previous menu.
                                break;
                        }
                        break;



                    case 2:
                        // Show all vehicle LPN by state.
                        userStateInput = menu.GetStateFromUser("Select state to show all LPN by :");
                        Console.WriteLine(garage.GetAllVehicleLPNByState(userStateInput).ToString());
                        break;
                    case 3:
                        // Change vehicle state by LPN
                        
                        printAllLpnAndGetInput(); // need to be changed to new signuture
                        
                        // tell the user what is the current state of the selected LPN and than get input for state
                        Console.WriteLine("The current state of the vehicle is : {0}, if you choose the new state as the current state,\n No changes will be made !",garage.GetVehicleForDetails(userLPNInput).VehicleState.ToString());
                        userStateInput = menu.GetStateFromUser("Choose the new stage :");
                        garage.ChangeVehicleState(userLPNInput, userStateInput);
                        break;

                    case 4: // Fill air in vehicle
                    case 5: // Fill fuled vehicle.
                    case 6: // Charge electric vehicle.

                    case 7:
                        // Show vehicle details by LPN.
                        printAllLpnAndGetInput();  // need to be changed to new signuture
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
