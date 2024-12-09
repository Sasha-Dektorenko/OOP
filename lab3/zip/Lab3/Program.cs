
namespace Lab3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            DbContext context = new DbContext();
            IUserRepo userRepo = new UserRepo(context);
            IUserService userService = new UserService(userRepo);
            IGameRepo gameRepo = new GameRepo(context, userRepo);
            IGameService gameService = new GameService(gameRepo);
            
            userService.CreateUser("Vanya", 1);
            userService.CreateUser("Roma", 2);
            userService.CreateUser("Vova", 3);
            userService.CreateUser("Sasha", 3);
            userService.DisplayAllUsers();
            userRepo.DeleteUser(1);
            userService.DisplayUserStats(2);
            userRepo.UpdateUser(5, "Jora");
            userService.DisplayUserInfo(5);
            gameRepo.CreateGame(2,3, 1, 25);
            //gameService.DisplayAllGames();
            gameRepo.CreateGame(3,4,2);
            gameRepo.CreateGame(5,6,3);
            gameRepo.CreateGame(3,4,1,45);
            gameRepo.DeleteGame(6);
            //gameService.DisplayAllGames();
            /*var gamesByPlayerId = gameService.GetGamesByPlayerId(3);
            if (gamesByPlayerId.Count != 0)
            {
                foreach (var game in gamesByPlayerId)
                {
                    gameService.DisplayGameById(game.GameID);
                }
            } else Console.WriteLine("No games with such player");*/
            
            /*var gamesByGameType = gameService.GetGamesByGameType("All");
            if (gamesByGameType.Count != 0)
            {
                foreach (var game in gamesByGameType)
                {
                    gameService.DisplayGameById(game.GameID);
                }
            } else Console.WriteLine("No games with such type");*/
            
            var gamesByPoints = gameService.GetGamesByPoints(25);
            if (gamesByPoints.Count != 0)
            {
                foreach (var game in gamesByPoints)
                {
                    gameService.DisplayGameById(game.GameID);
                }
            } else Console.WriteLine("No games where players played for such points");
            
            
            /*
            var gamersWithSpecificrating = userService.GetAccountsByRating(20, 60);
            if (gamersWithSpecificrating.Count != 0)
            {
                foreach (var gamer in gamersWithSpecificrating)
                {
                    Console.WriteLine($"{gamer.UserID}. {gamer.UserName}");
                }
            } else Console.WriteLine("No gamers within such rating");

            var gamersWithNoGames = userService.GetUsersWithNoGames();
            if (gamersWithNoGames.Count != 0)
            {
                foreach (var gamer in gamersWithNoGames)
                {
                    Console.WriteLine($"{gamer.UserID}. {gamer.UserName}");
                }
            } else Console.WriteLine("No gamers without games\n");

            Console.WriteLine("\n \n");
            var gamersWithSpecificName = userService.SearchAccountsByNamePart("om");
            if (gamersWithSpecificName.Count != 0)
            {
                foreach (var gamer in gamersWithSpecificName)
                {
                    Console.WriteLine($"{gamer.UserID}. {gamer.UserName}");
                }
            } else Console.WriteLine("No gamers with such name part\n");

            Console.WriteLine("\n \n");
            var accountsByType = userService.GetUsersByAccountType("Standart");
            if (accountsByType.Count != 0)
            {
                foreach (var gamer in accountsByType)
                {
                    Console.WriteLine($"{gamer.UserID}. {gamer.UserName}");
                }
            } else Console.WriteLine($"No accounts with such type found or type of account is written incorrectly");
*/
        }
    }
}