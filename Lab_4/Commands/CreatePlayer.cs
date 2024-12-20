namespace Lab4;

public class CreatePlayer : ICommand
{
    public IUserService userService { get; }

    public CreatePlayer(IUserService userService)
    {
        this.userService = userService;
    }

    public void Execute()
    {
        bool ind = true;
        while (ind)
        {
            Console.WriteLine("Enter user name: ");
            string nameInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nameInput))
            {
                Console.WriteLine("Name cannot be empty.");
                continue;
            }

            var username = nameInput;
            Console.WriteLine("Enter account type (1-Standart, 2-Premium, 3-Streak): ");
            var accountType = int.Parse(Console.ReadLine());
            if (accountType <= 3 && accountType > 0)
            {
                userService.CreateUser(username, accountType);
                Console.WriteLine($"Player {username} Created");
                ind = false;
            }
            else
            {
                Console.WriteLine("Invalid number entered, pick number from 1 to 3");
            }
        }
    }
    
    public string GetInfo()
    {
        return "Create a new player";
    }
}