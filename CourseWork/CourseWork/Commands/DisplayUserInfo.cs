namespace CourseWork;

public class DisplayUserInfo : ICommand
{
    public IUserService userService { get; }

    public DisplayUserInfo(IUserService userService)
    {
        this.userService = userService;
    }

    public void Execute()
    {
        Console.WriteLine("Enter player ID(type me if you want to see your information):");
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
        
        userService.DisplayUserInfo(id);
    }

    public string GetInfo()
    {
        return "Display player information";
    }
}