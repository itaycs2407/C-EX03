﻿using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class MenuGenerator
    {
        public int GetUserInputMainMenu()
        {
            Console.WriteLine(r_Splash);
            Console.WriteLine(@"Main Menu  -  C & C LTD.
=============================
1. Recive new Vehicle
2. Show all vehicle LPN by state
3. Change vehicle state by LPN
4. Fill to MAX air presure in vehicle
5. Fill fuled vehicle
6. Charge electric vehicle
7. Show vehicle details by LPN
8. Exit
-----------------------------
Enter your choice : "); 
            return getUsersInput(1, 8);
        }

        public eVehicleState GetStateFromUser(string i_MenuHeader)
        {
            Console.WriteLine(i_MenuHeader);
            Console.WriteLine(@"---------------------------
1. On repair
2. Fixed
3. Payed
4. Return to main menu.
-----------------------------
Enter your choice : ");
            return (eVehicleState)(getUsersInput(1, 4) % 4);
        }

        public void GetGenralDetailsFromUser(out string i_OwnerName, out string i_OwnerPhoneNumber, out string i_Model, out string i_WheelManufactureName)
        {
            Console.Write("Enter owner name :");
            i_OwnerName = Console.ReadLine();
            Console.Write("Enter owner phonenumber :");
            i_OwnerPhoneNumber = Console.ReadLine();
            Console.Write("Enter vehicle model :");
            i_Model = Console.ReadLine();
            Console.Write("Enter wheels manufacture name :");
            i_WheelManufactureName = Console.ReadLine();
        }

        public void GetVehicleLPN(out string i_LPN)
        {
            Console.Write("Enter vehicle LPN (License Plate Number) :");
            i_LPN = Console.ReadLine();
        }

        public void GetWheelPressure(out float io_CurrentAirPressure)
        {
            string CurrentAirPressureSTR;
            Console.Write("Enter current wheel pressure (must be below manufacture max pressure) : ");
            CurrentAirPressureSTR = Console.ReadLine();
            while (!float.TryParse(CurrentAirPressureSTR, out io_CurrentAirPressure) || (io_CurrentAirPressure < 0))
            {
                if (io_CurrentAirPressure < 0)
                {
                    Console.Write("Wrong input. Wheel pressure cant be under 0. Enter current wheel pressure :");
                }
                else
                {
                    Console.Write("Wrong input.None float value, enter current wheel pressure :");
                }

                CurrentAirPressureSTR = Console.ReadLine();
            }
        }

        public void GetCurrentEnergyCapacity(out float io_CurrentAmountOfEnergy)
        {
            string CurrentAmountOfEnergySTR;

            Console.Write("Enter current amount of energy (between 0 - 1, represnting %):");
            CurrentAmountOfEnergySTR = Console.ReadLine();
            CurrentAmountOfEnergySTR.Replace(" ", string.Empty);
            while (!float.TryParse(CurrentAmountOfEnergySTR, out io_CurrentAmountOfEnergy) || (CurrentAmountOfEnergySTR == string.Empty) || (io_CurrentAmountOfEnergy < 0 ))
            {
                if (io_CurrentAmountOfEnergy < 0)
                {
                    Console.Write("Wrong input. Current energy capacity cant be under 0. Enter current amount of energy :");
                }
                else if (CurrentAmountOfEnergySTR == string.Empty)
                {
                    Console.Write("Wrong input. Value cant be empty. Enter current amount of energy :");
                }
                else
                {
                    Console.Write("Wrong input. Value must be float. Enter current amount of energy :");
                }

                CurrentAmountOfEnergySTR = Console.ReadLine();
            }
        }

        public void GetCarDetailsFromUser(out eVehicleColor io_Color, out eDoors io_Doors)
        {
            Console.WriteLine("Select Color :");
            Console.WriteLine(@"---------------------------
1. Red.
2. White.
3. Black.
4. Silver.
5. Cancel and return to main menu
-----------------------------
Enter your choice : ");
            io_Color = (eVehicleColor)(getUsersInput(1, 5) % 5);
            if (io_Color != eVehicleColor.None)
            {
                Console.WriteLine("Select number of doors :");
                Console.WriteLine(@"---------------------------
1. 2 doors - Cuppe.
2. 3 doors - TreeDoorCuppe.
3. 4 doors - Sedan.
4. 5 doors - Wagen.
5. Cancel and return to main menu
-----------------------------
Enter your choice : ");
                io_Doors = (eDoors)(getUsersInput(1, 5) % 5);
            }
            else
            {
                io_Doors = eDoors.None;
            }
        }

        public void GetTruckDetailsFromUser(out float io_CargoVolume, out bool io_IsDangerousMaterials)
        {
            string cargoVolumeSTR, boolUserInputSTR;
            int v_BoolUserInput;
            Console.Write("Enter cargo volume :");
            cargoVolumeSTR = Console.ReadLine();
            while (float.TryParse(cargoVolumeSTR, out io_CargoVolume) && io_CargoVolume < 0)
            {
                Console.Write("Wrong input. Enter cargo volume :");
                cargoVolumeSTR = Console.ReadLine();
            }

            Console.Write("Enter 1 if carry dangerous materials, 0 if not :");
            boolUserInputSTR = Console.ReadLine();
            while (int.TryParse(boolUserInputSTR, out v_BoolUserInput) && v_BoolUserInput != 0 && v_BoolUserInput != 1)
            {
                Console.Write("Wrong input. Enter 1 if carry dangerous materials, 0 if not :");
                boolUserInputSTR = Console.ReadLine();
            }

            io_IsDangerousMaterials = v_BoolUserInput == 1 ? true : !true;
        }

        public void GetMotorcycleDetailsFromUser(out eLicense io_Lisence, out int io_EngineVolume)
        {
            string engineVolumeStr;
            Console.Write("Enter engine volume :");
            engineVolumeStr = Console.ReadLine();
            while (int.TryParse(engineVolumeStr, out io_EngineVolume) && io_EngineVolume < 1)
            {
                Console.Write("Wrong input. Enter engine volume :");
                engineVolumeStr = Console.ReadLine();
            }

            Console.WriteLine("Select license :");
            Console.WriteLine(@"---------------------------
1. A
2. A1
3. AA
4. B
5. Cancel and return to main menu
-----------------------------
Enter your choice : ");
            io_Lisence = (eLicense)(getUsersInput(1, 5) % 5);
        }

        public eFuelType GetFueltypeFromUser()
        {
            Console.WriteLine("Choose fuel type :");
            Console.WriteLine(@"---------------------------
1. Octan 95
2. Octan 96
3. Octan 98
4. Soler
5.Cancel and return to main menu
-----------------------------
Enter your choice : ");
            return (eFuelType)(getUsersInput(1, 5) % 5);
        }

        public int AddVehicle()
        {
            Console.WriteLine(r_Splash);
            Console.WriteLine(@"Select type of car to recive
=============================
1. Recive electric car
2. Recive fueled car
3. Recive electric motorcycle
4. Recive fueled motorcycle
5. Recive Truck
6. Return to previous menu
-----------------------------
Enter your choice : ");
            return getUsersInput(1, 6);
        }

        private int getUsersInput(int i_LowIntLimit, int i_HighIntLimit)
        {
            int userInput = 0;
            string userInputStr = Console.ReadLine();
            userInputStr.Replace(" ", string.Empty);
            while ((int.TryParse(userInputStr, out userInput) && (userInputStr == string.Empty)) || (userInput < i_LowIntLimit || userInput > i_HighIntLimit))
            {
                Console.WriteLine("Please enter number of you choice ({0}-{1})", i_LowIntLimit, i_HighIntLimit);
                userInputStr = Console.ReadLine();
            }

            return userInput;
        }

        public string SelectLPN(List<string> i_AllVehicleLPN)
        {
            string userInputSTR;
            Console.WriteLine("Please select LPN from the list above :");
            userInputSTR = Console.ReadLine();
            while (!i_AllVehicleLPN.Contains(userInputSTR))
            {
                Console.WriteLine("Wrong input. Please try again and select LPN from the list above :");
                userInputSTR = Console.ReadLine();
            }

            return userInputSTR;
        }

        private readonly string r_Splash =
         "                                    .--\"\"'-----,   `\"--..\n"
        + "                                .-''   /      ; .'\"----,`-,\n"
        + "                               .'      :_:     ; :      ;;`.`.\n"
        + "                              .      _.- _.-    .' :      ::  `..\n"
        + "                           _;..----------------' :: __  ::   ;;\n"
        + "                      .--\"\". '           _.....`:=(_)-' :--'`.\n"
        + "                    .'   .'         .--''__       :       ==:    ;\n"
        + "                .--/    /        .'.''     ``-,   :         :   '`-.\n"
        + "             .\"', :    /       .'-`\\\\       .--.\\ :         :  ,   _\\\n"
        + "            ;   ; |   ;       /:'  ;;      /_  \\\\:         :  :  /\\\\\n"
        + "            |\\_/  |   |      / \\__//      /\"--\\\\ \\:         :  : ;|`\\|    \n"
        + "            : \"  /\\_/\\_//   \"\"\"      /     \\\\ :         :  : :|'||\n"
        + "          [\"\"\"\"\"\"\"\"\"--------........._  /      || ;      __.:--' :|//|\n"
        + "           \"------....__         ].'|      // |--\"\"\"'__...-'`\\ \\//\n"
        + "             `| C&C LTD |_;...--'\": :  \\    //  |---\"\"\"      \\_\\/\n"
        + "               \"\"\"\"\"\"\"\"\"'            \\ \\  \\_.//  /\n"
        + "                 `---'                \\ \\_     _'\n";

        public float GetEnergyCapacityToAdd(string i_AskFromUser)
        {
            Console.Write(i_AskFromUser);
            string userInputSTR = Console.ReadLine();
            float userInput;
            while (float.TryParse(userInputSTR, out userInput) && userInput < 0)
            {
                Console.Write("wrong input, " + i_AskFromUser);
                userInputSTR = Console.ReadLine();
            }

            return userInput;
        }
    }
}