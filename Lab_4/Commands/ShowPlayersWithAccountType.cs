namespace Lab4;

public class ShowPlayersWithAccountType : ICommand
{
    public IUserService userService { get; }

    public ShowPlayersWithAccountType(IUserService userService)
    {
        this.userService = userService;
    }

    public void Execute()
    {
        Console.WriteLine("Enter type of account: ");
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Account type name cannot be empty.");
            return;
        }
        var accountType = input;
        var accountsByType = userService.GetUsersByAccountType(accountType);
        if (accountsByType.Count != 0)
        {
            foreach (var gamer in accountsByType)
            {
                Console.WriteLine($"{gamer.UserID}. {gamer.UserName}");
            }
        } else Console.WriteLine($"No accounts with such type found or type of account is written incorrectly");
    }

    public string GetInfo()
    {
        return "Show players with entered account type";
    }
}