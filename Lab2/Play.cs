namespace Lab_2;

public static class Play
{
    public static void game(GameAccount player1, GameAccount player2, int gameType)
    {
        if (gameType == 1)
        {
            var ind = true;
            do
            {
                Console.WriteLine("Enter rating of a game: ");
                var input = Console.ReadLine();
                int.TryParse(input, out var rating);
                if (rating > 1)
                {
                    var defaultGame = Factory.CreateGame(player1, player2, gameType, rating);
                    player1.GameResult(defaultGame);
                    player2.GameResult(defaultGame);
                    Console.WriteLine();
                    Console.WriteLine($"{defaultGame.Winner.UserName} won {defaultGame.Looser.UserName} " +
                                      $"in default game on rating: {rating}");
                    Console.WriteLine();
                    ind = false;
                }
                else
                {
                    throw new Exception("Rating cannot be negative or zero, please try again");
                }
            } while (ind);
        }
        else if (gameType == 2)
        {
            var trainingGame = Factory.CreateGame(player1, player2, gameType, 0);
            player1.GameResult(trainingGame);
            player2.GameResult(trainingGame);
            Console.WriteLine();
            Console.WriteLine($"{trainingGame.Winner.UserName} won {trainingGame.Looser.UserName} in training game \n");
        } else if (gameType == 3)
        {
            Console.WriteLine($"Current rating of {player1}: {player1.CurrentRating} \n");
            Console.WriteLine($"Current rating of {player2}: {player2.CurrentRating} \n");

            var allOrNothingGame = Factory.CreateGame(player1, player2, gameType, 0);
            player1.GameResult(allOrNothingGame);
            player2.GameResult(allOrNothingGame);
            Console.WriteLine();
            Console.WriteLine($"{allOrNothingGame.Winner.UserName} won {allOrNothingGame.Looser.UserName} " +
                              $"in \"All or nothing game and recieves: {allOrNothingGame.Points} points \n");
        }
    }
}