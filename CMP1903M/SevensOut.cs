using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*Sevens Out
2 x dice
Rules:
	Roll the two dice, noting the total rolled each time.
	If it is a 7 - stop.
	If it is any other number - add it to your total.
		If it is a double - add double the total to your score (3,3 would add 12 to your total)
*/

namespace CMP1903M
{
    internal class SevensOut : Game, IScoreable, ITestable
    {

        public bool Testing { get; set; } = false;

        private bool IsDouble()
        {
            if (DieList[0].Value == DieList[1].Value) 
            {
                return true;
            } 
            else 
            {
                return false;
            }
        }   

        public int ScoreDice()
        {
            if (Total == 7) 
            {
                return -1;
            } 
            else if (IsDouble())
            {
                return Total * 2;
            } 
            else 
            {
                return Total;
            }

        }

      

        public override void Play()
        {
            if (_isOver)
            {
                return;
            }
            int rolledScore = 0;
            while (rolledScore != -1)
            {
                if (!_isBot) 
                {
                    Console.WriteLine("Ready to roll? (Press Enter)");
                    Console.ReadLine();
                } else 
                {
                    Console.WriteLine("Bot is rolling..");
                    if (!Testing)
                        Thread.Sleep(1000);
                }
      
                RollAll();
                Sum();
                Report();

                rolledScore = ScoreDice();
                if (rolledScore != -1)
                {
                    _score += rolledScore;
                }
            }
            _isOver = true;
        }

        public SevensOut(bool isBot = false)
        {
            Instantiate(2);
            _isBot = isBot;
        }

        public override void Report()
        {
            // lets report both dice values
            Console.WriteLine($"The sum is {Total} ({DieList[0].Value} and {DieList[1].Value})");
        }
    }
}
