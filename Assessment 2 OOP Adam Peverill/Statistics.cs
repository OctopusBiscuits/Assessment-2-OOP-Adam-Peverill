using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2_OOP_Adam_Peverill
{
    internal class Statistics
    {
        // Displays user wins and fastest round in the console. 
        public void stats()
        {
            // Three Or More

            Console.WriteLine("Three Or More stats \n ---- \n");

            Console.WriteLine(" Player One Wins " + ThreeOrMore.Score_p1 + "\n Player Two Wins " + ThreeOrMore.Score_p2 + "\n Least amount of turns" + ThreeOrMore.Time_win + "\n ---- \n");

            // Sevens out 

            Console.WriteLine("Sevens Out \n ---- \n");

            Console.WriteLine(" Player One Wins " + SevensOut.Score_p1 + "\n Player Two Wins " + SevensOut.Score_p2 + "\n Least amount of turns" + SevensOut.Time_win + "\n ---- \n");


            Console.WriteLine("\n Press enter to go back to Game select...");
            Console.Read();
        }
    }
}
