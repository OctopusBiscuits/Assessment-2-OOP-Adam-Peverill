using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2_OOP_Adam_Peverill
{
    // These mechanics are required by both games.
    internal class ParentGame
    {

        bool isFirst;
        protected void First()
        {
            isFirst = true;

            Console.WriteLine("It is Player One's turn");
            Console.Read();
        }

        protected void Second()
        {
            isFirst = false;

            Console.WriteLine("It is Player Two's turn");

            Console.Read();
        }

        public void PlayerSwitch()
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
