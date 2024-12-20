using System;

namespace Lab_1
{
    public class GameAccount
    {
       public string UserName { get; }
       public List<Game> GameHistory { get; private set; }

       public int CurrentRating
       {
           get
           {
               int rating = 100;  
               foreach (var game in GameHistory)
               {
                   if (game.Winner == this)
                   {
                       rating += game.Points; 
                   } 
                   else if (rating - game.Points < 1)
                   {
                       rating = 1;
                   }
                   else
                   {
                       rating -= game.Points;
                   }
               }
               return rating;
           }
       }


       public int GamesCount
       {
           get
           {
               return GameHistory.Count;
           }
       }

       public GameAccount(string userName)
       {
           UserName = userName;
           GameHistory = new List<Game>();
       }

       public void WinGame(GameAccount opponent, int rating)
       {
           if (rating < 0) throw new ArgumentException("Rating cannot be negative.");
           var game = new Game(this, opponent, rating);
           GameHistory.Add(game);
           opponent.GameHistory.Add(game);
           Console.WriteLine($"{UserName} won {opponent.UserName}, points played for: {rating}.");
       }

       public void LoseGame(GameAccount opponent, int rating)
       {
           if (rating < 0) throw new ArgumentException("Rating cannot be negative.");
           var game = new Game(opponent, this, rating);
           GameHistory.Add(game);
           opponent.GameHistory.Add(game);
           Console.WriteLine($"{UserName} lost {opponent.UserName}, points played for: {rating}.");
       }

       public void GetStats()
       {
           Console.WriteLine("+--------+----------------+----------+--------+");
           Console.WriteLine($"         {UserName}'s game history            ");
           Console.WriteLine("+--------+----------------+----------+--------+");
           if (GameHistory.Count == 0)
           {
               Console.WriteLine("|            No games played yet.             |");
           }
           else
           {
               Console.WriteLine("| GameID |    Opponent    |  Result  | Points |");
               Console.WriteLine("+--------+----------------+----------+--------+");
               
               foreach (var game in GameHistory)
               {
                   string opponent = game.Winner == this ? game.Looser.UserName : game.Winner.UserName;
                   string result = game.Winner == this ? "Win" : "Loss";
                   int points = game.Points;
                   int gameId = game.GameID;


                   Console.WriteLine($"| {gameId,-6} | {opponent,-14} | {result,-8} | {points,-6} |");
               }
           }


           Console.WriteLine("+--------+----------------+----------+-------+");
       }

       
       
    }
}