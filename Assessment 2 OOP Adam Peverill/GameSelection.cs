using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2_OOP_Adam_Peverill
{
    // A class built around having the user select which game they would like to 
    internal class GameSelection
    {
        ThreeOrMore TOM = new ThreeOrMore();
        SevensOut SO = new SevensOut();
        Statistics SC = new Statistics();
        Test Tt =new Test();

        // Function for the user to chose between playing by themselves or with another player. 
        // This is saved to a bool and is sent to the class.
        internal bool Player_select()
        {
            Console.WriteLine("Which mode would you like to play in? \n[1] Multiplayer \n[2] Single Player");
            int User_response = Test.Usable_value(2);

            // Single player is off
            if (User_response == 1) { return false; }

            // Single player is on
            else { return true; }

        }


        // Has user select a number  between 1-5 which corresponds to different classes.
        public void Game_select()
        {
            bool Continue = true;

            while (Continue == true)
            {
                Console.WriteLine("Welcome to the games program! Please select what you would like to do \n----\n[1] Play Three-or-more \n[2] Play Sevens-Out \n[3] Check Statistics \n[4] Test program \n[5] Exit");

                int User_select = Test.Usable_value(5);

                //ThreeOrMore
                if (User_select == 1) { TOM.Game(Player_select(), false); }

                //SevensOut
                else if (User_select == 2) { SO.Game(); }

                //Statistics
                else if (User_select == 3) { SC.stats(); }

                //test
                else if (User_select == 4) { Tt.Game_testloop(); }

                //Quit
                else { Console.WriteLine("Thank you for playing! I hope to see you again sometime!"); Continue = false; break; }

            }

        }

    }
}
