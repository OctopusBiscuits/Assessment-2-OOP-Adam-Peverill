using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2_OOP_Adam_Peverill
{
    // These mechanics are required by both games.
    internal class ColourSwitch
    {

        bool isFirst = false;

        protected void First()
        {
            isFirst = true;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nIt is Player One's turn");
            Console.Read();
        }

        protected void Second()
        {
            isFirst = false;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nIt is Player Two's turn");
            Console.Read();
        }

        // Switch() swaps between First and Second depending on if the bool 'isFirst' is set to true or false.
        public void Switch()
        {
            if (isFirst == true)
            {
                Second();

                
            }

            else 
            {
                First();
            }
        }

    }
}
