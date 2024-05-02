using System;
using System.Collections.Generic;
using System.Linq;  
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M
{
    interface IScoreable
    {
        int ScoreDice();
    }
    interface ITestable
    {
        bool Testing { get; set; }
    }
    internal class Game
    {
        /*
         * The Game class should create three die objects, roll them, sum and report the total of the three dice rolls.
         *
         * EXTRA: For extra requirements (these aren't required though), the dice rolls could be managed so that the
         * rolls could be continous, and the totals and other statistics could be summarised for example.
         */

        //Properties
        public List<Die> DieList { get; private set; } = new List<Die>();
        public int Total { get; private set; } = 0;

        protected int _score { get; set; } = 0;
        protected bool _isBot { get; set; } = false;
        protected bool _isOver { get; set; } = false;


        //Methods

        // <summary>
        // Instantiates the Die objects
        // </summary>
        public void Instantiate(int diceAmt)
        {
            for (int i = 0; i < diceAmt; i++)
            {
                Die die = new Die();
                DieList.Add(die);
            }
        }
       
        // <summary>
        // Runs the Roll method on all of the Die objects
        // </summary>
        public void RollAll()
        {
           foreach (Die d in DieList)
           {
                d.Roll();
           }
        }

        // <summary>
        // Sums up the value of all the Die objects and saves it in the Total property
        // </summary>
        public void Sum()
        {
            Total = 0;
            foreach (Die die in DieList)
            {
                Total += die.Value;
            }
        }

        // <summary>
        // Makes our private score property accessible
        // </summary>
        public int GetScore()
        {
            return _score;
        }

        // <summary>
        // Makes the games status property accessible
        // </summary>
        public bool IsOver()
        {
            return _isOver;
        }

        // <summary>
        // Writes the sum of the Die objects in the console
        // </summary>
        virtual public void Report()
        {
            Console.WriteLine($"The sum is {Total}");
        }

        // <summary>
        // Creates all Die objects, rolls them, sums then up and reports it to the console
        // </summary>
        virtual public void Play() {
            Console.WriteLine("Rolling..");
            Instantiate(3);
            RollAll();
            Sum();
            Report();
        }


    }
}
