using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M
{

    struct GamePlay
    {
        public int gameType { get; set; }
        public int score { get; set; }
    }
     struct GameStats // needs to store number of plays, high scores, etc
    {
        public GameStats(List<GamePlay> plays  )
        {
            Plays = plays;
        }

        public List<GamePlay> Plays { get; set; }

    }
    internal class Statistics
    {
        private GameStats SevensOutStats { get; set; }
        private GameStats ThreeOrMoreStats { get; set; }

        public Statistics()
        {
            SevensOutStats = new GameStats(new List<GamePlay>());
            ThreeOrMoreStats = new GameStats(new List<GamePlay>());
        }

        public void RegisterSevensOutGame(int score, int type)
        {
            SevensOutStats.Plays.Add(new GamePlay { gameType = type, score = score });
        }

        public void RegisterThreeOrMoreGame(int score, int type)
        {
            ThreeOrMoreStats.Plays.Add(new GamePlay { gameType = type, score = score });

        }

        public int ComputeThreeOrMoreHighScore()
        {
            int highScore = 0;
            foreach (GamePlay play in ThreeOrMoreStats.Plays)
            {
                if (play.score > highScore)
                {
                    highScore = play.score;
                }
            }
            return highScore;
        }

        public int ComputeSevensOutHighScore()
        {
            int highScore = 0;
            foreach (GamePlay play in SevensOutStats.Plays)
            {
                if (play.score > highScore)
                {
                    highScore = play.score;
                }
            }
            return highScore;
        }

        public float ComputeThreeOrMoreAverageScore()
        {

            int totalScore = 0;
            foreach (GamePlay play in ThreeOrMoreStats.Plays)
            {
                totalScore += play.score;
            }

          
            try
            {
                float avgScore =  totalScore / ThreeOrMoreStats.Plays.Count;
                return avgScore;
            }
            catch (DivideByZeroException e)
            {
                return 0;
            }

          
        }

        public float ComputeSevensOutAverageScore()
        {
            int totalScore = 0;
            foreach (GamePlay play in SevensOutStats.Plays)
            {
                totalScore += play.score;
            }

            try
            {
                float avgScore = totalScore / SevensOutStats.Plays.Count;
                return avgScore;
            }
            catch (DivideByZeroException e)
            {
                return 0;
            }
        }

        public int ComputeThreeOrMorePlays()
        {
            return ThreeOrMoreStats.Plays.Count;
        }

        public int ComputeSevensOutPlays()
        {
            return SevensOutStats.Plays.Count;
        }

        public void Display()
        {
            Console.WriteLine($"Displaying stats for Sevens Out:\n\nHigh score: {ComputeSevensOutHighScore()}\nAverage score: {ComputeSevensOutAverageScore()}\nNumber of plays: {ComputeSevensOutPlays()}\n");
            Console.WriteLine($"Displaying stats for Three or More:\n\nHigh score: {ComputeThreeOrMoreHighScore()}\nAverage score: {ComputeThreeOrMoreAverageScore()}\nNumber of plays: {ComputeThreeOrMorePlays()}\n");
            Console.WriteLine(
                $"Total number of plays: {ComputeSevensOutPlays() + ComputeThreeOrMorePlays()}\n");

        }
    }
}
