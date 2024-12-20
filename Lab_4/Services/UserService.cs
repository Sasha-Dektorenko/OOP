namespace Lab4;

public class UserService : IUserService
{
    public IUserRepo userRepo { get; }
    public IGameRepo gameRepo { get; }

    public UserService(IUserRepo userRepo, IGameRepo gameRepo)
    {
        this.gameRepo = gameRepo;
        this.userRepo = userRepo;
    }

    public void CreateUser(string username, int accountType)
    {
        if (userRepo.GetUserByName(username) != null)
        {
            Console.WriteLine($"User with name {username} already exists");
        }
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
            Console.WriteLine("---------------------------");
            Console.WriteLine(
                $"User ID: {user.UserID}\nName: {user.UserName}\nCurrent rating: {user.CurrentRating}\nAccount type:{user.AccountType}");
            Console.WriteLine("---------------------------");
        }
        else
        {
            Console.WriteLine($"User with id {id} not found");
            return;
        }
    }

    public void DisplayUserStats(int id)
    {
        var user = userRepo.GetUserById(id);
        if (user != null)
        {
            Console.WriteLine("+--------+----------------+----------+--------+");
            Console.WriteLine($"         {user.UserName}'s game history            ");
            Console.WriteLine("+--------+----------------+----------+--------+");
            Console.WriteLine($"         Current rating:{user.CurrentRating}        ");
            Console.WriteLine("+--------+----------------+----------+--------+");
            var userGames = gameRepo.GetGamesByPlayerID(id);
            if (userGames.Count == 0)
            {
                Console.WriteLine("|            No games played yet.             |");
            }  else
            {
                Console.WriteLine("| GameID |    Opponent    |  Result  | Points |");
                Console.WriteLine("+--------+----------------+----------+--------+");

                foreach (var game in userGames)
                {
                    var opponent = game.Winner == user ? game.Looser.UserName : game.Winner.UserName;
                    var result = game.Winner == user ? "Win" : "Loss";
                    var points = game.Points;
                    var gameId = game.GameID;


                    Console.WriteLine($"| {gameId,-6} | {opponent,-14} | {result,-8} | {points,-6} |");
                }
            }


            Console.WriteLine("+--------+----------------+----------+-------+");
        }
        else
        {
            Console.WriteLine($"User with id {id} not found");
            return;
        }
    }

    public void DisplayAllUsers()
    {
        foreach (var user in userRepo.GetAllUsers())
        { 
            Console.WriteLine($"ID: {user.UserID} Name: {user.UserName}");
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

    public void DeleteUser(int id)
    {
        var accountToRemove = userRepo.GetUserById(id);
        if (accountToRemove != null)
        {
            userRepo.DeleteUser(accountToRemove);
        }
        else
        {
            Console.WriteLine($"There is no user with id: {id}");
            return;
        }
    }


    public void UpdateUser(int id, string newName)
    {
        var accountToUpdate = userRepo.GetUserById(id);
        if (accountToUpdate == null)
        {
            Console.WriteLine($"There is no user with this id: {id}");
            return;
        }
        if (userRepo.GetUserByName(newName) == null)
        {
            userRepo.UpdateUser(accountToUpdate, newName);
        }
        else
        {
            Console.WriteLine($"User with username \" {newName}\"already exists");
            return;
        }
    }

}
