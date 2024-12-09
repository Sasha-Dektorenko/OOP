namespace Lab3;

public class GameService : IGameService
{
    public IGameRepo gameRepo { get; }
    public IUserRepo userRepo { get; }

    public GameService(IGameRepo gameRepo, IUserRepo userRepo)
    {
        this.userRepo = userRepo;
        this.gameRepo = gameRepo;
    }
    
    public void CreateGame(int player1ID, int player2ID, int gameType, int rating = 0)
    {
        if (player1ID == player2ID) throw new Exception("Player ID's should be different");
        var player1 = userRepo.GetUserById(player1ID);
        var player2 = userRepo.GetUserById(player2ID);
        if (player1 == null) throw new Exception($"Player with id {player1ID} is not found");
        if (player2 == null) throw new Exception($"Player with id {player2ID} is not found");
        var game = Factory.CreateGame(player1, player2, gameType, rating);
        
        gameRepo.AddGame(game);
        
        player1.GameResult(game);
        player2.GameResult(game);
    }

    public void DisplayGameById(int id)
    {
        var game = gameRepo.GetGameById(id);
        if (game != null)
        {
            if (game.GetType() != typeof(TrainingGame))
            {
                Console.WriteLine(
                    $"Game ID: {game.GameID} \nGame type: {game.GameType}\nWinner: {game.Winner.UserName}" +
                    $"\nLooser: {game.Looser.UserName} \nPoints: {game.Points}");
            }
            else
                Console.WriteLine($"Game ID: {game.GameID} \nGame type: {game.GameType}\nWinner: {game.Winner.UserName}" +
                                  $"\nLooser: {game.Looser.UserName}");
            Console.WriteLine("---------------------");
        }
        else
        {
            throw new Exception($"Game with id {id} not found");
        }
    }

    public void DisplayAllGames()
    {
        foreach (var game in gameRepo.GetAllGames())
        {
           DisplayGameById(game.GameID);
        }
        gameRepo.GetAllGames();
    }

    public List<Game> GetGamesByPlayerId(int id)
    {
        return gameRepo.GetAllGames().Where(game => game.Winner.UserID == id || game.Looser.UserID == id).ToList();
    }

    public List<Game> GetGamesByGameType(string gameType)
    {
        if (string.IsNullOrWhiteSpace(gameType))
        {
            throw new ArgumentException("Game type cannot be null or empty");
        }

        return gameRepo.GetAllGames()
            .Where(game => game.GameType.Contains(gameType, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Game> GetGamesByPoints(int points)
    {
        return gameRepo.GetAllGames().Where(game => game.Points == points).ToList();
    }
}