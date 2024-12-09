namespace Lab3;

public interface IGameRepo
{
    void AddGame(Game game);
    List<Game> GetAllGames();
    Game? GetGameById(int id);
    void DeleteGame(int id);
}

