namespace CourseWork;

public class DisplayPlayerStats : ICommand
{
    public IUserService userService { get; }

    public DisplayPlayerStats(IUserService userService)
    {
        this.userService = userService;
    }

    public void Execute()
    {
        Console.WriteLine("Enter player ID(type me if you want to see your stats):");
        string idInput = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(idInput))
        {
            Console.WriteLine("ID cannot be empty.");
            return;
        }

        int id;
        if (idInput.Equals("me", StringComparison.OrdinalIgnoreCase))
        {
            if (userService.LoggedInUserId == 0)
            {
                Console.WriteLine("You are not logged in, do you want to? (yes/no):");
                string choice = Console.ReadLine()?.ToLower();

                if (choice.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    var loginUser = new LoginPlayer(userService);
                    loginUser.Execute();
                }
                else return;
            }
            id = userService.LoggedInUserId;
        } else id = int.Parse(idInput);
        
        if (id <= 0)
        {
            Console.WriteLine("ID cannot be zero or below");
        }
        userService.DisplayUserStats(id);
    }

    public string GetInfo()
    {
        return "Show player current stats";
    }
}