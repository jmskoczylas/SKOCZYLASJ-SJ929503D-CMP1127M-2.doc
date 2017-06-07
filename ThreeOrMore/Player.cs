// Player class is responsible for rolling the die.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeOrMore
{
    class Player
    {
        #region Player Roll
        /// <summary>
        /// Roll the die. 
        /// </summary>
        /// <returns>Array with 5 random integer values</returns>
        public int[] Player_Roll()
        {
            Die myDie = new Die();
            return myDie.Roll();
        }
        #endregion

        #region Player Roll (Custom die number)
        /// <summary>
        /// Roll the dice in order to receive custom number of random generated numbers.
        /// </summary>
        /// <param name="how_many_die">How many die do you wish to roll?</param>
        /// <returns>Array with custom number of random generated numbers<</returns>
        public int[] Player_Roll(int how_many_die)
        {
            Die myDie = new Die();
            return myDie.Roll(how_many_die);
        }
        #endregion
    }
}
