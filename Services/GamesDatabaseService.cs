using BeginningMongoDBAtlasDotNet.Models;
using MongoDB.Driver;

namespace BeginningMongoDBAtlasDotNet.Services
{
    public class GamesDatabaseService
    {
        private readonly IMongoCollection<Game> _games;
        public GamesDatabaseService(string connectionString)
        {
            var mongoDBClient = new MongoClient(connectionString);
            var database = mongoDBClient.GetDatabase("GamesDB");

            _games = database.GetCollection<Game>("Games");
        }

        public List<Game> Get() => _games.Find(game => true).ToList();

        public Game GetOne(string id) => _games.Find(game => game.Id == id).FirstOrDefault();

        public void CreateOne(Game game) => _games.InsertOne(game);

        public void CreateMany(Game[] games) => _games.InsertMany(games);

        public void UpdateOne(string id, Game updatedGame) => _games.ReplaceOne(game => game.Id == id, updatedGame);

        public void DeleteOne(string id)
        {
            FilterDefinition<Game> filter = Builders<Game>.Filter.Eq("_id", id);
            _games.DeleteOne(filter);
        }
    }
}
