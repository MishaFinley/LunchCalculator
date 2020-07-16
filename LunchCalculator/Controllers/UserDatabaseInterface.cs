using LunchCalculator.Models;
using MongoDB.Driver;
using System.Linq;

namespace LunchCalculator.Controllers
{
    public class UserDatabaseInterface
    {
        private static string dbConnectionString = "mongodb+srv://ahsim:misha12@cluster0-otacx.mongodb.net/Users?retryWrites=true&w=majority";
        private static MongoClient dbClient = new MongoClient(dbConnectionString);
        private static IMongoDatabase database = dbClient.GetDatabase("LunchCalc");
        private static IMongoCollection<User> users = database.GetCollection<User>("users");
        public static void createUser(User user)
        {
            users.InsertOne(user);
        }
        public static User readUser(string username)
        {
            var filter = Builders<User>.Filter.Eq("username", username);
            return users.Find(filter).FirstOrDefault();
        }
        public static void updateUser(User user)
        {
            var filter = Builders<User>.Filter.Eq("username", user.username);
            users.ReplaceOne(filter, user);
        }
        public static void deleteUser(string username)
        {
            var filter = Builders<User>.Filter.Eq("username", username);
            users.DeleteMany(filter);
        }
    }
}
