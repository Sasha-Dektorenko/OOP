
namespace Lab4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            DbContext context = new DbContext();
            IUserRepo userRepo = new UserRepo(context);
            IGameRepo gameRepo = new GameRepo(context);
            IGameService gameService = new GameService(gameRepo, userRepo);
            IUserService userService = new UserService(userRepo, gameRepo);
            
            var commandHandler = new CommandHandler(userService, gameService);
            commandHandler.Start();
        }
    }
}