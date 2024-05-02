using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2_OOP_Adam_Peverill
{
    // creates a new object which psudo-randomly picks between 1-6. 
    public class Die
    {
        static Random Rdm = new Random();
        public int Roll() { int Die_Result = Rdm.Next(1, 7); return Die_Result; }
    }
}
