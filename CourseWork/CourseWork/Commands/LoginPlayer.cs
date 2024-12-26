namespace CourseWork;

public class LoginPlayer : ICommand
{
    public IUserService userService { get; }

    public LoginPlayer(IUserService userService)
    {
        this.userService = userService;
    }

    public void Execute()
    {
        bool ind = true;
        while (ind)
        {
            if (userService.LoggedInUserId != 0)
            {
                Console.WriteLine($"You are already logged in, do you want to change account? (yes/no): ");
                string choice = Console.ReadLine()?.ToLower();
                

                if (choice.Equals("no", StringComparison.OrdinalIgnoreCase))
                {
                    return;
                } 
            }
            Console.WriteLine("Enter your name: ");
            string nameInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nameInput))
            {
                Console.WriteLine("Name cannot be empty.");
                continue;
            }

            if (userService.GetRegisteredUser(nameInput) == null)
            {
                Console.WriteLine($"User not found, do you want to register a new account? (yes/no): ");
                string choice = Console.ReadLine()?.ToLower();

                if (choice.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    var registerPlayer = new RegisterPlayer(userService);
                    registerPlayer.Execute();
                }
                else return;
            }
            
            if (userService.GetRegisteredUser(nameInput).UserID == userService.LoggedInUserId)
            {
                Console.WriteLine("This is the same account you were trying to loginl");
                return;
            }

            var username = nameInput;
            
            Console.WriteLine("Enter your password: ");
            var passwdInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(passwdInput))
            {
                Console.WriteLine("Password cannot be empty.");
                continue;
            }

            if (!passwdInput.Equals(userService.GetRegisteredUser(username).Password, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Invalid password, try again");
                continue;
            }
            var password = passwdInput;
            
            userService.LoginUser(username, password);
            ind = false;
        }
    }
    
    public string GetInfo()
    {
        return "Login by name and password";
    }
}