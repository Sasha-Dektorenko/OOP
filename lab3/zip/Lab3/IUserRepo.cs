namespace Lab3;

public interface IUserRepo
{
    void AddUser(GameAccount gameAccount);
    GameAccount? GetUserById(int id);
    GameAccount? GetUserByName(string username);
    void UpdateUser(int id, string newName);
    void DeleteUser(int id);
    List<GameAccount> GetAllUsers();
}
