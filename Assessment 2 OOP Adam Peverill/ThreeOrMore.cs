using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2_OOP_Adam_Peverill
{
    internal class ThreeOrMore : ColourSwitch, IGames
    {
        Die Die = new Die();

        // this variable sets the amount of points a player must reach in order to win.
        int Goal = 20;



        // Stores how many times the 1st player has won
        private static int P1_Wins = 0;
        
        public static int Score_p1
        {
            get { return P1_Wins; }
            set { P1_Wins = value; }
        }

        // Stores how many times the 2nd player has won
        private static int P2_Wins = 0;

        public static int Score_p2
        {
            get { return P2_Wins; }
            set { P2_Wins = value; }
        }

        // Stores the shortest amount of time it took for a player to win
        private static int Win_Time = 1000;
        public static int Time_win
        {
            get { return Win_Time; }
            set { Win_Time = value; }
        }

        public int Game(bool single_player, bool Test_loop)
        {

            List<int> Temp_List = new List<int>();
            bool Player_Won;

            int Counter = 0;
            int P1_Score = 0;
            int P2_Score = 0;

            while (P1_Score <= Goal || P2_Score <= Goal)
            {
                Counter++;

                /* 
                code line begins with the switch function to establish whos turn it is and change the colours of the console to make player turns more obvious
                The Gameplay functions plays out and is saved to a player temp value. This is due to the required use of the test class to try the results beforehand
                */

                // Player one. Test loop should be set as false unless the test class is using this function

                Switch();
                int P1_Temp = Gameplay(Temp_List, Test_loop, false);

                P1_Score += P1_Temp;

                bool Test1_Result = Test.TOM_DiceSum(P1_Score, P1_Temp, Goal);

                Console.WriteLine("\nYou have " + P1_Score + " Total");

                if (Test1_Result == true) { Player_Won = true; Console.Clear(); GameData(Counter, Player_Won); break; }

                // Player two. IF user selected single player, true will be set to the Gameplay function and cause a Psudo_random result for two of a kinds.

                Switch();
                int P2_Temp = Gameplay(Temp_List, single_player, false);

                bool Test2_Result = Test.TOM_DiceSum(P2_Score, P2_Temp, Goal);

                P2_Score += P2_Temp;

                Console.WriteLine("\nYou have " + P2_Score + " Total");

                if (Test2_Result == true) { Player_Won = false; Console.Clear(); GameData(Counter, Player_Won); break; }
            }

            Console.WriteLine("---- \n returning to menu...\n ---- \n");

            if (Counter <= Win_Time) { Win_Time = Counter; return Win_Time; }

            else { return Counter; }
            
        }


        internal int Gameplay(List<int> Temp_list, bool Single_player, bool TOAK_blocker)
        {
            // creates a new list 
            List<int> Player_list = new List<int>();

            // Values are kept as a Temp_total as players could chose to reroll if they were to achieve 3 of a kind and 2 of a kind at the same time.
            int Temp_Total = 0;

            // Roll Dice until the list has reached 5 elements. This allows for rerolls to occur.

            Console.WriteLine("Now rolling your dice \n ----");
            if (Temp_list.Count != 0)
            { 
                foreach(int i in Temp_list)
                {
                    Console.WriteLine("\tPlayer has stored: " + i);
                    Player_list.Add(i);
                }
            }

            while (Player_list.Count < 5)
            {
                int temp_dice = Die.Roll();

                Console.WriteLine("\tDice " + Player_list.Count + " Has Rolled: " + temp_dice);

                Player_list.Add(temp_dice);

            }

            Console.WriteLine("\n----");

            for (int j = 1; j <= 6; j++)
            {
                int counter = 0;

                foreach (int numbers in Player_list) { if (numbers == j) {counter++;} }

                // Both 5 and 4 break the loop as there is no possibility to gain a 2 of a kind 
                // 3 of a kind = 3 points,   4 of a kind = 6 points,  5 of a kind = 12 points

                if (counter == 5)
                { Temp_Total = 12; break; }

                else if (counter == 4)
                { Temp_Total = 6; break; }

                else if (counter == 3)
                { Console.WriteLine("You have the opportunity to gain 3 points!!"); Temp_Total = 3; }

                // if only two match, player can chose to reroll the non matching die (1), reroll every dice (2) or leave the results as they are. 
                // A temp bool called "TOAK_blocker" stops players from repeatedly rolling the dice they kept, now only allowing them to do it once per turn
                else if (counter == 2)
                {
                    // Holds the new results of the list
                    List<int> Reroll_results = new List<int>();

                    if (Single_player == false && TOAK_blocker == false)
                    {
                        try
                        {
                            Console.WriteLine("You have a two of a kind!! What would you like to do \n [1] Reroll Dice other than " + j + "\n [2] Reroll every Dice \n [3] Keep results");
                            TOAK_blocker = true;
                            Console.Read();
                            int User_response = Test.Usable_value(3);
                            

                            // User chose to keep the numbers from the list
                            if (User_response == 1)
                            { Reroll_results.Add(j); Reroll_results.Add(j); Temp_Total = Gameplay(Reroll_results, Single_player, TOAK_blocker); return Temp_Total; }

                            // User chose to reroll every dice
                            if (User_response == 2)
                            { Temp_Total = Gameplay(Reroll_results, Single_player, TOAK_blocker); return Temp_Total; }

                            else { break; }

                        }

                        catch (Exception ex) { Console.WriteLine(ex ); break; }

                    }


                    else if (Single_player == true && TOAK_blocker == false)
                    {
                        TOAK_blocker = true;

                        // simulates random choice. 
                        int Coin_flip = Die.Roll();

                        // If roll is bigger than 3; keep the numbers from the list

                        if (Coin_flip > 3)
                        { Reroll_results.Add(j); Reroll_results.Add(j); Temp_Total = Gameplay(Reroll_results, Single_player, TOAK_blocker); return Temp_Total; }

                        // if roll is less or equal to 3; reroll every dice

                        if (Coin_flip <= 3)
                        { Temp_Total = Gameplay(Reroll_results, Single_player, true); return Temp_Total; }

                    }

                    else { Console.WriteLine("Unlucky, the reroll yielded no valid results");  break; }
                }

            }
           
            Console.WriteLine("A total of " + Temp_Total + " points have been secured!");

            return Temp_Total;
        }

        internal int GameData(int Rounds, bool Winner)
        {

            if (Winner == true)
            {
                P1_Wins++;

                Console.WriteLine("Player One has won the game!");
                Console.WriteLine("This is their " + P1_Wins + "Win!");

                return P1_Wins;


            }

            else if (Winner == false)
            {
                P2_Wins++;

                Console.WriteLine("Player Two has won the game!");
                Console.WriteLine("This is their " + P2_Wins + " Win!");

                return P2_Wins;
            }

            else
            {
                throw new Exception("Unexpected Criteria: No Winner has been found");
            }

        }
    }
}
