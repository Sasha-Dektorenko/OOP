namespace Lab4;

public interface IUserService
{
    void CreateUser(string username, int accountType);
    void DisplayUserInfo(int id);
    void DisplayUserStats(int id);
    void DisplayAllUsers();
    void DeleteUser(int id);
    void UpdateUser(int id, string newName);
    List<GameAccount> GetAccountsByRating(int minRating, int maxRating);
    List<GameAccount> GetUsersWithNoGames();
    List<GameAccount> SearchAccountsByNamePart(string namePart);
    List<GameAccount> GetUsersByAccountType(string accountType);
}
