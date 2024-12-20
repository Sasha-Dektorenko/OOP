namespace Lab4;

public interface IGameService
{
    void DisplayAllGames();
    List<Game> GetGamesByGameType(string gameType);
    void DisplayGameById(int id);
    List<Game> GetGamesByPoints(int points);
    void CreateGame(int player1ID, int player2ID, int gameType, int rating = 0);
    void DeleteGame(int id);
}