using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Die
    {
        /*
         * The Die class should contain one property to hold the current die value,
         * and one method that rolls the die, returns and integer and takes no parameters.
         */

        //Properties
        public int Value {  get; private set; }
        private static Random _random = new Random();

        //Methods

        // <summary>
        // Gets a random number and saves it to the Value property, as well as returning it
        // </summary>
        // <returns>
        // An integer representing the value on the Die object after it has been rolled
        // </returns>
        public int Roll() { 
            Value = _random.Next(1, 7);
            return Value;
        }


    }
}
