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
