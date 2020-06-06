using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Program
    {
            private static MenuGenerator s_Menu = new MenuGenerator();
            private static Garage s_Garage = new Garage();
            private static string s_UserLPNInput, s_OwnerName, s_OwnerPhoneNumber, s_Model, s_LPN, s_WheelManufactureName;
            private static int s_Case1UserInput, s_EngineVolume, s_UserInput = 1;
            private static bool s_IsDangerousMaterials, s_Exit = s_UserInput == 8 ? true : !true;
            private static List<string> s_VehicleLPNList;
            private static eVehicleState s_UserStateInput;
            private static eLicense s_Lisence;
            private static eVehicleColor s_Color;
            private static eDoors s_Doors;
            private static float s_CurrentAirPressure, s_CargoVolume, s_CurrentAmountOfEnergy;

        public static eVehicleState UserStateInput { get => s_UserStateInput; set => s_UserStateInput = value; }

        public static void Main(string[] args)
        {
            manageMainProgramGarage();
            Console.WriteLine("Thank you and Bye Bye .. ");
        }
#region MenuOptionsFunctions
        private static void insertNewVehicle()
        {
            s_Case1UserInput = s_Menu.AddVehicle();
            if (s_Case1UserInput != 6)
            {
                s_Menu.GetVehicleLPN(out s_LPN);

                // check if vehicle already in the garage
                if (s_Garage.IsLPNExistInGarage(s_LPN))
                {
                    Console.WriteLine("The vehicle is already in the garage. changhing its state to \"On Repair\"");
                    s_Garage.ChangeVehicleState(s_LPN, eVehicleState.OnRepair);
                }
                else
                {
                       s_Menu.GetGenralDetailsFromUser(out s_OwnerName, out s_OwnerPhoneNumber, out s_Model, out s_WheelManufactureName);
                    switch (s_Case1UserInput)
                    {
                        case 1:
                            // Recive electric car.
                            // get valid wheel current pressure
                            getUserInputForCarWheelPressure();

                            // get valid current energy 
                            getAndValidateEnergyCapacity(out s_CurrentAmountOfEnergy);
                            getDetailsAndCreateCar(eEnergyType.Electric);
                            break;
                        case 2:
                            // Recive fueled car.
                            // get valid wheel current pressure
                            getUserInputForCarWheelPressure();

                            // get valid current energy 
                            getAndValidateEnergyCapacity(out s_CurrentAmountOfEnergy);
                            getDetailsAndCreateCar(eEnergyType.Fueled);
                            break;
                        case 3:
                            // Recive electric motorcycle.
                            // get valid wheel current pressure
                            getUserInputForMotorWheelPressure();

                            // get valid current energy 
                            getAndValidateEnergyCapacity(out s_CurrentAmountOfEnergy);
                            getDetailsAndCreateMotor(eEnergyType.Electric);
                            break;
                        case 4:
                            // Recive fueled motorcycle
                            // get valid wheel current pressure
                            getUserInputForMotorWheelPressure();

                            // get valid current energy 
                            getAndValidateEnergyCapacity(out s_CurrentAmountOfEnergy);
                            getDetailsAndCreateMotor(eEnergyType.Fueled);
                            break;
                        case 5:
                            // Recive Truck
                            // get valid wheel current pressure
                            getUserInputForTruckWheelPressure();

                            // get valid current energy 
                            getAndValidateEnergyCapacity(out s_CurrentAmountOfEnergy);
                            s_Menu.GetTruckDetailsFromUser(out s_CargoVolume, out s_IsDangerousMaterials);
                            s_Garage.ReciveNewTruck(s_OwnerName, s_OwnerPhoneNumber, s_LPN, s_Model, s_CurrentAirPressure, s_WheelManufactureName, s_CargoVolume, s_IsDangerousMaterials, s_CurrentAmountOfEnergy);
                            break;
                        case 6:
                            // Return to previous menu.
                            break;
                    }
                }
            }
        }

        private static void getAndValidateEnergyCapacity(out float i_CurrentAmountOfEnergy)
        {
            do
            {
                s_Menu.GetCurrentEnergyCapacity(out i_CurrentAmountOfEnergy);
            }
            while (!s_Garage.IsValidEnergyCapacity(i_CurrentAmountOfEnergy));
        }

        private static void showVehiclesLPNByState()
        {
            UserStateInput = s_Menu.GetStateFromUser("Select state to show all LPN by :");
            if (UserStateInput != eVehicleState.None)
            {
                s_VehicleLPNList = s_Garage.GetAllVehicleLPNByState(UserStateInput);
                if (s_VehicleLPNList.Count > 0)
                {
                    Console.WriteLine(@"State to be diaplayed : {0}", UserStateInput.ToString());
                    printAllLpnAndGetInput(s_VehicleLPNList, false);
                }
                else
                {
                    Console.WriteLine("No vehicle in the Garage.");
                }
            }
        }

        private static void setVehicleState()
        {
            // get all LPN
            s_VehicleLPNList = s_Garage.GetAllVehicleLPN();
            if (s_VehicleLPNList.Count > 0)
            {
                // print the LPN list and get input from user on witch LPN he want to change state ->userLPNInput
                printAllLpnAndGetInput(s_VehicleLPNList, true);

                // tell the user what is the current state of the selected LPN and than get input for state
                Console.WriteLine("The current state of the vehicle is : {0}, in case you choose the new state as the current state,\nfNo change will be made !", s_Garage.GetVehicleForDetails(s_UserLPNInput).VehicleState.ToString());
                UserStateInput = s_Menu.GetStateFromUser("Choose the new stage :");

                // add the logic for exit the menu
                if (UserStateInput != eVehicleState.None)
                {
                    s_Garage.ChangeVehicleState(s_UserLPNInput, UserStateInput);
                }
            }
            else
            {
                Console.WriteLine("No vehicle in the Garage.");
            }
        }

        private static void fillAirToVechile()
        {
            s_VehicleLPNList = s_Garage.GetAllVehicleLPN();
            if (s_VehicleLPNList.Count > 0)
            {
                // print the LPN list and get input from user on witch LPN he want to fill air in the wheels ->userLPNInput
                printAllLpnAndGetInput(s_VehicleLPNList, true);
                Vehicle vehicleToFillAir = s_Garage.GetVehicleForDetails(s_UserLPNInput);
                vehicleToFillAir.FillAirToMaxPressure();
            }
            else
            {
                Console.WriteLine("No vehicle in the Garage.");
            }
        }

        private static void fillFueledTypeVehicle()
        {
            // get all LPN for vehicle powered by 
            s_VehicleLPNList = s_Garage.GetAllVehicleLPN(eEnergyType.Fueled);
            if (s_VehicleLPNList.Count > 0)
            {
                // print the LPN list for electric vehicles and get input from user on witch LPN he want to charge ->userLPNInput
                printAllLpnAndGetInput(s_VehicleLPNList, true);
                Vehicle fueledVehicle = s_Garage.GetVehicleForDetails(s_UserLPNInput);
                Console.WriteLine(@"The current energy of the vehicle is {0:0.00} liter out of {1:0.00} liter", fueledVehicle.Energy.CurrentEnergy, fueledVehicle.Energy.MaxEnergy);

                // fill the vehicle.
                float amountOfFuelToCharge = s_Menu.GetEnergyCapacityToAdd("Please enter amount of fuel to add : ");

                // ask from user for fuel type
                eFuelType FuleTypeToFill = s_Menu.GetFueltypeFromUser();
                
                // charge the vehicle
                if (FuleTypeToFill != eFuelType.None)
                {
                    try
                    {
                        fueledVehicle.Energy.FillEnergy(amountOfFuelToCharge, FuleTypeToFill);
                    }
                    catch (ValueOutOfRangeException voor)
                    {
                        Console.WriteLine(voor.Message);
                    }
                    catch (ArgumentException a)
                    {
                        Console.WriteLine(a.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("No vehicle in the Garage.");
            }
        }

        private static void chargeElectricVehicle()
        {
            // get all LPN for vehicle powered by 
            s_VehicleLPNList = s_Garage.GetAllVehicleLPN(eEnergyType.Electric);

            // print the LPN list for electric vehicles and get input from user on witch LPN he want to charge ->userLPNInput
            if (s_VehicleLPNList.Count > 0)
            {
                printAllLpnAndGetInput(s_VehicleLPNList, true);

                // need to add : input from user 
                Vehicle elctricVeheicle = s_Garage.GetVehicleForDetails(s_UserLPNInput);

                if (Math.Floor(elctricVeheicle.Energy.MaxEnergy - elctricVeheicle.Energy.CurrentEnergy) != 0)
                {
                    Console.WriteLine(@"The current energy of the vehicle is {0:0.000} hours out of {1:0.000} hours", elctricVeheicle.Energy.CurrentEnergy, elctricVeheicle.Energy.MaxEnergy);
                    float numberOfMinuesToCharge;
                    do
                    {
                        numberOfMinuesToCharge = s_Menu.GetEnergyCapacityToAdd(string.Format(@"Please enter number of minutes to charge between 1 and {0:0.0}: ", Math.Floor((elctricVeheicle.Energy.MaxEnergy - elctricVeheicle.Energy.CurrentEnergy) * 60)));
                    }
                    while (((numberOfMinuesToCharge / 60) + elctricVeheicle.Energy.CurrentEnergy) > elctricVeheicle.Energy.MaxEnergy);

                    // charge the vehicle
                    elctricVeheicle.Energy.FillEnergy(numberOfMinuesToCharge);
                }
                else
                {
                    Console.WriteLine("The energy pack if full!");
                }
            }
            else
            {
                Console.WriteLine("No vehicle in the Garage.");
            }
        }

        private static void printVechileDetails()
        {
            s_VehicleLPNList = s_Garage.GetAllVehicleLPN();
            if (s_VehicleLPNList.Count > 0)
            {
                // print the LPN list and get input from user on witch LPN he want to change state ->userLPNInput
                printAllLpnAndGetInput(s_VehicleLPNList, true);
                Console.WriteLine(s_Garage.GetVehicleForDetails(s_UserLPNInput).ToString());
            }
            else
            {
                Console.WriteLine("No vehicle in the Garage.");
            }
        }
#endregion

        private static void manageMainProgramGarage()
        {
            while (s_UserInput >= 1 && s_UserInput <= 8 && !s_Exit)
            {
                s_UserInput = s_Menu.GetUserInputMainMenu();
                switch (s_UserInput)
                {
                    case 1: // Recive new Vehicle.
                        insertNewVehicle();
                        break;
                    case 2: // Show all vehicle LPN by state.
                        showVehiclesLPNByState();
                        break;
                    case 3: // Change vehicle state by LPN
                        setVehicleState();
                        break;
                    case 4: // Fill air in vehicle
                        fillAirToVechile();           
                        break;
                    case 5: // Fill fuled vehicle.
                        fillFueledTypeVehicle();
                        break;
                    case 6: // Charge electric vehicle.
                        chargeElectricVehicle();
                        break;
                    case 7: // Show vehicle details by LPN.
                        printVechileDetails();
                        break;
                    case 8: // Exit.
                        s_Exit = true;
                        break;
                }

                if (!s_Exit)
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
                s_UserLPNInput = s_Menu.SelectLPN(i_VehicleLPNToPring);
            }
        }

        private static void getDetailsAndCreateCar(eEnergyType i_EnergyType)
        {
            s_Menu.GetCarDetailsFromUser(out s_Color, out s_Doors);
            if (s_Color != eVehicleColor.None && s_Doors != eDoors.None)
            {
                if (i_EnergyType == eEnergyType.Electric)
                {
                    s_Garage.ReciveNewElectricCar(s_OwnerName, s_OwnerPhoneNumber, s_LPN, s_Model, s_CurrentAirPressure, s_WheelManufactureName, s_CurrentAmountOfEnergy, s_Color, s_Doors);
                }
                else
                {
                    s_Garage.ReciveNewFueledCar(s_OwnerName, s_OwnerPhoneNumber, s_LPN, s_Model, s_CurrentAirPressure, s_WheelManufactureName, s_CurrentAmountOfEnergy, s_Color, s_Doors);
                }
            }
        }

        private static void getDetailsAndCreateMotor(eEnergyType i_EnergyType)
        {
            s_Menu.GetMotorcycleDetailsFromUser(out s_Lisence, out s_EngineVolume);
            if (s_Lisence != eLicense.None)
            {
                if (i_EnergyType == eEnergyType.Electric)
                {
                    s_Garage.ReciveNewElectricMotorcycle(s_OwnerName, s_OwnerPhoneNumber, s_LPN, s_Model, s_CurrentAirPressure, s_WheelManufactureName, s_CurrentAmountOfEnergy, s_Lisence, s_EngineVolume);
                }
                else
                {
                    s_Garage.ReciveNewFueledMotorcycle(s_OwnerName, s_OwnerPhoneNumber, s_LPN, s_Model, s_CurrentAirPressure, s_WheelManufactureName, s_CurrentAmountOfEnergy, s_Lisence, s_EngineVolume);
                }
            }
        }

        private static void getUserInputForCarWheelPressure()
        {
            do
            {
                s_Menu.GetWheelPressure(out s_CurrentAirPressure);
            }
            while (!s_Garage.IsValidWheelPressureForCar(s_CurrentAirPressure));
        }

        private static void getUserInputForMotorWheelPressure()
        {
            do
            {
                s_Menu.GetWheelPressure(out s_CurrentAirPressure);
            }
            while (!s_Garage.IsValidWheelPressureForMotor(s_CurrentAirPressure));
        }

        private static void getUserInputForTruckWheelPressure()
        {
            do
            {
                s_Menu.GetWheelPressure(out s_CurrentAirPressure);
            }
            while (!s_Garage.IsValidWheelPressureForTruck(s_CurrentAirPressure));
        }
    }
}
