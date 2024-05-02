using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMP1903M
{
    internal class Program
    {
        static void Main(string[] args)
        {
   
            Statistics stats = new Statistics();

            while (true)
            {
                Console.WriteLine("What game would you like to play?\n1. Sevens Out\n2. Three or More\n3. Statistics\n4. Perform Tests\n5. Exit");
                int gameChoice = Utils.ReadIntChoice(1, 5);
                if (gameChoice == 5) { break; }

                if (gameChoice == 3)
                {
                    stats.Display();
                    continue;
                }

                if (gameChoice == 4)
                {
                    Testing test = new Testing();
                    test.Test();
                    continue;
                }

                Console.WriteLine("How would you like to play?\n1. Alone\n2. With another player (Local)\n3. With a bot\n4. Cancel");
                int playChoice = Utils.ReadIntChoice(1, 4);
                if (playChoice == 4) { continue; }

                switch (gameChoice)
                {
                  
                    case 1:
                        Utils.PlaySevensOut(stats, playChoice);
                        break;
                    case 2:
                        Utils.PlayThreeOrMore(stats, playChoice);
                        break;
                }

            }
        }
    }
}
