namespace Lab4;

public class DeletePlayer : ICommand
{
    public IUserService userService { get; }

    public DeletePlayer(IUserService userService)
    {
        this.userService = userService;
    }

    public void Execute()
    {
        Console.WriteLine("Enter player ID:");
        string idInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(idInput))
        {
            Console.WriteLine("ID cannot be empty.");
            return;
        }
        var id = int.Parse(idInput);
        if (id <= 0)
        {
            Console.WriteLine("ID cannot be zero or below");
            return;
        }
        userService.DeleteUser(id);
        Console.WriteLine($"User with ID {id} deleted");
    }

    public string GetInfo()
    {
        return "Delete user by id";
    }
}