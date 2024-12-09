namespace Lab3;

public class GameRepo : IGameRepo
{
    public DbContext context { get; }

    public GameRepo(DbContext context)
    {
        this.context = context;
    }

    public void AddGame(Game game)
    {
        context.Games.Add(game);
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