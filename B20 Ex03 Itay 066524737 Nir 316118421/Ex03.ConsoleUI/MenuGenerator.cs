using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    class MenuGenerator
    {
        public int GetUserInputMainMenu()
        {
            int userInput;
            string userInputStr;
            Console.WriteLine(r_Splash);
            Console.WriteLine("Main Menu  -  C & C LTD.");
            Console.WriteLine("=============================");
            Console.WriteLine("1. Recive new Vehicle. ");
            Console.WriteLine("2. Show all vehicle LPN by state. ");
            Console.WriteLine("3. Change vehicle state by LPN ");
            Console.WriteLine("4. Fill air in vehicle ");
            Console.WriteLine("5. Fill fuled vehicle. ");
            Console.WriteLine("6. Charge electric vehicle. ");
            Console.WriteLine("7. Show vehicle details by LPN. ");
            Console.WriteLine("8. Exit. ");
            Console.WriteLine("-----------------------------");
            Console.Write("Enter your choice : ");
            userInputStr = Console.ReadLine();
            while (int.TryParse(userInputStr, out userInput) && (userInput < 1 || userInput > 8))
            {
                Console.WriteLine("Please enter number of you choice (1-8)");
                userInputStr = Console.ReadLine();
            }

            return userInput;
        }
        public eVehicleState GetStateOfVehicle()
        {
            int userInput;
            string userInputStr;
            Console.WriteLine("Choose state of vehicle :");
            Console.WriteLine("---------------------------");
            Console.WriteLine("1. On repair. ");
            Console.WriteLine("2. Fixed. ");
            Console.WriteLine("3. Payed. ");
            Console.WriteLine("4. Return to previous menu. ");
            Console.WriteLine("-----------------------------");
            Console.Write("Enter your choice : ");
            userInputStr = Console.ReadLine();
            while (int.TryParse(userInputStr, out userInput) && (userInput < 1 || userInput > 4))
            {
                Console.WriteLine("Please enter number of you choice (1-4)");
                userInputStr = Console.ReadLine();
            }

            return (eVehicleState)userInput;
        }

        public eVehicleState GetStateFromUser(string i_MenuHeader)
        {
            int userInput;
            string userInputStr;
            Console.WriteLine(i_MenuHeader);
            Console.WriteLine("---------------------------");
            Console.WriteLine("1. On repair. ");
            Console.WriteLine("2. Fixed. ");
            Console.WriteLine("3. Payed. ");
            Console.WriteLine("-----------------------------");
            Console.Write("Enter your choice : ");
            userInputStr = Console.ReadLine();
            while (int.TryParse(userInputStr, out userInput) && (userInput < 1 || userInput > 3))
            {
                Console.WriteLine("Please enter number of you choice (1-3)");
                userInputStr = Console.ReadLine();
            }

            return (eVehicleState)userInput;
        }

        public int AddVehicle()
        {
            int userInput;
            string userInputStr;
            Console.WriteLine(r_Splash);
            Console.WriteLine("Select type of car to recive");
            Console.WriteLine("=============================");
            Console.WriteLine("1. Recive electric car. ");
            Console.WriteLine("2. Recive fueled car. ");
            Console.WriteLine("3. Recive electric motorcycle. ");
            Console.WriteLine("4. Recive fueled motorcycle ");
            Console.WriteLine("5. Recive Truck ");
            Console.WriteLine("6. Return to previous menu. ");
            Console.WriteLine("-----------------------------");
            Console.Write("Enter your choice : ");
            userInputStr = Console.ReadLine();
            while (int.TryParse(userInputStr, out userInput) && (userInput < 1 || userInput > 6))
            {
                Console.WriteLine("Please enter number of you choice (1-6)");
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
         "                                    _.--\"\"'-----,   `\"--.._\n"
        + "                                .-''   _/_      ; .'\"----,`-,\n"
        + "                               .'      :___:     ; :      ;;`.`.\n"
        + "                              .      _.- _.-    .' :      ::  `..\n"
        + "                           __;..----------------' :: ___  ::   ;;\n"
        + "                      .--\"\". '           ___.....`:=(___)-' :--'`.\n"
        + "                    .'   .'         .--''__       :       ==:    ;\n"
        + "                .--/    /        .'.''     ``-,   :         :   '`-.\n"
        + "             .\"', :    /       .'-`\\\\       .--.\\ :         :  ,   _\\\n"
        + "            ;   ; |   ;       /:'  ;;      /__  \\\\:         :  :  /_\\\\\n"
        + "            |\\_/  |   |      / \\__//      /\"--\\\\ \\:         :  : ;|`\\|    \n"
        + "            : \"  /\\__/\\____//   \"\"\"      /     \\\\ :         :  : :|'||\n"
        + "          [\"\"\"\"\"\"\"\"\"--------........._  /      || ;      __.:--' :|//|\n"
        + "           \"------....______         ].'|      // |--\"\"\"'__...-'`\\ \\//\n"
        + "             `| C&C LTD |__;_...--'\": :  \\    //  |---\"\"\"      \\__\\_/\n"
        + "               \"\"\"\"\"\"\"\"\"'            \\ \\  \\_.//  /\n"
        + "                 `---'                \\ \\_     _'\n";
    }
}
