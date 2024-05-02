
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/*
Three or More
5 x dice
Rules:
	Roll all 5 dice hoping for a 3-of-a-kind or better.
	If 2-of-a-kind is rolled, player may choose to rethrow all, or the remaining dice.
	3-of-a-kind: 3 points
	4-of-a-kind: 6 points
	5-of-a-kind: 12 points
	First to a total of 20.
 */

namespace CMP1903M
{
    internal class ThreeOrMore : Game, IScoreable, ITestable
    {

        public bool Testing { get; set; } = false;

        private Dictionary<int, int> DiceCount { get; set; } = new Dictionary<int, int>();

        private static Random _random = new Random();

        private void RollRemaining()
        {
            for (int i = 0; i < DieList.Count; i++)
            {
                if (DiceCount[DieList[i].Value] != 1)
                {
                    DieList[i].Roll();
                }
            } 
        }

        public int ScoreDice()
		{

		

            for (int i = 1; i <= 6; i++)
            {
                DiceCount[i] = 0;
            }
            foreach (Die die in DieList)
            {
                DiceCount[die.Value]++;
   }

            int uniqueValues = DiceCount.Count(x => x.Value == 1);

            switch (uniqueValues)
            {
                case 5:
                    return 12;
                case 4:
                    return 6;
                case 3:
                    return 3;
                case 2:
                    return -1;
                default:
                    return 0;
            }


        }

        public override void Report()
        {
            // report the score and the values of all the dice in one console.write line
            string diceValues = String.Join(", ", DieList.Select(x => x.Value));
            Console.WriteLine($"Dice: ({diceValues})");


        }

        public ThreeOrMore(bool isBot = false)
        {
            Instantiate(5);
            _isBot = isBot;
        }

        public override void Play()
        {
            if (_isOver)
            {
                return;
            }

            if (_isBot)
            {
                Console.WriteLine("Bot is rolling..");
                if (!Testing)
                    Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("Ready to roll? (Press Enter)");
                Console.ReadLine();
            }

            RollAll();
            int rolledScore = ScoreDice();
            Report();

            while (rolledScore == -1)
            {
                Console.WriteLine("Two of a kind!");
                if (_isBot)
                {
                    int botChoice = _random.Next(1, 3);
                    if (botChoice == 1)
                    {
                        RollAll();
                    }
                    else
                    {
                        RollRemaining();
                    }
                }
                else
                {
                    Console.WriteLine("Would you like:\n1: Re-roll all dice\n2: Re-roll remaining dice");
                    int choice = Utils.ReadIntChoice(1, 2);
                    if (choice == 1)
                    {
                        RollAll();
                    }
                    else
                    {
                        RollRemaining();
                    }
                }

                rolledScore = ScoreDice();
            }

            _score += rolledScore;
            if (_isBot)
            {
                Console.WriteLine($"Bot scored {rolledScore}\nBot's new score is {_score}");
            }
            else
            {
                Console.WriteLine($"Scored: {rolledScore}\nYour new score is {_score}");
            }

            if (_score >= 20)
            {
                _isOver = true;
               
            }

        }
      

    }
}
