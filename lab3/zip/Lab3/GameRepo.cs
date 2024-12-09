namespace Lab3;

public class GameRepo : IGameRepo
{
    public DbContext context { get; }
    public IUserRepo userRepo { get; }

    public GameRepo(DbContext context, IUserRepo userRepo)
    {
        this.userRepo = userRepo;
        this.context = context;
    }

    public void CreateGame(int player1ID, int player2ID, int gameType, int rating = 0)
    {
        if (player1ID == player2ID) throw new Exception("Player ID's should be different");
        var player1 = userRepo.GetUserById(player1ID);
        var player2 = userRepo.GetUserById(player2ID);
        if (player1 == null) throw new Exception($"Player with id {player1ID} is not found");
        if (player2 == null) throw new Exception($"Player with id {player2ID} is not found");
        var game = Factory.CreateGame(player1, player2, gameType, rating);
        
        context.Games.Add(game);
        
        player1.GameResult(game);
        player2.GameResult(game);
    }

    public List<Game> GetAllGames()
    {
        return context.Games;
    }

    public Game? GetGameById(int id)
    {
        return context.Games.FirstOrDefault(game => game.GameID == id);
    }

    public void DeleteGame(int id)
    {
        var gameToRemove = GetGameById(id);
        if (gameToRemove != null)
        {
            context.Games.Remove(gameToRemove);
        }
        else
        {
            throw new Exception($"Game with ID {id} does not exist");
        }
    }
    
}