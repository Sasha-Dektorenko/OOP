namespace Lab4;

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
        if (player1 == null)
        {
            Console.WriteLine($"Player with id {player1ID} is not found");
        }
        if (player2 == null)
        {
            Console.WriteLine($"Player with id {player2ID} is not found");
        }
        var game = Factory.CreateGame(player1, player2, gameType, rating);
        Console.WriteLine("Game created succesfully");
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

    public void DeleteGame(int id)
    {
        var gameToRemove = gameRepo.GetGameById(id);
        if (gameToRemove != null)
        {
            gameRepo.DeleteGame(gameToRemove);
        }
        else
        {
            Console.WriteLine($"There is no game with id: {id}");
            return;
        }
    }

    public List<Game> GetGamesByGameType(string gameType)
    {
        if (string.IsNullOrWhiteSpace(gameType))
        {
            throw new ArgumentException("Game type cannot be null or empty");
        }
        return gameRepo.GetAllGames()
            .Where(game => game.GameType.Contains(gameType, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Game> GetGamesByPoints(int points)
    {
        return gameRepo.GetAllGames().Where(game => game.Points == points).ToList();
    }
}