using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M
{
    internal class Utils
    {
        public static int ReadIntChoice(int min, int max)
        {
            int choice = min - 1;

            while (choice < min || choice > max)
            {
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    if (choice < min || choice > max)
                    {
                        Console.WriteLine("Invalid choice, please try again.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid choice, please try again.");
                }
            }
            return choice;
        }   

        public static void PlaySevensOutWithPlayer(Statistics stats, bool withBot)
        {
            SevensOut playerOneGame = new SevensOut(false);
            SevensOut playerTwoGame;
            if (withBot)
            {
                playerTwoGame = new SevensOut(true);
            } else
            {
                playerTwoGame = new SevensOut(false);
            }

            Console.WriteLine("Player One's turn:");
            playerOneGame.Play();
            int playerOneScore = playerOneGame.GetScore();

            
            if (withBot)
            {
                Console.WriteLine("Bot's turn:");
            }
            else
            {
                Console.WriteLine("Player Two's turn:");
            }

            playerTwoGame.Play();
            int playerTwoScore = playerTwoGame.GetScore();

            if (playerOneScore > playerTwoScore)
            {
                Console.WriteLine("Player One wins!");
            }
            else if (playerOneScore < playerTwoScore)
            {
                Console.WriteLine("Player Two wins!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }

            Console.WriteLine($"Player One's score: {playerOneScore}\nPlayer Two's score: {playerTwoScore}");

            stats.RegisterSevensOutGame(playerOneScore, withBot ? 3 : 2);
            stats.RegisterSevensOutGame(playerTwoScore, withBot ? 3 : 2);
        }

        public static void PlaySevensOutAlone(Statistics stats)
        {
            SevensOut game = new SevensOut(false);
            game.Play();

            int playerScore = game.GetScore();

            Console.WriteLine($"Final score: {playerScore}");

            stats.RegisterSevensOutGame(playerScore, 1);
        }

        public static void PlayThreeOrMoreAlone(Statistics stats)
        {
            ThreeOrMore game = new ThreeOrMore(false);
            while (!game.IsOver())
            {
                game.Play();
            }

            int playerScore = game.GetScore();
            Console.WriteLine($"Final score: {playerScore}");

            stats.RegisterThreeOrMoreGame(playerScore, 1);
        }

        public static void PlayThreeOrMoreWithPlayer(Statistics stats, bool withBot)
        {
            bool playerOnesTurn = true;
            ThreeOrMore playerOneGame = new ThreeOrMore(false);
            ThreeOrMore playerTwoGame;
            if (withBot)
            {
                playerTwoGame = new ThreeOrMore(true);
            }
            else
            {
                playerTwoGame = new ThreeOrMore(false);
            }

            while (!playerOneGame.IsOver() && !playerTwoGame.IsOver())
            {
                if (playerOnesTurn)
                {
                    Console.WriteLine("\n\nPlayer One's turn:");
                    playerOneGame.Play();
                    playerOnesTurn = false;
                }
                else
                {
                    if (withBot)
                    {
                        Console.WriteLine("\n\nBot's turn:");
                    }
                    else
                    {
                        Console.WriteLine("\n\nPlayer Two's turn:");
                    }
                    playerTwoGame.Play();
                    playerOnesTurn = true;
                }

            }

            int playerOneScore = playerOneGame.GetScore();
            int playerTwoScore = playerTwoGame.GetScore();

            Console.WriteLine($"Player One's score: {playerOneScore}\nPlayer Two's score: {playerTwoScore}");

            if (playerOneScore > playerTwoScore)
            {
                Console.WriteLine("Player One wins!");
            }
            else if (playerOneScore < playerTwoScore)
            {
                Console.WriteLine("Player Two wins!");
            }

            stats.RegisterThreeOrMoreGame(playerOneScore, withBot ? 3 : 2);
            stats.RegisterThreeOrMoreGame(playerTwoScore, withBot ? 3 : 2);

        }

      
        public static void PlaySevensOut(Statistics stats, int playChoice)
        {
            switch (playChoice)
            {
                case 1:
                    PlaySevensOutAlone(stats);
                    break;
                case 2:
                    PlaySevensOutWithPlayer(stats, false);
                    break;
                case 3:
                    PlaySevensOutWithPlayer(stats, true);
                    break;
            }
        }

        public static void PlayThreeOrMore(Statistics stats, int playChoice)
        {
            switch (playChoice)
            {
                case 1:
                    PlayThreeOrMoreAlone(stats);
                    break;
                case 2:
                    PlayThreeOrMoreWithPlayer(stats, false);
                    break;
                case 3:
                    PlayThreeOrMoreWithPlayer(stats, true);
                    break;
            }
        }
    }
}
