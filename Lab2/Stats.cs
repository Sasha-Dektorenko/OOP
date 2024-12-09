namespace Lab_2;

public static class Stats
{
    public static void Get(GameAccount gamer)
    {
        Console.WriteLine("+--------+----------------+----------+--------+");
        Console.WriteLine($"         {gamer.UserName}'s game history            ");
        Console.WriteLine("+--------+----------------+----------+--------+");
        if (gamer.GameHistory.Count == 0)
        {
            Console.WriteLine("|            No games played yet.             |");
        }
        else
        {
            Console.WriteLine("| GameID |    Opponent    |  Result  | Points |");
            Console.WriteLine("+--------+----------------+----------+--------+");

            foreach (var game in gamer.GameHistory)
            {
                var opponent = game.Winner == gamer ? game.Looser.UserName : game.Winner.UserName;
                var result = game.Winner == gamer ? "Win" : "Loss";
                var points = game.Points;
                var gameId = game.GameID;


                Console.WriteLine($"| {gameId,-6} | {opponent,-14} | {result,-8} | {points,-6} |");
            }
        }


        Console.WriteLine("+--------+----------------+----------+-------+");
    }
}