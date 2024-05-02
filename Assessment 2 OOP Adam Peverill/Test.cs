using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2_OOP_Adam_Peverill
{
    internal class Test
    {
        // Implemented into SevensOut to check both dice and whether both dice equal to 7
        public static bool SO_DiceSum(int D1, int D2)
        {
            bool Seven_Trigger = false;


            // Checks if Dice sum is correct
            Debug.Assert(D1 > 0 && D1 <= 6, "Logic error: Dice is not between 1 and 6");

            Debug.Assert(D2 > 0 && D1 <= 6, "Logic error: Dice is not between 1 and 6");

            // If D1 and D2 create 7, the loop breaks.

            if (D1 + D2 == 7) { Debug.Assert(D1 + D2 == 7, "Logic error: both dice do not equal 7"); Seven_Trigger = true; }

            return Seven_Trigger;
        }

        // Test for Three Or more to check if score is added correctly and is above 20. Static to be used directly in the program.
        public static bool TOM_DiceSum(int Score, int temp_score, int Goal)
        {
           bool Goal_Trigger = false;

            // scores set and added correctly
            int Test_score = Score + temp_score;

            Debug.Assert(Test_score == Score + temp_score);

            //Recognised when total is >= 20
            if (Test_score >= Goal) { Goal_Trigger = true; }

            return Goal_Trigger;
        }



        // Tests several instances of a games program and returns the amount of rounds the games took
        public void Game_testloop()
        {
            /* Process process = new Process();
               process.canceloutputread()
               process.start() */

            List<int> Round_Holder = new List<int>();

            
            try
            {
                Console.WriteLine("[1] Test Three or more \n[2] Test Sevens Out");
                int Test_select = Test.Usable_value(2);

                if (Test_select == 1)
                {
                    ThreeOrMore TOM = new ThreeOrMore();

                    for (int i = 0; i < 50; i++) { Round_Holder.Add(TOM.Game(true, true)); }
                }

                else if (Test_select == 2)
                {
                    SevensOut SO = new SevensOut();

                    for (int i = 0; i < 50; i++) { Round_Holder.Add(SO.Game()); }
                }

            }

            catch (Exception ex) { Console.WriteLine(ex); }

            finally
            { 
                foreach (int i in Round_Holder) { Console.Write(i + ","); }

                Console.Read();
            }
        }


        // Usable Value checks to see if a user input is logically allowed and is within a set number parameter. this stops wrong inputs from distrupting the code flow.
        // This was adapted code from previous assignment: Adam Peverill 27646423 [2024] 'DiceGame', CMP1903-2324, University Of Lincoln, Assignment

        public static int Usable_value(int Value_size)
        {
            // Holds the tested integer given by the user, returning it to be used for array selection.

            int Temp_Output;

            // Bool variables to allow a method to start and stop loops.

            bool UsableInteger = false;

            Console.WriteLine("\n");

            var UserInput = Console.ReadLine();

            while (UsableInteger == false)
            {

                bool UsableInput = int.TryParse(UserInput, out Temp_Output);

                // If the Usable is seen as an integer and the output is the same or smaller than the value size parameter, return the output to the main program

                if (UsableInput == true && Temp_Output <= Value_size)
                {
                    UsableInteger = true;

                    return Temp_Output;
                }

                // If the previous conditions are not met, an error message is sent and the programs enters an iteration loop until demands are filled.

                else
                {
                    Console.WriteLine("\n");

                    Temp_Output = Usable_value(Value_size);

                    return Temp_Output;
                }

            }

            return 0;
        }
    }
}

