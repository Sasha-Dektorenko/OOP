namespace Lab3;

public class UserService : IUserService
{
    public IUserRepo userRepo { get; }

    public UserService(IUserRepo userRepo)
    {
        this.userRepo = userRepo;
    }

    public void CreateUser(string username, int accountType)
    {
        if (userRepo.GetUserByName(username) != null) throw new Exception($"User with name {username} already exists");
        GameAccount gameAccount;
        if (accountType == 2) gameAccount = new PremiumGameAccount(username);
        else if (accountType == 3) gameAccount = new StreakGameAccount(username);
        else gameAccount = new GameAccount(username);
        userRepo.AddUser(gameAccount);
    }

    public void DisplayUserInfo(int id)
    {
        var user = userRepo.GetUserById(id);
        if (user != null)
        {
            Console.WriteLine(
                $"User ID: {user.UserID}\nName: {user.UserName}\nCurrent rating: {user.CurrentRating}\nAccount type:{user.AccountType}");
            Console.WriteLine("---------------------------");
        }
        else
        {
            throw new Exception($"User with id {id} not found");
        }
    }

    public void DisplayUserStats(int id)
    {
        var user = userRepo.GetUserById(id);
        if (user != null)
        {
            Stats.Get(user);
        }
        else
        {
            throw new Exception($"User with id {id} not found");
        }
    }

    public void DisplayAllUsers()
    {
        foreach (var user in userRepo.GetAllUsers())
        { 
            DisplayUserInfo(user.UserID);
        }
    }
    
    public List<GameAccount> GetAccountsByRating(int minRating, int maxRating)
    {
        return userRepo.GetAllUsers()
            .Where(account => account.CurrentRating >= minRating && account.CurrentRating <= maxRating)
            .ToList();
    }
    
    public List<GameAccount> GetUsersWithNoGames()
    {
        return userRepo.GetAllUsers()
            .Where(account => account.GamesCount == 0)
            .ToList();
    }
    
    public List<GameAccount> SearchAccountsByNamePart(string namePart)
    {
        if (string.IsNullOrWhiteSpace(namePart))
        {
            throw new ArgumentException("Name part cannot be null or empty");
        }

        return userRepo.GetAllUsers()
            .Where(account => account.UserName.Contains(namePart, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<GameAccount> GetUsersByAccountType(string accountType)
    {
        if (string.IsNullOrWhiteSpace(accountType))
        {
            throw new ArgumentException("Account type cannot be null or empty");
        }

        return userRepo.GetAllUsers()
            .Where(user => string.Equals(user.AccountType, accountType, StringComparison.OrdinalIgnoreCase))
            .ToList();
        
    }


}
