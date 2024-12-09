namespace Lab3;

public interface IGameService
{
    void DisplayAllGames();
    List<Game> GetGamesByPlayerId(int id);
    List<Game> GetGamesByGameType(string gameType);
    void DisplayGameById(int id);
    List<Game> GetGamesByPoints(int points);
}