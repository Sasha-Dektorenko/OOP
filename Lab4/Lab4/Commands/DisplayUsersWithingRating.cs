namespace Lab4;

public class DisplayUsersWithingRating : ICommand
{
    public IUserService userService { get; }

    public DisplayUsersWithingRating(IUserService userService)
    {
        this.userService = userService;
    }

    public void Execute()
    {
        string minInput = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(minInput))
        {
            Console.WriteLine("Rating cannot be empty.");
            return;
        }
        var min = int.Parse(minInput);
        if (min <= 0)
        {
            Console.WriteLine("Rating cannot be zero or below");
            return;
        }
        string maxInput = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(minInput))
        {
            Console.WriteLine("Rating cannot be empty.");
            return;
        }
        var max = int.Parse(minInput);
        if (max <= 0)
        {
            Console.WriteLine("Rating cannot be zero or below");
            return;
        }
        var gamersWithSpecificrating = userService.GetAccountsByRating(min, max);
        if (gamersWithSpecificrating.Count != 0)
        {
            foreach (var gamer in gamersWithSpecificrating)
            {
                Console.WriteLine($"ID:{gamer.UserID} Name:{gamer.UserName}");
            }
        } else Console.WriteLine("No gamers within such rating");
    }

    public string GetInfo()
    {
        return "Show players withing specific rating";
    }
}