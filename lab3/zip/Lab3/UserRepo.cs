namespace Lab3;

public class UserRepo : IUserRepo
{
    public DbContext context { get; }

    public UserRepo(DbContext context)
    {
        this.context = context;
    }

    public void AddUser(GameAccount gameAccount)
    {
        context.Gamers.Add(gameAccount);
    }

    public GameAccount? GetUserById(int id)
    {
        return context.Gamers.FirstOrDefault(ga => ga.UserID == id);
    }

    public GameAccount? GetUserByName(string username)
    {
        return context.Gamers.Find(ga => ga.UserName == username);
    }

    public void UpdateUser(int id, string newName)
    {
        var accountToUpdate = GetUserById(id);
        if (accountToUpdate == null) throw new Exception($"There is no user with this id: {id}");
        if (GetUserByName(newName) == null)
        {
            accountToUpdate.UserName = newName;
        }
        else throw new Exception($"User with username \" {newName}\"already exists");
    }

    public void DeleteUser(int id)
    {
        var accountToRemove = GetUserById(id);
        if (accountToRemove != null)
        {
            context.Gamers.Remove(accountToRemove);
        } else throw new Exception($"There is no user with this id: {id}");
    }
    
    public List<GameAccount> GetAllUsers()
    {
        return context.Gamers;
    }
    
}
