using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M
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

        private SevensOut _testSevensOut = new SevensOut(true);

        private ThreeOrMore _testThreeOrMore = new ThreeOrMore(true);

        private TextWriter _savedTextWriter;

        //Methods

        // <summary>
        // Runs a method on our Game property to set it up
        // </summary>
        private void SetupTests() {

            _testGame.Instantiate(3);
            _testThreeOrMore.Testing = true;
            _testSevensOut.Testing = true;

            _savedTextWriter = Console.Out;
            Console.SetOut(TextWriter.Null);

        }

        private void ThreeOrMoreScoreTest()
        {
            _testThreeOrMore.RollAll();
            int score = _testThreeOrMore.ScoreDice();
            Console.WriteLine(score);
            Debug.Assert(score == 3 || score == 6 || score == 12 || score == -1 || score == 0, "ThreeOrMore score out of range");
        }

        private void ThreeOrMoreTotalTest()
        {
            while (!_testThreeOrMore.IsOver())
            {
                _testThreeOrMore.Play();
            }



            Debug.Assert(_testThreeOrMore.GetScore() >= 20, "ThreeOrMore total not >= 20");


        }

        private void SevensOutTotalTest()
        {
            _testSevensOut.RollAll();
            _testSevensOut.Sum();
            Debug.Assert(_testSevensOut.Total >= 2 && _testSevensOut.Total <= 12, "SevensOut total out of range");
            Debug.Assert(_testSevensOut.Total == _testSevensOut.DieList[0].Value + _testSevensOut.DieList[1].Value, "SevensOut total incorrectly computed");
        }

        private void SevensOutSevenTest()
        {
            int rolledScore = 0;
            while (rolledScore != -1)
            {
                _testSevensOut.RollAll();
                _testSevensOut.Sum();
                rolledScore = _testSevensOut.ScoreDice();
            }
            Debug.Assert(_testSevensOut.Total == 7, "SevensOut total not 7");
        }

        // <summary>
        // Runs the Roll method on our Game object,
        // and checks if every Die objects value is in range using an assertion
        // </summary>
        private void RollTest()
        {
            _testGame.RollAll();
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
                SevensOutTotalTest();
                SevensOutSevenTest();
                ThreeOrMoreTotalTest();
                ThreeOrMoreScoreTest();
           
            }

            using (StreamWriter sw = File.AppendText("logs.txt"))
            {
                sw.WriteLine($"All tests passed succesfully (x9999) at {DateTime.Now}");
            }


            Console.SetOut(_savedTextWriter);
            Console.WriteLine("Testing finished succesfully");
            
        }
    }
}
