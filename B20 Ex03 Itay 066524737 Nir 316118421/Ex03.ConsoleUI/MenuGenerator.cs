using Ex03.GarageLogic;
using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    class MenuGenerator
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
        public eVehicleState GetStateOfVehicle()
        {
            Console.WriteLine(@"Choose state of vehicle :
---------------------------
1. On repair
2. Fixed
3. Payed
4. Return to previous menu
-----------------------------
Enter your choice : ");
            return (eVehicleState)(getUsersInput(1, 4)-1);
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
            return (eVehicleState)(getUsersInput(1, 3)-1);
        }

        public void GetGenralDetailsFromUser(out string i_OwnerName, out string i_OwnerPhoneNumber, out string i_Model, out string i_LPN, out string i_WheelManufactureName, out float i_CurrentAirPressure, out float i_CurrentAmountOfEnergy)
        {
            string CurrentAirPressureSTR, CurrentAmountOfEnergySTR;
            Console.Write("Enter owner name :");
            i_OwnerName = Console.ReadLine();
            Console.Write("Enter owner phonenumber :");
            i_OwnerPhoneNumber = Console.ReadLine();
            Console.Write("Enter vehicle LPN (License Plate Number) :");
            i_LPN = Console.ReadLine();
            Console.Write("Enter vehicle model :");
            i_Model = Console.ReadLine();
            Console.Write("Enter wheels manufacture name :");
            i_WheelManufactureName = Console.ReadLine();
            Console.Write("Enter current wheel pressure :");
            CurrentAirPressureSTR = Console.ReadLine();
            while (float.TryParse(CurrentAirPressureSTR, out i_CurrentAirPressure) && i_CurrentAirPressure < 0 )
            {
                Console.Write("Wrong input. Enter current wheel pressure :");
                CurrentAirPressureSTR = Console.ReadLine();
            }
            Console.Write("Enter current amount of energy :");
            CurrentAmountOfEnergySTR = Console.ReadLine();
            while (float.TryParse(CurrentAirPressureSTR, out i_CurrentAmountOfEnergy) && i_CurrentAmountOfEnergy < 0)
            {
                Console.Write("Wrong input. Enter current amount of energy :");
                CurrentAmountOfEnergySTR = Console.ReadLine();
            }
        }

       
        internal void GetCarDetailsFromUser(out eVehicleColor io_Color, out eDoors io_Doors)
        {
            Console.WriteLine("Select Color :");
            Console.WriteLine(@"---------------------------
1. Red.
2. White.
3. Black.
4. Silver.
-----------------------------
Enter your choice : ");
            io_Color = (eVehicleColor)getUsersInput(1, 4);
            Console.WriteLine("Select number of doors :");
            Console.WriteLine(@"---------------------------
1. 2 doors - Cuppe.
2. 3 doors - TreeDoorCuppe.
3. 4 doors - Sedan.
4. 5 doors - Wagen.
-----------------------------
Enter your choice : ");
            io_Doors = (eDoors)getUsersInput(1, 4);
        }


    internal void GetTruckDetailsFromUser(out float io_CargoVolume, out bool io_IsDangerousMaterials)
        {
            string cargoVolumeSTR, boolUserInputSTR;
            int boolUserInput;
            Console.Write("Enter cargo volume :");
            cargoVolumeSTR = Console.ReadLine();
            while (float.TryParse(cargoVolumeSTR, out io_CargoVolume) && io_CargoVolume < 0)
            {
                Console.Write("Wrong input. Enter cargo volume :");
                cargoVolumeSTR = Console.ReadLine();
            }
            Console.Write("Enter 1 if carry dangerous materials, 0 if not :");
            boolUserInputSTR = Console.ReadLine();
            while (int.TryParse(boolUserInputSTR, out boolUserInput) && boolUserInput != 0 && boolUserInput != 1)
            {
                Console.Write("Wrong input. Enter 1 if carry dangerous materials, 0 if not :");
                boolUserInputSTR = Console.ReadLine();
            }
            io_IsDangerousMaterials = boolUserInput == 1 ? true : !true;
        }

        internal void GetMotorcycleDetailsFromUser(out eLicense io_Lisence, out int io_EngineVolume)
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
-----------------------------
Enter your choice : ");
            io_Lisence = (eLicense)getUsersInput(1, 4);
        }
           
        public eFuelType GetFueltypeFromUser()
        {
            Console.WriteLine("Choose fuel type :");
            Console.WriteLine(@"---------------------------
1. Octan 95
2. Octan 96
3. Octan 98
4. Soler
-----------------------------
Enter your choice : ");
            return (eFuelType)getUsersInput(1, 4);
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
            userInputStr.Replace(" ", "");
            while (int.TryParse(userInputStr, out userInput) && (userInputStr == string.Empty) || (userInput < i_LowIntLimit || userInput > i_HighIntLimit))
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