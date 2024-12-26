namespace CourseWork;

public class RegisterPlayer : ICommand
{
    public IUserService userService { get; }

    public RegisterPlayer(IUserService userService)
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
            
            Console.WriteLine("Enter password (minimum 8 characters): ");
            var passwdInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(passwdInput))
            {
                Console.WriteLine("Password cannot be empty.");
                continue;
            }

            if (passwdInput.Length < 8)
            {
                Console.WriteLine("Password is too short, try again.");
                continue;
            }
            var password = passwdInput;
            
            Console.WriteLine("Choose account type (1-Standart, 2-Premium, 3-Streak): ");
            var accountType = int.Parse(Console.ReadLine());
            if (accountType <= 3 && accountType > 0)
            {
                userService.RegisterUser(username, password, accountType);
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
        return "Register a new player";
    }
}