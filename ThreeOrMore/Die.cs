//  Die class is responsible for generating random numbers which are going to be passed on to different classes.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeOrMore
{
    class Die
    {
        #region Roll      
        /// <summary>
        /// Roll the dice in order to receive 5 random numbers.
        /// </summary>
        /// <returns>Array with 5 random generated numbers</returns>
        public int[] Roll()
        {
            // Create new array.
            int[] result = new int[5];

            // Create new Random class object with seeded value.
            Random myDie = new Random((int)DateTime.Now.Ticks);

            // Loop through array, insert random number into array at index i.
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = myDie.Next(1, 7);
            }
            return result;
        }
        #endregion

        #region Roll (Custom die number)
        /// <summary>
        /// Roll the dice in order to receive custom number of random generated numbers.
        /// </summary>
        /// <param name="how_many_die">How many random numbers do you need?</param>
        /// <returns>Array with custom number of random generated numbers</returns>
        public int[] Roll(int how_many_die)
        {
            // Create new array. Array length is equa to 'how_many_die' value given in the method.
            int[] result = new int[how_many_die];

            // Create new Random class object with seeded value.
            Random myDie = new Random((int)DateTime.Now.Ticks);

            // Loop through array, insert random number into array at index i.
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = myDie.Next(1, 7);
            }
            return result;
        }
        #endregion  
    }
}