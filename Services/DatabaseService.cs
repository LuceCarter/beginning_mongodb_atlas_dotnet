using MongoDB.Driver;

namespace beginning_mongodb_atlas_dotnet.Services
{
    public class DatabaseService
    {
        public DatabaseService(string connectionString)
        {
            MongoClient mongoDBClient = new MongoClient(connectionString);
            List<string> databases = mongoDBClient.ListDatabaseNames().ToList();

            foreach (string db in databases)
            {
                Console.WriteLine(db);

            }
        }
    }
}
