namespace Lab4;

public class SearchPlayersByNamePart : ICommand
{
    public IUserService userService { get; }

    public SearchPlayersByNamePart(IUserService userService)
    {
        this.userService = userService;
    }

    public void Execute()
    {
        Console.WriteLine("Enter part of player name: ");
        string nameInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nameInput))
        {
            Console.WriteLine("Name cannot be empty.");
            return;
        }
        var namePart = nameInput;
        var gamersWithSpecificName = userService.SearchAccountsByNamePart(namePart);
        if (gamersWithSpecificName.Count != 0)
        {
            foreach (var gamer in gamersWithSpecificName)
            {
                Console.WriteLine($"{gamer.UserID}. {gamer.UserName}");
            }
        } else Console.WriteLine("No gamers with such name part\n");
    }

    public string GetInfo()
    {
        return "Show players with entered name part";
    }
}