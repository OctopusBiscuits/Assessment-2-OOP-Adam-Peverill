using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Assessment_2_OOP_Adam_Peverill
{
    internal class SevensOut : ColourSwitch, IGames
    {
        Die Die = new Die();

        // this variable sets the amount of points a player must reach in order to win.
        int Goal = 300;

        private static int P1_Wins = 0;


        // Stores how many times the 1st player has won
        public static int Score_p1
        {
            get { return P1_Wins; }
            set { P1_Wins = value; }
        }

        // Stores how many times the 2nd player has won
        private static  int P2_Wins = 0;

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

        bool Player_Won;

        public int Game()
        {

            int Counter = 0;
            int P1_Score = 0;
            int P2_Score = 0;

            while (P1_Score <= Goal || P2_Score <= Goal)
            {

                Counter++;

                Switch();
                P1_Score = Gameplay(P1_Score);

                Console.WriteLine("\nYou have " + P1_Score + " Total");

                if (P1_Score >= Goal) { Player_Won = true; Console.Clear(); GameData(Counter, Player_Won); break; }

                Switch();
                P2_Score = Gameplay(P2_Score);

                Console.WriteLine("\nYou have " + P2_Score + " Total so far");

                if (P2_Score >= Goal) { Player_Won = false; Console.Clear(); GameData(Counter, Player_Won); break; }


            }

            if (Counter <= Win_Time) { Win_Time = Counter; }

            Console.WriteLine("---- \n returning to menu...\n ---- \n");
            return Win_Time;
        }

        internal int Gameplay(int Total)
        {
            bool Game_Stop = false;

            while (Game_Stop == false)
            {
                int D1 = Die.Roll();
                int D2 = Die.Roll();

                int D_Result = D1 + D2;

                Console.WriteLine("You have rolled: " + D1 + ", and " + D2);

                // If D1 and D2 create 7, the loop breaks.
                if (Test.SO_DiceSum(D1,D2) == true)
                {
                    Console.Write("Bad luck! You've rolled a 7!\n\n");

                    break;
                }

                // If D1 and D2 are the same value, the resulting points will be doubled 
                // Result Double is made as a seperate value so that it can be added to the console
                else if (D1 == D2)
                {
                    int R_Double = (D1 + D2) * 2;
                    Total += R_Double;

                    Console.Write("Thats a double! " + D_Result + " Has been added to your total!\n\n");
                }

                // IF D1 and D2 don't match and if the dice added together don't create 7, add the result to total
                else if (D1 != D2 && D1 + D2 != 7)
                {
                    Total += (D1 + D2);

                    Console.Write(D_Result + " Has been added to your total!\n\n");
                }

                // There shouldn't be any other results from this, therefore an exception is thrown if the value meets none of the criteria
                //else
                //{
                //   throw new Exception("Unexpected Criteria");
                //}

                if (Total > Goal)
                {
                    Console.WriteLine("The Point Goal Has been reached!");

                    break;
                }
            }

            Console.ResetColor();

            Console.WriteLine("\n----");

            return Total;
        }


        internal int GameData(int Rounds, bool Winner)
        {

            if (Winner == true)
            {
                P1_Wins++;
     
                Console.WriteLine("Player One has won the game!");
                Console.WriteLine("This is their " + P1_Wins + " Win!");

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
