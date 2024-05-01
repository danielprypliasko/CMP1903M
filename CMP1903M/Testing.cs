using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Testing
    {
        /*
         * This class should test the Game and the Die class.
         * Create a Game object, call the methods and compare their output to expected output.
         * Create a Die object and call its method.
         * Use debug.assert() to make the comparisons and tests.
         */

        //Properties
        private Game _testGame = new Game();

        //Methods

        // <summary>
        // Runs a method on our Game property to set it up
        // </summary>
        private void SetupTests() {

            _testGame.Instantiate();
        }

        // <summary>
        // Runs the Roll method on our Game object,
        // and checks if every Die objects value is in range using an assertion
        // </summary>
        private void RollTest()
        {
            _testGame.Roll();
            foreach (Die die in _testGame.DieList)
            {
                Debug.Assert(die.Value >= 1 && die.Value <= 6, "Die value out of range");
            }
        }

        // <summary>
        // Runs the Sum method on our Game object,
        // and checks if the Sum is correct by summing up all the Die objects and comparing with an Assertion
        // </summary>
        private void SumTest() {
            _testGame.Sum();
            int total = 0;
            foreach (Die die in _testGame.DieList)
            {
                total += die.Value;
            }
            Debug.Assert(_testGame.Total == total, "Die sum incorrectly computed");
        }

        // <summary>
        // Sets up and runs the proper tests,
        // outputs to console when done
        // </summary>
        public void Test()
        {
            SetupTests();
            for (int i = 0; i < 9999; i++)
            {
                RollTest();
                SumTest();
            }
            Console.WriteLine("Testing finished succesfully");
        }
    }
}
