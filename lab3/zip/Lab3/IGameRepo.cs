namespace Lab3;

public interface IGameRepo
{
    void CreateGame(int player1ID, int player2ID, int gameType, int rating = 0);
    List<Game> GetAllGames();
    Game? GetGameById(int id);
    void DeleteGame(int id);
}

